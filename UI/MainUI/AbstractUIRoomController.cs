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

        protected Action<string> logWrite;

        protected PictureBoxZoomMoveController<CheckLogicZone> pictureBoxZoomMoveController;
        protected PictureBox pictureBoxItemList;

        public bool Init(
            Action<string> logWrite,
            PictureBoxZoomMoveController<CheckLogicZone> pictureBoxZoomMoveController,
            PictureBox pbItemList, 
            ListBox lbCheckList)
        {
            this.logWrite = logWrite;
            this.pictureBoxZoomMoveController = pictureBoxZoomMoveController;
            this.pictureBoxItemList = pbItemList;
            // Init picture box item list
            this.pictureBoxItemList.Paint += DrawAllItemList;
            this.pictureBoxItemList.Refresh();

            // Init ListBox
            lbCheckList.DrawItem += DrawCheckList;
            lbCheckList.MouseClick += OnCheckListItemClick;

            // Perform specific action
            return OnInit(lbCheckList);
        }

        protected abstract bool OnInit(ListBox lbCheckList);


        public abstract void DrawSquareCategory(int rectWidthAndHeight);
        protected abstract void DrawAllItemList(object sender, PaintEventArgs e);
        protected abstract void DrawCheckList(object sender, DrawItemEventArgs e);

        /// <summary>
        /// When we click on a check on the list box.
        /// We find the check list and Update the IsClaim bool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void OnCheckListItemClick(object sender, MouseEventArgs e);
    }
}
