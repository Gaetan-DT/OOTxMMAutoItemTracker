using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Item;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class MajoraMaskController
    {
        const string ITEM_SPRITE_MONO_PATH = @"\Resource\Itemicons\mm_items_mono.png";
        const string ITEM_SPRITE_COLOR_PATH = @"\Resource\Itemicons\mm_items.png";
        const string ITEM_LOGIC_FILE_NAME = @"\Resource\Mappings\" + ItemLogicMethod.CST_DEFAULT_FILE_NAME;
        const string ITEM_CHECK_LOGIC_CATEGORY_PATH = @"\Resource\CheckLogic\" + CheckLogicCategory.CST_DEFAULT_FILE_NAME;

        const int ITEM_LIST_SIZE_IN_FILE = 42; // in px
        const int ITEM_LIST_SIZE= 42; // in px

        private Bitmap itemSpriteMono;
        private Bitmap itemSpriteColor;

        public List<ItemLogic> itemLogics;
        public List<CheckLogicCategory> checkLogicCategories;
        public List<CheckLogic> checkLogics;

        public PictureBox pictureBoxItemList;

        public bool Init(PictureBox pbItemList, ListBox lbCheckList, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                // Init picture box item list
                this.pictureBoxItemList = pbItemList;
                this.pictureBoxItemList.Paint += DrawAllItemList;
                this.pictureBoxItemList.Refresh();
                // Init ListBox
                lbCheckList.DrawItem += DrawCheckList;
                lbCheckList.MouseClick += OnCheckListItemClick;
                // Init image
                itemSpriteMono = new Bitmap(Image.FromFile(Application.StartupPath + ITEM_SPRITE_MONO_PATH));
                itemSpriteColor = new Bitmap(Image.FromFile(Application.StartupPath + ITEM_SPRITE_COLOR_PATH));
                // Init json
                itemLogics = ItemLogicMethod.Deserialize(Application.StartupPath + ITEM_LOGIC_FILE_NAME);
                checkLogicCategories = CheckLogicCategory.LoadFromFile(Application.StartupPath + ITEM_CHECK_LOGIC_CATEGORY_PATH);
                checkLogics = CheckLogic.FromHeader(checkLogicCategories);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                errorMessage = e.Message;
                return false;
            }
        }

        // Refrehs all check available for a zone
        // Use the list of all check logic and filter it by zone
        public void RefreshCheckListForCategory(ListBox listbox, MajoraMaskCheckLogicZone checkLogicZone)
        {
            listbox.Items.Clear();
            foreach (var checkLogic in checkLogics) // recuperer tout les checks dans la catégorie
                if (checkLogic.Zone == checkLogicZone)
                    listbox.Items.Add(checkLogic);
        }

        public void DrawSquareCategory(PictureBoxZoomMoveController<MajoraMaskCheckLogicZone> pictureBox, int rectWidthAndHeight)
        {
            foreach (var checkLogicCategory in checkLogicCategories)
            {
                pictureBox.AddRect(
                    checkLogicCategory.SquarePositionX - rectWidthAndHeight / 2,
                    checkLogicCategory.SquarePositionY - rectWidthAndHeight / 2,
                    rectWidthAndHeight, rectWidthAndHeight,
                    MajoraMaskCheckLogicZoneMethod.FromString(checkLogicCategory.Name)
                );
            }
        }

        // Call when change is trigger from memory
        public void OnItemLogicChange(Tuple<ItemLogicPopertyName, object> itemLogicProperty)
        {
            var strItemLogicPropertyName = ItemLogicPopertyNameMethod.ToString(itemLogicProperty.Item1);
            foreach (var itemLogic in itemLogics)
            {
                if (strItemLogicPropertyName == itemLogic.propertyName)
                {
                    if (itemLogicProperty.Item2 is bool)
                    {
                        itemLogic.hasItem = (bool)itemLogicProperty.Item2;
                        itemLogic.CurrentVariant = 0;
                    }
                    // TODO: gerer les différent cas pour les enum
                    pictureBoxItemList.Refresh();
                    // TODO: appeler la logicresolver pour mettre à jour les check avec le nouveau set d'items
                    break;
                }
            }
            /* recuperer l'item logic grace au param itemlogicproperty.item1 de l'event
            * avec l'item logic maj itemlogic "hasItem" grace au param foo de l'event 
            * si le foo.Item2 est autre qu'un bool on va maj l'itemlogic.currentvariant
            rappeler drawitem
            * appeler la logicresolver pour mettre à jour les check avec le nouveau set d'items
            */
        }

        public void DrawAllItemList(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
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
                var point = GetPositionInDrawingOfItemLogicPropertyName(itemLogic);
                g.DrawImage(imageToDraw, new Rectangle(point.X * ITEM_LIST_SIZE, point.Y * ITEM_LIST_SIZE, ITEM_LIST_SIZE, ITEM_LIST_SIZE));
            }
        }

        public void DrawCheckList(object sender, DrawItemEventArgs e)
        {
            var listBox = (ListBox)sender;
            var checkLogic = (CheckLogic)listBox.Items[e.Index];
            Brush brush;
            if (checkLogic.IsClaim)
                brush = Brushes.Gray;
            else if (checkLogic.IsAvailable)
                brush = Brushes.Green;
            else
                brush = Brushes.Red;
            e.Graphics.DrawString(checkLogic.Id, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }

        public void OnCheckListItemClick(object sender, MouseEventArgs e)
        {
            var listBox = (ListBox)sender;
            var checkList = (CheckLogic)listBox.SelectedItem;
            checkList.IsClaim = !checkList.IsClaim;
            listBox.Refresh();
        }

        private Point GetPositionInDrawingOfItemLogicPropertyName(ItemLogic itemLogic)
        {
            switch (ItemLogicPopertyNameMethod.FromString(itemLogic.propertyName))
            {
                case ItemLogicPopertyName.ImgOcarina:
                    return new Point(0, 0);
                case ItemLogicPopertyName.ImgBow:
                    return new Point(1, 0);
                case ItemLogicPopertyName.ImgFireArrow:
                    return new Point(2, 0);
                case ItemLogicPopertyName.ImgIceArrow:
                    return new Point(3, 0);
                case ItemLogicPopertyName.ImgLightArrow:
                    return new Point(4, 0);
                case ItemLogicPopertyName.ImgBomb:
                    return new Point(0, 1);
                case ItemLogicPopertyName.ImgBombchu:
                    return new Point(1, 1);
                case ItemLogicPopertyName.ImgStick:
                    return new Point(2, 1);
                case ItemLogicPopertyName.ImgNuts:
                    return new Point(3, 1);
                case ItemLogicPopertyName.ImgBeans:
                    return new Point(4, 1);
                case ItemLogicPopertyName.ImgKeg:
                    return new Point(0, 2);
                case ItemLogicPopertyName.ImgPicto:
                    return new Point(1, 2);
                case ItemLogicPopertyName.ImgLens:
                    return new Point(2, 2);
                case ItemLogicPopertyName.ImgHook:
                    return new Point(3, 2);
                case ItemLogicPopertyName.ImgGfsword:
                    return new Point(4, 2);
                case ItemLogicPopertyName.Imgbottle1:
                    return new Point(0, 3);
                case ItemLogicPopertyName.Imgbottle2:
                    return new Point(1, 3);
                case ItemLogicPopertyName.Imgbottle3:
                    return new Point(2, 3);
                case ItemLogicPopertyName.Imgbottle4:
                    return new Point(3, 3);
                case ItemLogicPopertyName.Imgbottle5:
                    return new Point(4, 3);
                case ItemLogicPopertyName.Imgbottle6:
                    return new Point(5, 3);
                case ItemLogicPopertyName.ImgScrubTrade:
                    return new Point(5, 0);
                case ItemLogicPopertyName.ImgKeyMama:
                    return new Point(5, 1);
                case ItemLogicPopertyName.ImgLetterpendant:
                    return new Point(5, 2);
                case ItemLogicPopertyName.DekuMask:
                    return new Point(5, 4);
                case ItemLogicPopertyName.GoronMask:
                    return new Point(5, 5);
                case ItemLogicPopertyName.ZoraMask:
                    return new Point(5, 6);
                case ItemLogicPopertyName.FiercedeityMask:
                    return new Point(5, 7);
                case ItemLogicPopertyName.TruthMask:
                    return new Point(4, 6);
                case ItemLogicPopertyName.KafeiMask:
                    return new Point(2, 6);
                case ItemLogicPopertyName.AllnightMask:
                    return new Point(1, 4);
                case ItemLogicPopertyName.BunnyhoodMask:
                    return new Point(2, 5);
                case ItemLogicPopertyName.KeatonMask:
                    return new Point(0, 5);
                case ItemLogicPopertyName.GaroMask:
                    return new Point(2, 7);
                case ItemLogicPopertyName.RomaniMask:
                    return new Point(0, 6);
                case ItemLogicPopertyName.CircusleaderMask:
                    return new Point(1, 6);
                case ItemLogicPopertyName.PostmanMask:
                    return new Point(0, 4);
                case ItemLogicPopertyName.CoupleMask:
                    return new Point(3, 6);
                case ItemLogicPopertyName.GreatfairyMask:
                    return new Point(4, 4);
                case ItemLogicPopertyName.GibdoMask:
                    return new Point(1, 7);
                case ItemLogicPopertyName.DonGeroMask:
                    return new Point(3, 5);
                case ItemLogicPopertyName.KamaroMask:
                    return new Point(0, 7);
                case ItemLogicPopertyName.CaptainMask:
                    return new Point(3, 7);
                case ItemLogicPopertyName.StoneMask:
                    return new Point(3, 4);
                case ItemLogicPopertyName.BremenMask:
                    return new Point(1, 5);
                case ItemLogicPopertyName.BlastMask:
                    return new Point(2, 4);
                case ItemLogicPopertyName.ScentsMask:
                    return new Point(4, 5);
                case ItemLogicPopertyName.GiantMask:
                    return new Point(4, 7);
                case ItemLogicPopertyName.ImgSword:
                    return new Point(4, 8);
                case ItemLogicPopertyName.ImgShield:
                    return new Point(5, 8);
                case ItemLogicPopertyName.ImgQuiver:
                    return new Point(4, 9);
                case ItemLogicPopertyName.ImgBombBag:
                    return new Point(5, 9);
                case ItemLogicPopertyName.ImgWallet:
                    return new Point(1, 9);
                case ItemLogicPopertyName.OdolwaMask:
                    return new Point(0, 8);
                case ItemLogicPopertyName.GohtMask:
                    return new Point(1, 8);
                case ItemLogicPopertyName.GyorgMask:
                    return new Point(2, 8);
                case ItemLogicPopertyName.TwinmoldMask:
                    return new Point(3, 8);
                case ItemLogicPopertyName.ImgBombersNote:
                    return new Point(0, 9);
                case ItemLogicPopertyName.ImgDoubleDefense:
                    return new Point(2, 9);
                case ItemLogicPopertyName.ImgMagic:
                    return new Point(3, 9);
                default:
                    throw new Exception($"Unknown property name: {itemLogic}");
            }
        }
    }
}
