using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.MainUI
{
    abstract class AbstractUIRoomController<CheckLogicZone>
    {
        protected const int ITEM_LIST_SIZE_IN_FILE = 42; // in px
        protected const int ITEM_LIST_SIZE = 42; // in px

        protected Bitmap itemSpriteMono;
        protected Bitmap itemSpriteColor;

        public PictureBox pictureBoxItemList;
        protected PictureBoxZoomMoveController<CheckLogicZone> pictureBoxZoomMoveController;

        public abstract bool Init(
            PictureBoxZoomMoveController<CheckLogicZone> pictureBoxZoomMoveController,
            PictureBox pbItemList, 
            ListBox lbCheckList, 
            out string errorMessage);


        public abstract void DrawSquareCategory(int rectWidthAndHeight);
        public abstract void DrawAllItemList(object sender, PaintEventArgs e);
        public abstract void DrawCheckList(object sender, DrawItemEventArgs e);

        public abstract void OnCheckListItemClick(object sender, MouseEventArgs e);
    }
}
