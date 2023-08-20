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
    class MajoraMaskController : AbstractUIRoomController<MajoraMaskCheckLogicZone>
    {
        const string ITEM_SPRITE_MONO_PATH = @"\Resource\Itemicons\mm_items_mono.png";
        const string ITEM_SPRITE_COLOR_PATH = @"\Resource\Itemicons\mm_items.png";
        const string ITEM_LOGIC_FILE_NAME = @"\Resource\Mappings\" + ItemLogicMethod.CST_DEFAULT_FILE_NAME;
        const string ITEM_CHECK_LOGIC_CATEGORY_PATH = @"\Resource\CheckLogic\" + MajoraMaskCheckLogicCategory.CST_DEFAULT_FILE_NAME;

        public List<ItemLogic> itemLogics;
        public List<MajoraMaskCheckLogicCategory> checkLogicCategories;
        public List<MajoraMaskCheckLogic> checkLogics;

        public override bool Init(PictureBox pbItemList, ListBox lbCheckList, out string errorMessage)
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
                checkLogicCategories = MajoraMaskCheckLogicCategory.LoadFromFile(Application.StartupPath + ITEM_CHECK_LOGIC_CATEGORY_PATH);
                checkLogics = MajoraMaskCheckLogic.FromHeader(checkLogicCategories);
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

        public override void DrawSquareCategory(PictureBoxZoomMoveController<MajoraMaskCheckLogicZone> pictureBox, int rectWidthAndHeight)
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
        public void OnItemLogicChange(Tuple<MajoraMaskItemLogicPopertyName, object> itemLogicProperty)
        {
            foreach (var itemLogic in itemLogics)
            {
                if (itemLogic.propertyName == null || itemLogic.propertyName == "")
                    continue;
                else if (itemLogicProperty.Item1 == MajoraMaskItemLogicPopertyNameMethod.FromString(itemLogic.propertyName))
                {
                    if (itemLogicProperty.Item2 is bool)
                    {
                        itemLogic.hasItem = (bool)itemLogicProperty.Item2;
                        itemLogic.CurrentVariant = 0;
                    }
                    else if (itemLogicProperty.Item2 is EquipmentQuiver)
                    {
                        itemLogic.hasItem = (EquipmentQuiver)itemLogicProperty.Item2 != EquipmentQuiver.None;
                        itemLogic.CurrentVariant = (int)itemLogicProperty.Item2;
                    }
                    else
                    {
                        itemLogic.hasItem = false;
                        itemLogic.CurrentVariant = 0;
                    }
                    // TODO: gerer les différent cas pour les enum
                    pictureBoxItemList.Refresh();
                    // TODO: appeler la logicresolver pour mettre à jour les check avec le nouveau set d'items
                    break;
                }
            }
        }

        public override void DrawAllItemList(object sender, PaintEventArgs e)
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
                var point = GetPositionInDrawingOfItemLogicPropertyName(itemLogic);
                g.DrawImage(imageToDraw, new Rectangle(point.X * ITEM_LIST_SIZE, point.Y * ITEM_LIST_SIZE, ITEM_LIST_SIZE, ITEM_LIST_SIZE));
            }
        }

        public override void DrawCheckList(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            var listBox = (ListBox)sender;
            var checkLogic = (MajoraMaskCheckLogic)listBox.Items[e.Index];
            Brush brush;
            if (checkLogic.IsClaim)
                brush = Brushes.Gray;
            else if (checkLogic.IsAvailable)
                brush = Brushes.Green;
            else
                brush = Brushes.Red;
            e.Graphics.DrawString(checkLogic.Id, e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }

        public override void OnCheckListItemClick(object sender, MouseEventArgs e)
        {
            var listBox = (ListBox)sender;
            var checkList = (MajoraMaskCheckLogic)listBox.SelectedItem;
            checkList.IsClaim = !checkList.IsClaim;
            listBox.Refresh();
        }

        private Point GetPositionInDrawingOfItemLogicPropertyName(ItemLogic itemLogic)
        {
            switch (MajoraMaskItemLogicPopertyNameMethod.FromString(itemLogic.propertyName))
            {
                case MajoraMaskItemLogicPopertyName.ImgOcarina:
                    return new Point(0, 0);
                case MajoraMaskItemLogicPopertyName.ImgBow:
                    return new Point(1, 0);
                case MajoraMaskItemLogicPopertyName.ImgFireArrow:
                    return new Point(2, 0);
                case MajoraMaskItemLogicPopertyName.ImgIceArrow:
                    return new Point(3, 0);
                case MajoraMaskItemLogicPopertyName.ImgLightArrow:
                    return new Point(4, 0);
                case MajoraMaskItemLogicPopertyName.ImgBomb:
                    return new Point(0, 1);
                case MajoraMaskItemLogicPopertyName.ImgBombchu:
                    return new Point(1, 1);
                case MajoraMaskItemLogicPopertyName.ImgStick:
                    return new Point(2, 1);
                case MajoraMaskItemLogicPopertyName.ImgNuts:
                    return new Point(3, 1);
                case MajoraMaskItemLogicPopertyName.ImgBeans:
                    return new Point(4, 1);
                case MajoraMaskItemLogicPopertyName.ImgKeg:
                    return new Point(0, 2);
                case MajoraMaskItemLogicPopertyName.ImgPicto:
                    return new Point(1, 2);
                case MajoraMaskItemLogicPopertyName.ImgLens:
                    return new Point(2, 2);
                case MajoraMaskItemLogicPopertyName.ImgHook:
                    return new Point(3, 2);
                case MajoraMaskItemLogicPopertyName.ImgGfsword:
                    return new Point(4, 2);
                case MajoraMaskItemLogicPopertyName.Imgbottle1:
                    return new Point(0, 3);
                case MajoraMaskItemLogicPopertyName.Imgbottle2:
                    return new Point(1, 3);
                case MajoraMaskItemLogicPopertyName.Imgbottle3:
                    return new Point(2, 3);
                case MajoraMaskItemLogicPopertyName.Imgbottle4:
                    return new Point(3, 3);
                case MajoraMaskItemLogicPopertyName.Imgbottle5:
                    return new Point(4, 3);
                case MajoraMaskItemLogicPopertyName.Imgbottle6:
                    return new Point(5, 3);
                case MajoraMaskItemLogicPopertyName.ImgScrubTrade:
                    return new Point(5, 0);
                case MajoraMaskItemLogicPopertyName.ImgKeyMama:
                    return new Point(5, 1);
                case MajoraMaskItemLogicPopertyName.ImgLetterpendant:
                    return new Point(5, 2);
                case MajoraMaskItemLogicPopertyName.DekuMask:
                    return new Point(5, 4);
                case MajoraMaskItemLogicPopertyName.GoronMask:
                    return new Point(5, 5);
                case MajoraMaskItemLogicPopertyName.ZoraMask:
                    return new Point(5, 6);
                case MajoraMaskItemLogicPopertyName.FiercedeityMask:
                    return new Point(5, 7);
                case MajoraMaskItemLogicPopertyName.TruthMask:
                    return new Point(4, 6);
                case MajoraMaskItemLogicPopertyName.KafeiMask:
                    return new Point(2, 6);
                case MajoraMaskItemLogicPopertyName.AllnightMask:
                    return new Point(1, 4);
                case MajoraMaskItemLogicPopertyName.BunnyhoodMask:
                    return new Point(2, 5);
                case MajoraMaskItemLogicPopertyName.KeatonMask:
                    return new Point(0, 5);
                case MajoraMaskItemLogicPopertyName.GaroMask:
                    return new Point(2, 7);
                case MajoraMaskItemLogicPopertyName.RomaniMask:
                    return new Point(0, 6);
                case MajoraMaskItemLogicPopertyName.CircusleaderMask:
                    return new Point(1, 6);
                case MajoraMaskItemLogicPopertyName.PostmanMask:
                    return new Point(0, 4);
                case MajoraMaskItemLogicPopertyName.CoupleMask:
                    return new Point(3, 6);
                case MajoraMaskItemLogicPopertyName.GreatfairyMask:
                    return new Point(4, 4);
                case MajoraMaskItemLogicPopertyName.GibdoMask:
                    return new Point(1, 7);
                case MajoraMaskItemLogicPopertyName.DonGeroMask:
                    return new Point(3, 5);
                case MajoraMaskItemLogicPopertyName.KamaroMask:
                    return new Point(0, 7);
                case MajoraMaskItemLogicPopertyName.CaptainMask:
                    return new Point(3, 7);
                case MajoraMaskItemLogicPopertyName.StoneMask:
                    return new Point(3, 4);
                case MajoraMaskItemLogicPopertyName.BremenMask:
                    return new Point(1, 5);
                case MajoraMaskItemLogicPopertyName.BlastMask:
                    return new Point(2, 4);
                case MajoraMaskItemLogicPopertyName.ScentsMask:
                    return new Point(4, 5);
                case MajoraMaskItemLogicPopertyName.GiantMask:
                    return new Point(4, 7);
                case MajoraMaskItemLogicPopertyName.ImgSword:
                    return new Point(4, 8);
                case MajoraMaskItemLogicPopertyName.ImgShield:
                    return new Point(5, 8);
                case MajoraMaskItemLogicPopertyName.ImgQuiver:
                    return new Point(4, 9);
                case MajoraMaskItemLogicPopertyName.ImgBombBag:
                    return new Point(5, 9);
                case MajoraMaskItemLogicPopertyName.ImgWallet:
                    return new Point(1, 9);
                case MajoraMaskItemLogicPopertyName.OdolwaMask:
                    return new Point(0, 8);
                case MajoraMaskItemLogicPopertyName.GohtMask:
                    return new Point(1, 8);
                case MajoraMaskItemLogicPopertyName.GyorgMask:
                    return new Point(2, 8);
                case MajoraMaskItemLogicPopertyName.TwinmoldMask:
                    return new Point(3, 8);
                case MajoraMaskItemLogicPopertyName.ImgBombersNote:
                    return new Point(0, 9);
                case MajoraMaskItemLogicPopertyName.ImgDoubleDefense:
                    return new Point(2, 9);
                case MajoraMaskItemLogicPopertyName.ImgMagic:
                    return new Point(3, 9);
                case MajoraMaskItemLogicPopertyName.SongOfTime: 
                    return new Point(0, 10);
                case MajoraMaskItemLogicPopertyName.SongOfHealing: 
                    return new Point(1, 10);
                case MajoraMaskItemLogicPopertyName.EponaSong: 
                    return new Point(2, 10);
                case MajoraMaskItemLogicPopertyName.SongOfSoaring: 
                    return new Point(3, 10);
                case MajoraMaskItemLogicPopertyName.SongOfStorm: 
                    return new Point(4, 10);
                case MajoraMaskItemLogicPopertyName.SonataOfAwakening: 
                    return new Point(0, 11);
                case MajoraMaskItemLogicPopertyName.GoronLullaby: 
                    return new Point(1, 11);
                case MajoraMaskItemLogicPopertyName.NewWaveBossaNova: 
                    return new Point(2, 11);
                case MajoraMaskItemLogicPopertyName.ElegyOfEmptyness: 
                    return new Point(3, 11);
                case MajoraMaskItemLogicPopertyName.SongOathToOrder: 
                    return new Point(4, 11);
                case MajoraMaskItemLogicPopertyName.SunSong: 
                    return new Point(5, 11);
                default:
                    throw new Exception($"Unknown property name: {itemLogic}");
            }
        }
    }
}
