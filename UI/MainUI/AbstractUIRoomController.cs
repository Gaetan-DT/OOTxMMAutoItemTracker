using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Item;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

#nullable enable

namespace MajoraAutoItemTracker.UI.MainUI
{
    abstract class AbstractUIRoomController<CheckLogic, CheckLogicZone> 
        where CheckLogic : AbstractCheckLogic<CheckLogicZone>
    {
        protected const int ITEM_LIST_SIZE_IN_FILE = 42; // in px
        protected const int ITEM_LIST_SIZE = 42; // in px

        protected Point maxPropertyNamePosition = new Point();

        protected Bitmap? itemSpriteMono;
        protected Bitmap? itemSpriteColor;

        protected List<ItemLogic>? itemLogics;
        protected List<CheckLogic>? checkLogics;

        protected Action<string>? logWrite;

        protected ImageBoxController<CheckLogicZone>? pictureBoxZoomMoveController;
        protected PictureBox? pictureBoxItemList;

        public void Init(
            Action<string> logWrite,
            ImageBoxController<CheckLogicZone> pictureBoxZoomMoveController,
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

        public void RefreshCheckListForCategory(
            ListBox listbox, 
            CheckLogicZone checkLogicZone)
        {
            if (checkLogics == null)
            {
                Console.WriteLine("ERROR: RefreshCheckListForCategory: Not initialized");
                return;
            }
            listbox.BeginUpdate();
            listbox.Items.Clear();
            listbox.Items.AddRange(checkLogics.FindAll((it) => it.Zone?.Equals(checkLogicZone) ?? false).ToArray());
            listbox.EndUpdate();
        }

        protected List<CheckLogic> GetListOfCheckLogicForZone(CheckLogicZone zone)
        {
            var result = new List<CheckLogic>();
            if (checkLogics == null)
            {
                Console.WriteLine("ERROR: GetListOfCheckLogicForZone: Not initialized");
                return result;
            }
            foreach (var checkLogic in checkLogics)
                if (checkLogic.Zone != null && checkLogic.Zone.Equals(zone))
                    result.Add(checkLogic);
            return result;
        }

        protected List<CheckLogicZone> GetListOfZone()
        {
            var result = new List<CheckLogicZone>();
            if (checkLogics == null)
            {
                Console.WriteLine("ERROR: GetListOfZone: Not initialized");
                return result;
            }
            foreach (var checkLogic in checkLogics)
                if (checkLogic.Zone != null)
                    result.Add(checkLogic.Zone);
            return result.Distinct().ToList();
        }

        public void RefreshRegionInDrawingFollowingCheck()
        {
            foreach (var zone in GetListOfZone())
                RefreshRegionInDrawingFollowingCheck(zone);
        }

        public void RefreshRegionInDrawingFollowingCheck(CheckLogicZone zone)
        {
            if (checkLogics == null || pictureBoxZoomMoveController == null)
            {
                Console.WriteLine("ERROR: RefreshRegionInDrawingFollowingCheck: Not initialized");
                return;
            }
            bool isAllClaim = true;
            bool isAllCheckAvailable = true;
            bool isAtLeastOneCheckAvailable = false;
            int availableCheck = 0;
            foreach (var checkInZone in this.GetListOfCheckLogicForZone(zone))
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
            if (itemLogics == null || itemSpriteColor == null || itemSpriteMono == null)
            {
                Console.WriteLine("ERROR: DrawAllItemList: Not initialized");
                return;
            }
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

                var scaledSizeX = (sender as PictureBox)!.Width / (maxPropertyNamePosition.X + 1);
                var scaledSizeY = (sender as PictureBox)!.Height / (maxPropertyNamePosition.Y + 1);

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
            if (pictureBoxZoomMoveController == null)
            {
                Console.WriteLine("ERROR: OnCheckListItemClick: Not initialized");
                return;
            }
            var listBox = (ListBox)sender;
            var checkList = (AbstractCheckLogic<CheckLogicZone>)listBox.SelectedItem;
            checkList.IsClaim = !checkList.IsClaim;
            if (checkList.Zone != null)
                RefreshRegionInDrawingFollowingCheck(checkList.Zone);
            listBox.Refresh();
            pictureBoxZoomMoveController.RefreshDrawwing();
        }

        protected abstract Point GetPositionInDrawingOfItemLogicPropertyName(string propertyName);

        public void ResetCheckClaim()
        {
            if (checkLogics == null)
            {
                Console.WriteLine("ERROR: ResetCheckClaim: Not initialized");
                return;
            }
            foreach (var checkLogic in checkLogics)
                checkLogic.IsClaim = false;
            RefreshRegionInDrawingFollowingCheck();
        }

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
            if (checkLogics == null)
            {
                Console.WriteLine("ERROR: LoadFromSave: Not initialized");
                return;
            }
            foreach (var checkLogic in checkLogics)
            {
                var savedCheckToApply = listCheckSaveFormat.Find((it) => it.Id == checkLogic.Id);
                if (savedCheckToApply != null)
                {
                    checkLogic.IsClaim = savedCheckToApply.IsClaim;
                }
            }
            RefreshRegionInDrawingFollowingCheck();
        }
    }
}
