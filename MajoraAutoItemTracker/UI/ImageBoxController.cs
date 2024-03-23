using Cyotek.Windows.Forms;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

        public Point GetRectCenter()
        {
            return new Point()
            {
                X = rect.X + (rect.Width / 2),
                Y = rect.Y + (rect.Height / 2)
            };
        }
    }

    public class ImageBoxController<T>
    {
        public event Action<List<T>>? OnGraphicPathClick;

        private readonly ImageBox imageBox;

        private Point _mouseDownPanelPosition;

        private readonly List<Tuple<GraphicsPathWithData, T>> _ListPath = new List<Tuple<GraphicsPathWithData, T>>();

        public ImageBoxController(ImageBox imageBox)
        {
            imageBox.AutoScroll = true;
            this.imageBox = imageBox;
            imageBox.MouseClick += new MouseEventHandler(OnPicMouseClick);
            imageBox.Paint += new PaintEventHandler(OnPicImagePaint);
        }

        #region Drawing management

        public void SetSrcImage(Image image)
        {
            imageBox.Image = image;
        }

        public void SetSrcBitmap(Bitmap bitmap)
        {
            imageBox.Image = bitmap;
        }

        public void AddPath(GraphicsPathWithData path, T tag)
        {
            _ListPath.Add(new Tuple<GraphicsPathWithData, T>(path, tag));
            imageBox.Refresh();
        }

        public void AddRect(int left, int top, int width, int height, T tag)
        {
            GraphicsPathWithData data = new GraphicsPathWithData(
                new Rectangle(left, top, width, height),
                Color.Red,
                "");
            AddPath(data, tag);
        }

        public GraphicsPathWithData? GetGraphicsPathWithData(T tag)
        {
            return _ListPath.Find((it) => it.Item2?.Equals(tag) ?? false)?.Item1;
        }

        public void RefreshDrawwing()
        {
            imageBox.Refresh();
        }

        public void ClearPath()
        {
            _ListPath.Clear();
            imageBox.Refresh();
        }

        private void OnPicImagePaint(object? sender, PaintEventArgs e)
        {
            _ListPath.ForEach(x =>
            {
                var graphicsPathWithData = x.Item1;
                var innerBrush = new SolidBrush(graphicsPathWithData.pathColor);
                var outerPen = new Pen(Color.Black, 4);
                var brushText = new SolidBrush(Color.Black);

                var scaledRect = imageBox.GetOffsetRectangle(graphicsPathWithData.rect);
                var scaledRoundedRect = RoundedRect(scaledRect, imageBox.GetScaledSize(10, 10).Width);
                e.Graphics.FillPath(innerBrush, scaledRoundedRect);
                e.Graphics.DrawPath(outerPen, scaledRoundedRect);
                e.Graphics.DrawString(graphicsPathWithData.pathInnerText, CreateFont(), brushText, scaledRect);
            });
        }

        private Font CreateFont()
        {
            var fontFamily = new FontFamily("Times New Roman");
            float emSize = imageBox.GetScaledSize(30, 30).Width;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            return new Font(fontFamily, emSize);
        }

        #endregion

        #region Click event

        private void OnPicMouseClick(object? sender, MouseEventArgs e)
        {
            var mouseDownPanelLocation = imageBox.PointToClient(Cursor.Position);
            var cursorMovement = new Point(_mouseDownPanelPosition.X - mouseDownPanelLocation.X, _mouseDownPanelPosition.Y - mouseDownPanelLocation.Y);

            // Control if we allow click after moving the drawing
            if (cursorMovement.X >= 1 || cursorMovement.Y >= 1)
                return;

            // Check if we click on any graphic element
            if (OnGraphicPathClick != null)
            {
                var itemFound = _ListPath
                        .FindAll((it) => HasClickInPath(e, it))
                        .Select((it) => it.Item2)
                        .ToList();
                if (itemFound.Count > 0)
                    OnGraphicPathClick(itemFound);
            }
        }

        #endregion

        #region Utils

        private bool HasClickInPath(MouseEventArgs e, Tuple<GraphicsPathWithData, T> pathObject)
        {
            var scaledRect = imageBox.GetOffsetRectangle(pathObject.Item1.rect);
            return e.X >= scaledRect.Left && e.X <= scaledRect.Right &&
                e.Y >= scaledRect.Top && e.Y <= scaledRect.Bottom;
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        #endregion
    }
}
