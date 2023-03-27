using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI
{
    public class PictureBoxZoomMoveController<T>
    {
        #region CONSTANT
        private const double CST_ZOOMFACTOR = 1.25;
        private const int CST_MINMAX = 5;
        #endregion

        #region event
        public event MouseEventHandler MouseClick;
        public event Action<T> OnGraphicPathClick;
        #endregion

        private PictureBox _pictureBox;
        private Panel _panel;
        private Point _mouseDownLocation;

        private bool _isLeftClickDown = false;

        private List<Tuple<GraphicsPath, T>> _ListPath = new List<Tuple<GraphicsPath, T>>();

        public PictureBoxZoomMoveController(Panel panel)
        {
            _panel = panel;
            // Init
            _pictureBox = new PictureBox();
            // TODO: Understand and clean this
            _pictureBox.Location = new Point(0, 0);
            _pictureBox.TabIndex = 3;
            _pictureBox.TabStop = false;
            _panel.Controls.Add(this._pictureBox);
            _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _pictureBox.Location = new Point(0, 0);
            _panel.Cursor = Cursors.NoMove2D;
            _panel.AutoScroll = true;
            _panel.MouseEnter += new EventHandler(OnPicBoxMouseEnter);
            _panel.MouseWheel += new MouseEventHandler(OnPanelMouseWheel);
            _panel.SizeChanged += new EventHandler(OnSizeChange);
            _pictureBox.MouseEnter += new EventHandler(OnPicBoxMouseEnter);
            _pictureBox.MouseDown += new MouseEventHandler(OnPicMouseDown);
            _pictureBox.MouseMove += new MouseEventHandler(OnPicMouseMove);
            _pictureBox.MouseClick += new MouseEventHandler(OnPicMouseClick);
            _pictureBox.Paint += new PaintEventHandler(OnPicImagePaint);
        }

        public void SetSrcImage(Image image)
        {
            _pictureBox.Image = image;
            _pictureBox.Size = image.Size;
        }

        public void AddPath(GraphicsPath path, T tag)
        {
            _ListPath.Add(new Tuple<GraphicsPath, T>(path, tag));
            _pictureBox.Invalidate();
        }

        public void AddRect(int left, int top, int width, int height, T tag)
        {
            var rect = new Rectangle(left, top, width, height);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            AddPath(path, tag);
        }

        public void ClearPath()
        {
            _ListPath.Clear();
            _pictureBox.Invalidate();
        }

        private void OnPicImagePaint(object sender, PaintEventArgs e)
        {
            var pen = new Pen(Color.Red);
            _ListPath.ForEach(x => e.Graphics.DrawPath(pen, GetScaledPath(x.Item1)));
        }

        private GraphicsPath GetScaledPath(GraphicsPath path)
        {
            float matrixScaleX = (float)_pictureBox.Width / (float)_pictureBox.Image.Width;
            float matrixScaleY = (float)_pictureBox.Height / (float)_pictureBox.Image.Height;
            Matrix matrix = new Matrix();
            matrix.Scale(matrixScaleX, matrixScaleY);
            GraphicsPath scaledPath = (GraphicsPath)path.Clone();
            scaledPath.Transform(matrix);
            return scaledPath;
        }

        private bool HasClickInPath(MouseEventArgs e, Tuple<GraphicsPath, T> pathObject)
        {
            var scaledPath = GetScaledPath(pathObject.Item1);
            var bounds = scaledPath.GetBounds();
            return e.X >= bounds.Left && e.X <= bounds.Right &&
                e.Y >= bounds.Top && e.Y <= bounds.Bottom;
        }

        private void OnSizeChange(object sender, EventArgs e)
        {
            if (!_isLeftClickDown)
                UpdateImageSize(_pictureBox.Width, _pictureBox.Height);
        }

        private void OnPicMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isLeftClickDown = true;
                _mouseDownLocation = e.Location;
            }
        }

        private void OnPicMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _isLeftClickDown = false;
        }

        private void OnPicMouseClick(object sender, MouseEventArgs e)
        {
            if (MouseClick != null)
                MouseClick(sender, e);
            // Check if we click on any graphic element
            if (OnGraphicPathClick != null)
                foreach (var path in _ListPath)
                    if (HasClickInPath(e, path))
                        OnGraphicPathClick(path.Item2);
        }

        private void OnPicMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var newLeft = e.X + _pictureBox.Left - _mouseDownLocation.X;
                var newTop = e.Y + _pictureBox.Top - _mouseDownLocation.Y;

                var movementLeftRight = _mouseDownLocation.X - e.X;
                var movementTopBottom = _mouseDownLocation.Y - e.Y;

                if (IsNewPosValid(newLeft, _pictureBox.Left, _pictureBox.Right, _pictureBox.Width, _panel.Width, _pictureBox.Image.Width, movementLeftRight))
                    _pictureBox.Left = newLeft;
                if (IsNewPosValid(newTop, _pictureBox.Top, _pictureBox.Bottom, _pictureBox.Height, _panel.Height, _pictureBox.Image.Height, movementTopBottom))
                    _pictureBox.Top = newTop;
            }
        }
        
        private bool IsNewPosValid(
            int newPos, 
            int picBoxStartPos, 
            int picBoxEndPos, 
            int picBoxSize, 
            int panelSize, 
            int imgSize,
            int movement)
        {
            // TODO Issue to fix when zoomed
            if (picBoxSize > panelSize)
            {
                // Zoom in
                //Debug.WriteLine($"newPos {newPos}");
                //Debug.WriteLine($"panelSize {panelSize}");
                //Debug.WriteLine($"imgSize {imgSize}");
                //Debug.WriteLine($"picBoxSize {picBoxSize}");
                //Debug.WriteLine($"picBoxStartPos {picBoxStartPos}");
                //Debug.WriteLine($"picBoxEndPos {picBoxEndPos}");
                //Debug.WriteLine($"movement {movement}");
                if (movement >= 0 && picBoxEndPos < panelSize)
                    return false;
                if (newPos < panelSize - imgSize || newPos > 0)
                    return false;
            }
            else
            {
                // Zoom out
                if (newPos < 0)
                    return false;
                if (newPos > panelSize - picBoxSize)
                    return false;
                if (picBoxStartPos < 0 && newPos < picBoxStartPos)
                    return false;
                if (picBoxEndPos > panelSize && newPos + picBoxSize > picBoxEndPos)
                    return false;
                return true;
            }
            return true;
        }

        private void OnPicBoxMouseEnter(object sender, EventArgs e)
        {
            if (_pictureBox.Focused == false)
            {
                _pictureBox.Focus();
            }
        }

        private void OnPanelMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                ZoomIn();
            else
                ZoomOut();
        }

        private void ZoomIn()
        {
            if ((_pictureBox.Width < (CST_MINMAX * _panel.Width)) &&
                (_pictureBox.Height < (CST_MINMAX * _panel.Height)))
            {
                var width = Convert.ToInt32(_pictureBox.Width * CST_ZOOMFACTOR);
                var height = Convert.ToInt32(_pictureBox.Height * CST_ZOOMFACTOR);
                UpdateImageSize(width, height);
            }
        }

        private void ZoomOut()
        {
            if ((_pictureBox.Width > (_panel.Width / CST_MINMAX)) &&
                (_pictureBox.Height > (_panel.Height / CST_MINMAX)))
            {
                var width = Convert.ToInt32(_pictureBox.Width / CST_ZOOMFACTOR);
                var height = Convert.ToInt32(_pictureBox.Height / CST_ZOOMFACTOR);
                UpdateImageSize(width, height);
            }
        }

        private void UpdateImageSize(int width, int height)
        {
            _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _pictureBox.Width = width;
            _pictureBox.Height = height;
            if (ImageInWidth())
                CenterInWidth();
            if (ImageInHeight())
                CenterInHeight();
        }

        private void CenterInWidth()
        {
            _pictureBox.Left = (_panel.Width / 2) - (_pictureBox.Width / 2);
        }

        private void CenterInHeight()
        {
            _pictureBox.Top = (_panel.Height / 2) - (_pictureBox.Height / 2);
        }

        private bool ImageInWidth()
        {
            return _pictureBox.Width <= _panel.Width;
        }

        private bool ImageInHeight()
        {
            return _pictureBox.Height <= _panel.Height;
        }
    }
}
