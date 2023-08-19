using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;
using MajoraAutoItemTracker.Model.Item;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class OcarinaOfTimeController : AbstractUIRoomController<OcarinaOfTimeCheckLogicZone>
    {
        const string ITEM_SPRITE_MONO_PATH = @"\Resource\Itemicons\oot_items_mono.png";
        const string ITEM_SPRITE_COLOR_PATH = @"\Resource\Itemicons\oot_items.png";
        const string ITEM_LOGIC_FILE_NAME = @"\Resource\Mappings\" + ItemLogicMethod.CST_OOT_FILE_NAME;
        const string ITEM_CHECK_LOGIC_CATEGORY_PATH = @"\Resource\CheckLogic\" + OcarinaOfTimeCheckLogicCategory.CST_DEFAULT_FILE_NAME;

        public List<ItemLogic> itemLogics;
        public List<OcarinaOfTimeCheckLogicCategory> checkLogicCategories;
        public List<OcarinaOfTimeCheckLogic> checkLogics;

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
                checkLogicCategories = OcarinaOfTimeCheckLogicCategory.LoadFromFile(Application.StartupPath + ITEM_CHECK_LOGIC_CATEGORY_PATH);
                checkLogics = OcarinaOfTimeCheckLogic.FromHeader(checkLogicCategories);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                errorMessage = e.Message;
                return false;
            }
        }

        public void RefreshCheckListForCategory(ListBox listbox, OcarinaOfTimeCheckLogicZone checkLogicZone)
        {   
            listbox.Items.Clear();
            foreach (var checkLogic in checkLogics) // recuperer tout les checks dans la catégorie
                if (checkLogic.Zone == checkLogicZone)
                    listbox.Items.Add(checkLogic);
        }

        public override void DrawSquareCategory(PictureBoxZoomMoveController<OcarinaOfTimeCheckLogicZone> pictureBox, int rectWidthAndHeight)
        {
            foreach (var checkLogicCategory in checkLogicCategories)
            {
                pictureBox.AddRect(
                    checkLogicCategory.SquarePositionX - rectWidthAndHeight / 2,
                    checkLogicCategory.SquarePositionY - rectWidthAndHeight / 2,
                    rectWidthAndHeight, rectWidthAndHeight,
                    OcarinaOfTimeCheckLogicZoneMethod.FromString(checkLogicCategory.Name)
                );
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
            var listBox = (ListBox)sender;
            var checkLogic = (OcarinaOfTimeCheckLogic)listBox.Items[e.Index];
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
            var checkList = (OcarinaOfTimeCheckLogic)listBox.SelectedItem;
            checkList.IsClaim = !checkList.IsClaim;
            listBox.Refresh();
        }

        private Point GetPositionInDrawingOfItemLogicPropertyName(ItemLogic itemLogic)
        {
            switch (OcarinaOfTimeItemLogicPopertyNameMethod.FromString(itemLogic.propertyName))
            {
                case OcarinaOfTimeItemLogicPopertyName.Deku_Stick:
                    return new Point(0, 0);
                case OcarinaOfTimeItemLogicPopertyName.Deku_Nut:
                    return new Point(1, 0);
                case OcarinaOfTimeItemLogicPopertyName.Bomb:
                    return new Point(2, 0);
                case OcarinaOfTimeItemLogicPopertyName.Bow:
                    return new Point(3, 0);
                case OcarinaOfTimeItemLogicPopertyName.Fire_Arrow:
                    return new Point(4, 0);
                case OcarinaOfTimeItemLogicPopertyName.Din_Fire:
                    return new Point(5, 0);
                case OcarinaOfTimeItemLogicPopertyName.Fairy_Slingshot:
                    return new Point(0, 1);
                case OcarinaOfTimeItemLogicPopertyName.Ocarina:
                    return new Point(1, 1);
                case OcarinaOfTimeItemLogicPopertyName.Bombchu:
                    return new Point(2, 1);
                case OcarinaOfTimeItemLogicPopertyName.Hookshot:
                    return new Point(3, 1);
                case OcarinaOfTimeItemLogicPopertyName.Ice_Arrow:
                    return new Point(4, 1);
                case OcarinaOfTimeItemLogicPopertyName.Farore_Wind:
                    return new Point(5, 1);
                case OcarinaOfTimeItemLogicPopertyName.Boomerang:
                    return new Point(0, 2);
                case OcarinaOfTimeItemLogicPopertyName.Lens_of_Truth:
                    return new Point(1, 2);
                case OcarinaOfTimeItemLogicPopertyName.Magic_Bean:
                    return new Point(2, 2);
                case OcarinaOfTimeItemLogicPopertyName.Megaton_Hammer:
                    return new Point(3, 2);
                case OcarinaOfTimeItemLogicPopertyName.Light_Arrow:
                    return new Point(4, 2);
                case OcarinaOfTimeItemLogicPopertyName.Nayru_Love:
                    return new Point(5, 2);
                case OcarinaOfTimeItemLogicPopertyName.Bottle_1:
                    return new Point(0, 3);
                case OcarinaOfTimeItemLogicPopertyName.Bottle_2:
                    return new Point(1, 3);
                case OcarinaOfTimeItemLogicPopertyName.Bottle_3:
                    return new Point(2, 3);
                case OcarinaOfTimeItemLogicPopertyName.Bottle_4:
                    return new Point(3, 3);
                case OcarinaOfTimeItemLogicPopertyName.Weird_Egg:
                    return new Point(4, 3);
                case OcarinaOfTimeItemLogicPopertyName.Weird_Egg_2:
                    return new Point(5, 3);
                case OcarinaOfTimeItemLogicPopertyName.Kokiri_Sword:
                    return new Point(0, 4);
                case OcarinaOfTimeItemLogicPopertyName.Master_Sword:
                    return new Point(1, 4);
                case OcarinaOfTimeItemLogicPopertyName.Giant_Knife_Biggoron_Sword:
                    return new Point(2, 4);
                case OcarinaOfTimeItemLogicPopertyName.Stone_of_Agony:
                    return new Point(3, 4);
                case OcarinaOfTimeItemLogicPopertyName.Gerudo_Card:
                    return new Point(4, 4);
                case OcarinaOfTimeItemLogicPopertyName.Gold_Skulltula:
                    return new Point(5, 4);
                case OcarinaOfTimeItemLogicPopertyName.Deku_Shield:
                    return new Point(0, 5);
                case OcarinaOfTimeItemLogicPopertyName.Hylian_Shield:
                    return new Point(1, 5);
                case OcarinaOfTimeItemLogicPopertyName.Mirror_Shield:
                    return new Point(2, 5);
                case OcarinaOfTimeItemLogicPopertyName.Goron_Bracelet:
                    return new Point(3, 5);
                case OcarinaOfTimeItemLogicPopertyName.Silver_Scale:
                    return new Point(4, 5);
                case OcarinaOfTimeItemLogicPopertyName.Wallet:
                    return new Point(5, 5);
                case OcarinaOfTimeItemLogicPopertyName.Kokiri_Tunic:
                    return new Point(0, 6);
                case OcarinaOfTimeItemLogicPopertyName.Goron_Tunic:
                    return new Point(1, 6);
                case OcarinaOfTimeItemLogicPopertyName.Zora_Tunic:
                    return new Point(2, 6);
                case OcarinaOfTimeItemLogicPopertyName.Heart_Container:
                    return new Point(4, 6);
                case OcarinaOfTimeItemLogicPopertyName.Magic:
                    return new Point(5, 6);
                case OcarinaOfTimeItemLogicPopertyName.Kokiri_Boots:
                    return new Point(0, 7);
                case OcarinaOfTimeItemLogicPopertyName.Iron_Boots:
                    return new Point(1, 7);
                case OcarinaOfTimeItemLogicPopertyName.Hover_Boots:
                    return new Point(2, 7);
                case OcarinaOfTimeItemLogicPopertyName.Kokiri_Emerald:
                    return new Point(3, 7);
                case OcarinaOfTimeItemLogicPopertyName.Goron_Ruby:
                    return new Point(4, 7);
                case OcarinaOfTimeItemLogicPopertyName.Zora_Sapphire:
                    return new Point(5, 7);
                case OcarinaOfTimeItemLogicPopertyName.Forest_Medallion:
                    return new Point(0, 8);
                case OcarinaOfTimeItemLogicPopertyName.Fire_Medallion:
                    return new Point(1, 8);
                case OcarinaOfTimeItemLogicPopertyName.Water_Medallion:
                    return new Point(2, 8);
                case OcarinaOfTimeItemLogicPopertyName.Spirit_Medallion:
                    return new Point(3, 8);
                case OcarinaOfTimeItemLogicPopertyName.Shadow_Medallion:
                    return new Point(4, 8);
                case OcarinaOfTimeItemLogicPopertyName.Light_Medallion:
                    return new Point(5, 8);
                case OcarinaOfTimeItemLogicPopertyName.Minuet_of_Forest:
                    return new Point(0, 9);
                case OcarinaOfTimeItemLogicPopertyName.Bolero_of_Fire:
                    return new Point(1, 9);
                case OcarinaOfTimeItemLogicPopertyName.Serenade_of_Water:
                    return new Point(2, 9);
                case OcarinaOfTimeItemLogicPopertyName.Requiem_of_Spirit:
                    return new Point(3, 9);
                case OcarinaOfTimeItemLogicPopertyName.Nocturne_of_Shadow:
                    return new Point(4, 9);
                case OcarinaOfTimeItemLogicPopertyName.Prelude_of_Light:
                    return new Point(5, 9);
                case OcarinaOfTimeItemLogicPopertyName.Zelda_Lullaby:
                    return new Point(0, 10);
                case OcarinaOfTimeItemLogicPopertyName.Epona_Song:
                    return new Point(1, 10);
                case OcarinaOfTimeItemLogicPopertyName.Saria_Song:
                    return new Point(2, 10);
                case OcarinaOfTimeItemLogicPopertyName.Sun_Song:
                    return new Point(3, 10);
                case OcarinaOfTimeItemLogicPopertyName.Song_of_Time:
                    return new Point(4, 10);
                case OcarinaOfTimeItemLogicPopertyName.Song_of_Storms:
                    return new Point(5, 10);
                default:
                    throw new Exception($"Unknown property name: {itemLogic.propertyName}");
            }
        }
    }
}
