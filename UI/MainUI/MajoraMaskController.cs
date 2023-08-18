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

        private Bitmap itemSpriteMono;
        private Bitmap itemSpriteColor;

        public List<ItemLogic> itemLogics;
        public List<CheckLogicCategory> checkLogicCategories;
        public List<CheckLogic> checkLogics;

        public bool Init(Func<ItemLogic, PictureBox> getPictureBoxFromItemLogic, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                // Init image
                itemSpriteMono = new Bitmap(Image.FromFile(Application.StartupPath + ITEM_SPRITE_MONO_PATH));
                itemSpriteColor = new Bitmap(Image.FromFile(Application.StartupPath + ITEM_SPRITE_COLOR_PATH));
                // Init json
                itemLogics = ItemLogicMethod.Deserialize(Application.StartupPath + ITEM_LOGIC_FILE_NAME);
                checkLogicCategories = CheckLogicCategory.LoadFromFile(Application.StartupPath + ITEM_CHECK_LOGIC_CATEGORY_PATH);
                checkLogics = CheckLogic.FromHeader(checkLogicCategories);

                DrawItemSprite(getPictureBoxFromItemLogic);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                errorMessage = e.Message;
                return false;
            }
        }

        private void DrawItemSprite(Func<ItemLogic, PictureBox> getPictureBoxFromItemLogic)
        {
            foreach (var item in itemLogics)
                DrawItem(getPictureBoxFromItemLogic, item);
        }

        public void DrawItem(Func<ItemLogic, PictureBox> getPictureBoxFromItemLogic, ItemLogic itemLogic)
        {
            if (itemLogic.propertyName == null || itemLogic.propertyName == "")
                return;
            var pictureBox = getPictureBoxFromItemLogic(itemLogic);
            var posX = itemLogic.variants[itemLogic.CurrentVariant].positionX * 42;
            var posY = itemLogic.variants[itemLogic.CurrentVariant].positionY * 42;
            if (itemLogic.hasItem)
                pictureBox.Image = itemSpriteColor.Clone(new Rectangle(posX, posY, 42, 42), itemSpriteColor.PixelFormat);
            else
                pictureBox.Image = itemSpriteMono.Clone(new Rectangle(posX, posY, 42, 42), itemSpriteMono.PixelFormat);
        }

        // Refrehs all check available for a zone
        // Use the list of all check logic and filter it by zone
        public void RefreshCheckListForCategory(ListBox listbox, CheckLogicZone checkLogicZone)
        {
            listbox.Items.Clear();
            foreach (var checkLogic in checkLogics) // recuperer tout les checks dans la catégorie
                if (checkLogic.Zone == checkLogicZone)
                    listbox.Items.Add(checkLogic);
        }

        public void DrawSquareCategory(PictureBoxZoomMoveController<CheckLogicZone> pictureBox, int rectWidthAndHeight)
        {
            foreach (var checkLogicCategory in checkLogicCategories)
            {
                pictureBox.AddRect(
                    checkLogicCategory.SquarePositionX - rectWidthAndHeight / 2,
                    checkLogicCategory.SquarePositionY - rectWidthAndHeight / 2,
                    rectWidthAndHeight, rectWidthAndHeight,
                    CheckLogicZoneMethod.FromString(checkLogicCategory.Name)
                );
            }
        }
    }
}
