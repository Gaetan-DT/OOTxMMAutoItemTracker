using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.MainUI
{
    abstract class AbstractRoomController
    {
        public abstract bool Init(PictureBox pbItemList, ListBox lbCheckList, out string errorMessage);
        public abstract void DrawSquareCategory(PictureBoxZoomMoveController<MajoraMaskCheckLogicZone> pictureBox, int rectWidthAndHeight);
        public abstract void DrawAllItemList(object sender, PaintEventArgs e);
        public abstract void DrawCheckList(object sender, DrawItemEventArgs e)
    }
}
