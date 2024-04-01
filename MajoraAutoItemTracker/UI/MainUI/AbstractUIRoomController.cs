using MajoraAutoItemTracker.Core.Extensions;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Item;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.MainUI
{
    abstract class AbstractUIRoomController<CheckLogic, CheckLogicZone> 
        where CheckLogic : AbstractCheckLogic<CheckLogicZone>
    {
        protected const int ITEM_LIST_SIZE_IN_FILE = 42; // in px
        protected const int ITEM_LIST_SIZE = 42; // in px

        protected Point maxPropertyNamePosition = new Point();

        protected Action<string>? logWrite;

        protected ImageBoxController<CheckLogicZone>? pictureBoxZoomMoveController;
        protected PictureBox? pictureBoxItemList;

        protected abstract Bitmap GetItemSpriteMono();
        protected abstract Bitmap GetItemSpriteColor();
        protected abstract List<ItemLogic> GetItemLogics();
        protected abstract List<CheckLogic> GetCheckLogics();

        public void Init(
            Action<string> logWrite,
            ImageBoxController<CheckLogicZone> pictureBoxZoomMoveController,
            PictureBox pbItemList, 
            ListBox lbCheckList,
            ContextMenuStrip cmsCheckList)
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
            lbCheckList.MouseDown += ListBoxMouseDown;
            lbCheckList.ContextMenuStrip = cmsCheckList;
        }

        public void RefreshCheckListForCategory(
            GroupBox groupBox,
            ListBox listbox, 
            List<CheckLogicZone> checkLogicZoneList)
        {
            var listCheckForZone = GetCheckLogics().FindAll((it) => it.Zone != null && checkLogicZoneList.Contains(it.Zone)).ToArray();

            var zoneStr = checkLogicZoneList.FirstOrDefault()?.ToString();
            groupBox.Text = $"Zone: {zoneStr}";

            listbox.BeginUpdate();
            listbox.Items.Clear();
            listbox.Items.AddRange(listCheckForZone);
            listbox.EndUpdate();
        }

        protected List<CheckLogic> GetListOfCheckLogicForZone(CheckLogicZone zone)
        {
            var result = new List<CheckLogic>();
            foreach (var checkLogic in GetCheckLogics())
                if (checkLogic.Zone != null && checkLogic.Zone.Equals(zone))
                    result.Add(checkLogic);
            return result;
        }

        protected List<CheckLogicZone> GetListOfZone()
        {
            var result = new List<CheckLogicZone>();
            foreach (var checkLogic in GetCheckLogics())
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
            if (pictureBoxZoomMoveController == null)
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
            if (zoneGraphucsPathWithData != null)
            {
                zoneGraphucsPathWithData.pathColor = color;
                zoneGraphucsPathWithData.pathInnerText = availableCheck.ToString();
            }
        }
        public abstract void DrawSquareCategory(int rectWidthAndHeight);

        protected void DrawAllItemList(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            foreach (var itemLogic in GetItemLogics())
            {
                if (itemLogic.propertyName == null || itemLogic.propertyName == "")
                    continue;

                // Get scalled point
                var point = GetPositionInDrawingOfItemLogicPropertyName(itemLogic.propertyName);

                var scaledSizeX = (sender as PictureBox)!.Width / (maxPropertyNamePosition.X + 1);
                var scaledSizeY = (sender as PictureBox)!.Height / (maxPropertyNamePosition.Y + 1);

                var scaledSizeXY = Math.Min(scaledSizeX, scaledSizeY);
                var scaledX = (point.X * scaledSizeXY);
                var scaledY = (point.Y * scaledSizeXY);

                var imageRectangle = new Rectangle(scaledX, scaledY, scaledSizeXY, scaledSizeXY);


                // Draw Item and Text
                DrawItemImageAtPos(g, itemLogic, imageRectangle);
                DrawItemTextAtPos(g, itemLogic, imageRectangle);
            }
        }

        private void DrawItemImageAtPos(Graphics g, ItemLogic itemLogic, Rectangle pos)
        {
            var blurImage = itemLogic.ItemCount > 0;
            var posX = itemLogic.variants[itemLogic.CurrentVariant].positionX * ITEM_LIST_SIZE_IN_FILE;
            var posY = itemLogic.variants[itemLogic.CurrentVariant].positionY * ITEM_LIST_SIZE_IN_FILE;

            Bitmap itemSprite = itemLogic.hasItem ? GetItemSpriteColor() : GetItemSpriteMono();
            Image imageToDraw = itemSprite.Clone(
                new Rectangle(posX, posY, ITEM_LIST_SIZE_IN_FILE, ITEM_LIST_SIZE_IN_FILE),
                itemSprite.PixelFormat);

            if (blurImage)
            {
                imageToDraw = new Bitmap(imageToDraw).Blur(2);
            }

            g.DrawImage(imageToDraw, pos);
        }

        private void DrawItemTextAtPos(Graphics g, ItemLogic itemLogic, Rectangle pos)
        {
            if (itemLogic.ItemCount <= 0)
                return;
            var brushText = new SolidBrush(Color.White);
            var brushOutlineText = new Pen(Color.Black);
            var fontSize = 18;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            GraphicsPath stringPath = new GraphicsPath();
            stringPath.AddString(
                itemLogic.ItemCount.ToString(),
                new FontFamily("Georgia"),
                (int)FontStyle.Bold,
                g.DpiX * fontSize / 72,
                new Rectangle(
                    pos.X,
                    pos.Y + (pos.Height / 2),
                    pos.Width,
                    pos.Height / 2),
                stringFormat);

            g.FillPath(brushText, stringPath);
            g.DrawPath(brushOutlineText, stringPath);
        }

        protected void DrawCheckList(object? sender, DrawItemEventArgs e)
        {
            if (sender == null)
                return;
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
            e.Graphics.DrawString(
                checkLogic.Id, 
                e.Font ?? SystemFonts.DefaultFont, 
                brush, 
                e.Bounds, 
                StringFormat.GenericDefault);
        }


        /// <summary>
        /// When we click on a check on the list box.
        /// We find the check list and Update the IsClaim bool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnCheckListItemClick(object? sender, MouseEventArgs e)
        {
            if (sender == null)
                return;
            if (pictureBoxZoomMoveController == null)
            {
                Console.WriteLine("ERROR: OnCheckListItemClick: Not initialized");
                return;
            }
            var listBox = (ListBox)sender;
            var checkList = (AbstractCheckLogic<CheckLogicZone>?)listBox.SelectedItem;
            if (checkList != null)
            {
                checkList.IsClaim = !checkList.IsClaim;
                if (checkList.Zone != null)
                    RefreshRegionInDrawingFollowingCheck(checkList.Zone);
                listBox.Refresh();
                pictureBoxZoomMoveController.RefreshDrawwing();
            }
        }

        private void ListBoxMouseDown(object? sender, MouseEventArgs e)
        {
            if (sender == null)
                return;
            if (e.Button == MouseButtons.Right)
            {
                var listbox = ((ListBox)sender);
                var index = listbox.IndexFromPoint(e.Location);
                if (index >= 0)
                {
                    var checkLogic = (CheckLogic)listbox.Items[index];
                    if (listbox.ContextMenuStrip != null)
                    {
                        PrepareMenuItemForCheck(listbox.ContextMenuStrip, checkLogic);
                        listbox.ContextMenuStrip.Show();
                    }
                }
            }
        }

        protected abstract Point GetPositionInDrawingOfItemLogicPropertyName(string propertyName);

        public void ResetCheckClaim()
        {
            foreach (var checkLogic in GetCheckLogics())
                checkLogic.IsClaim = false;
            RefreshRegionInDrawingFollowingCheck();
        }

        public List<CheckSaveFormat> SaveListCheck()
        {
            return GetCheckLogics().Select((it) => new CheckSaveFormat()
            {
                Id = it.Id,
                IsClaim = it.IsClaim
            }).ToList();
        }

        public void LoadFromSave(List<CheckSaveFormat> listCheckSaveFormat)
        {
            foreach (var checkLogic in GetCheckLogics())
            {
                var savedCheckToApply = listCheckSaveFormat.Find((it) => it.Id == checkLogic.Id);
                if (savedCheckToApply != null)
                {
                    checkLogic.IsClaim = savedCheckToApply.IsClaim;
                }
            }
            RefreshRegionInDrawingFollowingCheck();
        }

        public void PrepareMenuItemForCheck(ContextMenuStrip cms, CheckLogic checkLogic)
        {
            cms.Items.Clear();
            cms.Items.Add($"{checkLogic.Id}").Enabled = false;
            cms.Items.Add("See logic (WIP)").Enabled = false;
        }
    }
}
