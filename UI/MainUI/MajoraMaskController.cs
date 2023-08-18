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
    class MajoraMaskController
    {
        const string ITEM_SPRITE_MONO_PATH = @"\Resource\Itemicons\mm_items_mono.png";
        const string ITEM_SPRITE_COLOR_PATH = @"\Resource\Itemicons\mm_items.png";
        const string ITME_LOGIC_FILE_NAME = @"\Resource\Mappings\" + ItemLogicMethod.CST_DEFAULT_FILE_NAME;

        private Bitmap itemSpriteMono;
        private Bitmap itemSpriteColor;

        public List<ItemLogic> itemLogics;

        public bool Init(Func<ItemLogic, PictureBox> getPictureBoxFromItemLogic, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                // Init image
                itemSpriteMono = new Bitmap(Image.FromFile(Application.StartupPath + ITEM_SPRITE_MONO_PATH));
                itemSpriteColor = new Bitmap(Image.FromFile(Application.StartupPath + ITEM_SPRITE_COLOR_PATH));
                // Init json
                itemLogics = ItemLogicMethod.Deserialize(Application.StartupPath + ITME_LOGIC_FILE_NAME);


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
    }
}
