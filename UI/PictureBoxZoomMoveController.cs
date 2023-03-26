using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI
{
    public class PictureBoxZoomMoveController
    {
        #region CONSTANT
        private const double CST_ZOOMFACTOR = 1.25;
        private const int CST_MINMAX = 5;
        #endregion

        #region event
        public event MouseEventHandler MouseClick;
        #endregion

        private PictureBox _pictureBox; // PicBox
        private Panel _panel;
        private Point _mouseDownLocation; // MouseDownLocation

        public PictureBoxZoomMoveController(Panel panel)
        {
            _panel = panel;
            // Init
            _pictureBox = new PictureBox();
            // 
            // PicBox
            // 
            _pictureBox.Location = new Point(0, 0);
            //_pictureBox.Name = "PicBox";
            //_pictureBox.Size = new Size(150, 240);
            _pictureBox.TabIndex = 3;
            _pictureBox.TabStop = false;
            // 
            // OuterPanel
            // 
            //this.OuterPanel.BorderStyle = BorderStyle.FixedSingle;
            _panel.Controls.Add(this._pictureBox);
            //this.OuterPanel.Dock = DockStyle.Fill;
            //this.OuterPanel.Location = new Point(0, 0);
            //this.OuterPanel.Name = "OuterPanel";
            //this.OuterPanel.Size = new Size(210, 190);
            //this.OuterPanel.TabIndex = 4;
            // 
            // PictureBox
            // 
            //this.Controls.Add(this.OuterPanel);
            //this.Name = "PictureBox";
            //this.Size = new System.Drawing.Size(210, 190);
            //this.OuterPanel.ResumeLayout(false);
            //this.ResumeLayout(false);

            // InitCtrl
            _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _pictureBox.Location = new Point(0, 0);
            //OuterPanel.Dock = DockStyle.Fill;
            _panel.Cursor = Cursors.NoMove2D;
            _panel.AutoScroll = true;
            _panel.MouseEnter += new EventHandler(OnPicBoxMouseEnter);
            _panel.MouseWheel += new MouseEventHandler(OnPanelMouseWheel);
            _pictureBox.SizeChanged += new EventHandler(OnSizeChange);
            _pictureBox.MouseEnter += new EventHandler(OnPicBoxMouseEnter);
            _pictureBox.MouseDown += new MouseEventHandler(OnPicMouseDown);
            _pictureBox.MouseMove += new MouseEventHandler(OnPicMouseMove);
            _pictureBox.MouseClick += new MouseEventHandler(OnPicMouseClick);
        }

        public void SetSrcImage(Image image)
        {
            _pictureBox.Image = image;
            _pictureBox.Size = image.Size;
        }

        private void OnSizeChange(object sender, EventArgs e)
        {
            Debug.WriteLine("OnSizeChange");
            UpdateImageSize(_pictureBox.Width, _pictureBox.Height);
        }

        private void OnPicMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDownLocation = e.Location;
            }
        }

        private void OnPicMouseClick(object sender, MouseEventArgs e)
        {
            if (MouseClick != null)
                MouseClick(sender, e);
        }

        private void OnPicMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var newLeft = e.X + _pictureBox.Left - _mouseDownLocation.X;
                var newTop = e.Y + _pictureBox.Top - _mouseDownLocation.Y;
                // Debug.WriteLine($"newLeft:{newLeft}, newTop:{newTop}");
                if (newLeft > _pictureBox.Left && newLeft < _panel.Width - _pictureBox.Width) // Fix me, not working on zoom
                    _pictureBox.Left = newLeft;
                else if (newLeft < _pictureBox.Left && newLeft >= 0)
                    _pictureBox.Left = newLeft;

                if (newTop > _pictureBox.Top && newTop < _panel.Height - _pictureBox.Height) // Fix me, not working on zoom
                    _pictureBox.Top = newTop;
                else if (newTop < _pictureBox.Top && newTop >= 0)
                    _pictureBox.Top = newTop;
            }
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
