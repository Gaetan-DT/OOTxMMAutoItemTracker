using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI
{
    public class GraphicsPathWithData
    {
        public readonly Rectangle rect;
        public Color pathColor;
        public string pathInnerText;

        public GraphicsPathWithData(Rectangle rect, Color pathColor, string pathInnerText)
        {
            this.rect = rect;
            this.pathColor = pathColor;
            this.pathInnerText = pathInnerText;
        }

        private Point GetRectCenter()
        {
            return new Point()
            {
                X = rect.X + (rect.Width/2),
                Y = rect.Y + (rect.Height/2)
            };
        }

        public GraphicsPath CreateGraphicPath()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(this.rect);
            return path;
        }

        public GraphicsPath CreateStringPath()
        {
            GraphicsPath path = new GraphicsPath();
            var fontFamily = new FontFamily("Times New Roman");
            float emSize = 30;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            path.AddString(pathInnerText, fontFamily, ((int)FontStyle.Bold), emSize, GetRectCenter(), sf);
            return path;
        }
    }

    public class PictureBoxZoomMoveController<T>
    {
        #region CONSTANT
        private const double CST_ZOOMFACTOR = 1.25;
        private const int CST_MINMAX = 5;
        #endregion

        #region event
        public event Action<T> OnGraphicPathClick;
        #endregion

        private readonly PictureBox _pictureBox = new PictureBox
        {
            Location = new Point(0, 0),
            TabIndex = 3,
            TabStop = false,
            SizeMode = PictureBoxSizeMode.StretchImage,
        };

        private readonly Panel _panel;
        private Point _mouseDownImagePosition;
        private Point _mouseDownPanelPosition;

        private bool _isLeftClickDown = false;

        private readonly List<Tuple<GraphicsPathWithData, T>> _ListPath = new List<Tuple<GraphicsPathWithData, T>>();

        public PictureBoxZoomMoveController(Panel panel)
        {
            _panel = panel;
            // Init panel
            _panel.Controls.Add(this._pictureBox);
            _panel.Cursor = Cursors.NoMove2D;
            _panel.MouseEnter += new EventHandler(OnPicBoxMouseEnter);
            _panel.MouseWheel += new MouseEventHandler(OnPanelOrImageMouseWheel);
            _panel.SizeChanged += new EventHandler(OnSizeChange);
            _panel.AutoScroll = false;
            // Init image event
            _pictureBox.MouseEnter += new EventHandler(OnPicBoxMouseEnter);
            _pictureBox.MouseDown += new MouseEventHandler(OnPicMouseDown);
            _pictureBox.MouseMove += new MouseEventHandler(OnPicMouseMove);
            _pictureBox.MouseClick += new MouseEventHandler(OnPicMouseClick);
            _pictureBox.Paint += new PaintEventHandler(OnPicImagePaint);
            _pictureBox.MouseWheel += new MouseEventHandler(OnPanelOrImageMouseWheel);
        }

        #region Drawing management

        public void SetSrcImage(Image image)
        {
            _pictureBox.Image = image;
            _pictureBox.Size = image.Size;
        }

        public void AddPath(GraphicsPathWithData path, T tag)
        {
            _ListPath.Add(new Tuple<GraphicsPathWithData, T>(path, tag));
            _pictureBox.Invalidate();
        }

        public void AddRect(int left, int top, int width, int height, T tag)
        {
            GraphicsPathWithData data = new GraphicsPathWithData(
                new Rectangle(left, top, width, height),
                Color.Red,
                "");
            AddPath(data, tag);
        }

        public GraphicsPathWithData GetGraphicsPathWithData(T tag)
        {
            return _ListPath.Find((it) => it.Item2.Equals(tag)).Item1;
        }

        public void RefreshDrawwing()
        {
            _pictureBox.Refresh();
        }

        public void ClearPath()
        {
            _ListPath.Clear();
            _pictureBox.Invalidate();
        }

        private void OnPicImagePaint(object sender, PaintEventArgs e)
        {
            _ListPath.ForEach(x =>
            {
                var graphicsPathWithData = x.Item1;
                var Brush = new SolidBrush(graphicsPathWithData.pathColor);
                e.Graphics.FillPath(Brush, GetScaledPath(graphicsPathWithData.CreateGraphicPath()));
                e.Graphics.FillPath(new SolidBrush(Color.Black), GetScaledPath(graphicsPathWithData.CreateStringPath()));
            });
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

        #endregion

        #region Click event

        private void OnSizeChange(object sender, EventArgs e)
        {
            if (!_isLeftClickDown)
                UpdateImageSizeAndPos(_pictureBox.Width, _pictureBox.Height);
        }

        private void OnPicMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isLeftClickDown = true;
                _mouseDownImagePosition = e.Location;
                _mouseDownPanelPosition = _panel.PointToClient(Cursor.Position);
            }
        }

        private void OnPicMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _isLeftClickDown = false;
        }

        private void OnPicMouseClick(object sender, MouseEventArgs e)
        {
            var mouseDownPanelLocation = _panel.PointToClient(Cursor.Position);
            var cursorMovement = new Point(_mouseDownPanelPosition.X - mouseDownPanelLocation.X, _mouseDownPanelPosition.Y - mouseDownPanelLocation.Y);

            // Control if we allow click after moving the drawing
            if (cursorMovement.X >= 1 || cursorMovement.Y >= 1)
                return;

            // Check if we click on any graphic element
            if (OnGraphicPathClick != null)
                foreach (var path in _ListPath)
                    if (HasClickInPath(e, path))
                        OnGraphicPathClick(path.Item2);
        }

        private void OnPicMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            var newLeft = e.X + _pictureBox.Left - _mouseDownImagePosition.X;
            var newTop = e.Y + _pictureBox.Top - _mouseDownImagePosition.Y;

            var movementLeftRight = _mouseDownImagePosition.X - e.X;
            var movementTopBottom = _mouseDownImagePosition.Y - e.Y;

            if (IsNewPosValid(newLeft, _pictureBox.Left, _pictureBox.Right, _pictureBox.Width, _panel.Width, movementLeftRight))
                _pictureBox.Left = newLeft;
            if (IsNewPosValid(newTop, _pictureBox.Top, _pictureBox.Bottom, _pictureBox.Height, _panel.Height, movementTopBottom))
                _pictureBox.Top = newTop;
        }

        private void OnPicBoxMouseEnter(object sender, EventArgs e)
        {
            if (_pictureBox.Focused == false)
                _pictureBox.Focus();
        }

        #endregion

        #region Zoom managment

        private void OnPanelOrImageMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                ZoomIn();
            else
                ZoomOut();
            ((HandledMouseEventArgs)e).Handled = true; // To prevent event scroll
        }

        private void ZoomIn()
        {
            if ((_pictureBox.Width < (CST_MINMAX * _panel.Width)) &&
                (_pictureBox.Height < (CST_MINMAX * _panel.Height)))
            {
                var width = Convert.ToInt32(_pictureBox.Width * CST_ZOOMFACTOR);
                var height = Convert.ToInt32(_pictureBox.Height * CST_ZOOMFACTOR);
                UpdateImageSizeAndPos(width, height);
            }
        }

        private void ZoomOut()
        {
            if ((_pictureBox.Width > (_panel.Width / CST_MINMAX)) &&
                (_pictureBox.Height > (_panel.Height / CST_MINMAX)))
            {
                var width = Convert.ToInt32(_pictureBox.Width / CST_ZOOMFACTOR);
                var height = Convert.ToInt32(_pictureBox.Height / CST_ZOOMFACTOR);
                UpdateImageSizeAndPos(width, height);
            }
        }

        private void UpdateImageSizeAndPos(int width, int height)
        {
            _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _pictureBox.Width = width;
            _pictureBox.Height = height;
            if (_pictureBox.Width <= _panel.Width || _pictureBox.Left < 0)
                _pictureBox.Left = (_panel.Width / 2) - (_pictureBox.Width / 2); // Center in width
            if (_pictureBox.Height <= _panel.Height || _pictureBox.Top < 0)
                _pictureBox.Top = (_panel.Height / 2) - (_pictureBox.Height / 2); // Center in height
        }

        #endregion

        #region Utils

        private bool HasClickInPath(MouseEventArgs e, Tuple<GraphicsPathWithData, T> pathObject)
        {
            var scaledPath = GetScaledPath(pathObject.Item1.CreateGraphicPath());
            var bounds = scaledPath.GetBounds();
            return e.X >= bounds.Left && e.X <= bounds.Right &&
                e.Y >= bounds.Top && e.Y <= bounds.Bottom;
        }

        private bool IsNewPosValid(int newPos, int picBoxStartPos, int picBoxEndPos, int picBoxSize, int panelSize, int movement)
        {
            if (picBoxSize > panelSize)
            {
                // Image larger than panel
                if (movement >= 0 && picBoxEndPos < panelSize)
                    return false;
                if (/*newPos < panelSize - imgSize ||*/ newPos > 0)
                    return false;
            }
            else
            {
                // Image lower than panel
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

        #endregion
    }
}
