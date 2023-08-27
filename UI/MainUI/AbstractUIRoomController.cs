using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Item;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.MainUI
{
    abstract class AbstractUIRoomController<CheckLogic, CheckLogicZone> 
        where CheckLogic : AbstractCheckLogic<CheckLogicZone>
    {
        protected const int ITEM_LIST_SIZE_IN_FILE = 42; // in px
        protected const int ITEM_LIST_SIZE = 42; // in px

        protected Point maxPropertyNamePosition = new Point();

        protected Bitmap itemSpriteMono;
        protected Bitmap itemSpriteColor;

        protected List<ItemLogic> itemLogics;
        protected List<CheckLogic> checkLogics;

        protected Action<string> logWrite;

        protected PictureBoxZoomMoveController<CheckLogicZone> pictureBoxZoomMoveController;
        protected PictureBox pictureBoxItemList;

        public void Init(
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
        }

        public void RefreshCheckListForCategory(ListBox listbox, CheckLogicZone checkLogicZone)
        {
            listbox.BeginUpdate();
            listbox.Items.Clear();
            listbox.Items.AddRange(checkLogics.FindAll((it) => it.Zone.Equals(checkLogicZone)).ToArray());
            listbox.EndUpdate();
        }

        protected List<CheckLogic> GetListOfCheckLogicForZone(CheckLogicZone zone)
        {
            return checkLogics.FindAll((it) => it.Zone.Equals(zone)).ToList();
        }

        public void RefreshRegionInDrawingFollowingCheck(CheckLogicZone zone)
        {
            bool isAllClaim = true;
            bool isAllCheckAvailable = true;
            bool isAtLeastOneCheckAvailable = false;
            int availableCheck = 0;
            foreach (var checkInZone in checkLogics.FindAll((it) => it.Zone.Equals(zone)))
            {
                if (!checkInZone.IsClaim)
                    isAllClaim = false;
                if (checkInZone.IsAvailable && !checkInZone.IsClaim)
                    availableCheck++;
                if (!checkInZone.IsAvailable)
                    isAllCheckAvailable = false;
                else
                    isAtLeastOneCheckAvailable = true;
            }
            Color color;
            if (isAllClaim)
                color = Color.Gray;
            else if (isAllCheckAvailable)
                color = Color.Green;
            else if (isAtLeastOneCheckAvailable)
                color = Color.Yellow;
            else
                color = Color.Red;
            var zoneGraphucsPathWithData = pictureBoxZoomMoveController.GetGraphicsPathWithData(zone);
            zoneGraphucsPathWithData.pathColor = color;
            zoneGraphucsPathWithData.pathInnerText = availableCheck.ToString();
        }
        public abstract void DrawSquareCategory(int rectWidthAndHeight);

        protected void DrawAllItemList(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            foreach (var itemLogic in itemLogics)
            {
                if (itemLogic.propertyName == null || itemLogic.propertyName == "")
                    continue;
                var posX = itemLogic.variants[itemLogic.CurrentVariant].positionX * ITEM_LIST_SIZE_IN_FILE;
                var posY = itemLogic.variants[itemLogic.CurrentVariant].positionY * ITEM_LIST_SIZE_IN_FILE;
                Image imageToDraw;
                if (itemLogic.hasItem)
                    imageToDraw = itemSpriteColor.Clone(new Rectangle(posX, posY, ITEM_LIST_SIZE_IN_FILE, ITEM_LIST_SIZE_IN_FILE), itemSpriteColor.PixelFormat);
                else
                    imageToDraw = itemSpriteMono.Clone(new Rectangle(posX, posY, ITEM_LIST_SIZE_IN_FILE, ITEM_LIST_SIZE_IN_FILE), itemSpriteMono.PixelFormat);
                var point = GetPositionInDrawingOfItemLogicPropertyName(itemLogic.propertyName);

                var scaledSizeX = (sender as PictureBox).Width / (maxPropertyNamePosition.X + 1);
                var scaledSizeY = (sender as PictureBox).Height / (maxPropertyNamePosition.Y + 1);

                var scaledSizeXY = Math.Min(scaledSizeX, scaledSizeY);

                var scaledX = (point.X * scaledSizeXY);
                var scaledY = (point.Y * scaledSizeXY);

                g.DrawImage(imageToDraw, new Rectangle(scaledX, scaledY, scaledSizeXY, scaledSizeXY));
            }
        }

        protected void DrawCheckList(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            var listBox = (ListBox)sender;
            var checkLogic = (AbstractCheckLogic<CheckLogicZone>)listBox.Items[e.Index];
            Brush brush;
            if (checkLogic.IsClaim)
                brush = Brushes.Gray;
            else if (checkLogic.IsAvailable)
                brush = Brushes.Green;
            else
                brush = Brushes.Red;
            e.Graphics.DrawString(checkLogic.Id, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }


        /// <summary>
        /// When we click on a check on the list box.
        /// We find the check list and Update the IsClaim bool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnCheckListItemClick(object sender, MouseEventArgs e)
        {
            var listBox = (ListBox)sender;
            var checkList = (AbstractCheckLogic<CheckLogicZone>)listBox.SelectedItem;
            checkList.IsClaim = !checkList.IsClaim;
            RefreshRegionInDrawingFollowingCheck(checkList.Zone);
            listBox.Refresh();
            pictureBoxZoomMoveController.RefreshDrawwing();
        }

        protected abstract Point GetPositionInDrawingOfItemLogicPropertyName(string propertyName);

        public List<CheckSaveFormat> SaveListCheck()
        {
            return checkLogics.Select((it) => new CheckSaveFormat()
            {
                Id = it.Id,
                IsClaim = it.IsClaim
            }).ToList();
        }

        public void LoadFromSave(List<CheckSaveFormat> listCheckSaveFormat)
        {
            foreach (var checkLogic in checkLogics)
            {
                var savedCheckToApply = listCheckSaveFormat.Find((it) => it.Id == checkLogic.Id);
                if (savedCheckToApply != null)
                {
                    checkLogic.IsClaim = savedCheckToApply.IsClaim;
                }
            }
        }
    }
}
