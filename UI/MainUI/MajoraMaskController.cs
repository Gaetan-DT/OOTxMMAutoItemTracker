using MajoraAutoItemTracker.Logic;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using MajoraAutoItemTracker.Model.Logic.MM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

#nullable enable

namespace MajoraAutoItemTracker.UI.MainUI
{
    class MajoraMaskController : AbstractUIRoomController<MajoraMaskCheckLogic, MajoraMaskCheckLogicZone>
    {
        const string ITEM_SPRITE_MONO_PATH = @"\Resource\Itemicons\mm_items_mono.png";
        const string ITEM_SPRITE_COLOR_PATH = @"\Resource\Itemicons\mm_items.png";
        const string ITEM_POSITION_MAPING_NAME = @"\Resource\Mappings\" + ItemLogicMethod.CST_DEFAULT_FILE_NAME;
        const string ITEM_CHECK_LOGIC_CATEGORY_PATH = @"\Resource\CheckLogic\" + MajoraMaskCheckLogicCategory.CST_DEFAULT_FILE_NAME;
        const string ITEM_LOGIC_FILE_NAME = LogicFile<object>.CST_REQ_CASUAL_PATH + LogicFile<object>.CST_MM_REQ_FILE_NAME;

        private readonly Dictionary<MajoraMaskItemLogicPopertyName, Point> mapPropertyNamePosition = new Dictionary<MajoraMaskItemLogicPopertyName, Point>()
        {
            { MajoraMaskItemLogicPopertyName.ImgOcarina, new Point(0, 0) },
            { MajoraMaskItemLogicPopertyName.ImgBow, new Point(1, 0) },
            { MajoraMaskItemLogicPopertyName.ImgFireArrow, new Point(2, 0) },
            { MajoraMaskItemLogicPopertyName.ImgIceArrow, new Point(3, 0) },
            { MajoraMaskItemLogicPopertyName.ImgLightArrow, new Point(4, 0) },
            { MajoraMaskItemLogicPopertyName.ImgBomb, new Point(0, 1) },
            { MajoraMaskItemLogicPopertyName.ImgBombchu, new Point(1, 1) },
            { MajoraMaskItemLogicPopertyName.ImgStick, new Point(2, 1) },
            { MajoraMaskItemLogicPopertyName.ImgNuts, new Point(3, 1) },
            { MajoraMaskItemLogicPopertyName.ImgBeans, new Point(4, 1) },
            { MajoraMaskItemLogicPopertyName.ImgKeg, new Point(0, 2) },
            { MajoraMaskItemLogicPopertyName.ImgPicto, new Point(1, 2) },
            { MajoraMaskItemLogicPopertyName.ImgLens, new Point(2, 2) },
            { MajoraMaskItemLogicPopertyName.ImgHook, new Point(3, 2) },
            { MajoraMaskItemLogicPopertyName.ImgGfsword, new Point(4, 2) },
            { MajoraMaskItemLogicPopertyName.Imgbottle1, new Point(0, 3) },
            { MajoraMaskItemLogicPopertyName.Imgbottle2, new Point(1, 3) },
            { MajoraMaskItemLogicPopertyName.Imgbottle3, new Point(2, 3) },
            { MajoraMaskItemLogicPopertyName.Imgbottle4, new Point(3, 3) },
            { MajoraMaskItemLogicPopertyName.Imgbottle5, new Point(4, 3) },
            { MajoraMaskItemLogicPopertyName.Imgbottle6, new Point(5, 3) },
            { MajoraMaskItemLogicPopertyName.ImgScrubTrade, new Point(5, 0) },
            { MajoraMaskItemLogicPopertyName.ImgKeyMama, new Point(5, 1) },
            { MajoraMaskItemLogicPopertyName.ImgLetterpendant, new Point(5, 2) },
            { MajoraMaskItemLogicPopertyName.DekuMask, new Point(5, 4) },
            { MajoraMaskItemLogicPopertyName.GoronMask, new Point(5, 5) },
            { MajoraMaskItemLogicPopertyName.ZoraMask, new Point(5, 6) },
            { MajoraMaskItemLogicPopertyName.FiercedeityMask, new Point(5, 7) },
            { MajoraMaskItemLogicPopertyName.TruthMask, new Point(4, 6) },
            { MajoraMaskItemLogicPopertyName.KafeiMask, new Point(2, 6) },
            { MajoraMaskItemLogicPopertyName.AllnightMask, new Point(1, 4) },
            { MajoraMaskItemLogicPopertyName.BunnyhoodMask, new Point(2, 5) },
            { MajoraMaskItemLogicPopertyName.KeatonMask, new Point(0, 5) },
            { MajoraMaskItemLogicPopertyName.GaroMask, new Point(2, 7) },
            { MajoraMaskItemLogicPopertyName.RomaniMask, new Point(0, 6) },
            { MajoraMaskItemLogicPopertyName.CircusleaderMask, new Point(1, 6) },
            { MajoraMaskItemLogicPopertyName.PostmanMask, new Point(0, 4) },
            { MajoraMaskItemLogicPopertyName.CoupleMask, new Point(3, 6) },
            { MajoraMaskItemLogicPopertyName.GreatfairyMask, new Point(4, 4) },
            { MajoraMaskItemLogicPopertyName.GibdoMask, new Point(1, 7) },
            { MajoraMaskItemLogicPopertyName.DonGeroMask, new Point(3, 5) },
            { MajoraMaskItemLogicPopertyName.KamaroMask, new Point(0, 7) },
            { MajoraMaskItemLogicPopertyName.CaptainMask, new Point(3, 7) },
            { MajoraMaskItemLogicPopertyName.StoneMask, new Point(3, 4) },
            { MajoraMaskItemLogicPopertyName.BremenMask, new Point(1, 5) },
            { MajoraMaskItemLogicPopertyName.BlastMask, new Point(2, 4) },
            { MajoraMaskItemLogicPopertyName.ScentsMask, new Point(4, 5) },
            { MajoraMaskItemLogicPopertyName.GiantMask, new Point(4, 7) },
            { MajoraMaskItemLogicPopertyName.ImgSword, new Point(4, 8) },
            { MajoraMaskItemLogicPopertyName.ImgShield, new Point(5, 8) },
            { MajoraMaskItemLogicPopertyName.ImgQuiver, new Point(4, 9) },
            { MajoraMaskItemLogicPopertyName.ImgBombBag, new Point(5, 9) },
            { MajoraMaskItemLogicPopertyName.ImgWallet, new Point(1, 9) },
            { MajoraMaskItemLogicPopertyName.OdolwaMask, new Point(0, 8) },
            { MajoraMaskItemLogicPopertyName.GohtMask, new Point(1, 8) },
            { MajoraMaskItemLogicPopertyName.GyorgMask, new Point(2, 8) },
            { MajoraMaskItemLogicPopertyName.TwinmoldMask, new Point(3, 8) },
            { MajoraMaskItemLogicPopertyName.ImgBombersNote, new Point(0, 9) },
            { MajoraMaskItemLogicPopertyName.ImgDoubleDefense, new Point(2, 9) },
            { MajoraMaskItemLogicPopertyName.ImgMagic, new Point(3, 9) },
            { MajoraMaskItemLogicPopertyName.SongOfTime, new Point(0, 10) },
            { MajoraMaskItemLogicPopertyName.SongOfHealing, new Point(1, 10) },
            { MajoraMaskItemLogicPopertyName.EponaSong, new Point(2, 10) },
            { MajoraMaskItemLogicPopertyName.SongOfSoaring, new Point(3, 10) },
            { MajoraMaskItemLogicPopertyName.SongOfStorm, new Point(4, 10) },
            { MajoraMaskItemLogicPopertyName.SonataOfAwakening, new Point(0, 11) },
            { MajoraMaskItemLogicPopertyName.GoronLullaby, new Point(1, 11) },
            { MajoraMaskItemLogicPopertyName.NewWaveBossaNova, new Point(2, 11) },
            { MajoraMaskItemLogicPopertyName.ElegyOfEmptyness, new Point(3, 11) },
            { MajoraMaskItemLogicPopertyName.SongOathToOrder, new Point(4, 11) },
            { MajoraMaskItemLogicPopertyName.SunSong, new Point(5, 11) }
    };

        private LogicFile<MajoraMaskJsonFormatLogicItem> logicFile;
        public MajoraMaskLogicResolver logicResolver;

        public List<MajoraMaskCheckLogicCategory> checkLogicCategories;

        public MajoraMaskController()
        {
            // Init max point
            foreach (var enumPropertyName in MajoraMaskItemLogicPopertyNameMethod.GetAsList())
            {
                var positionOfEnum = GetPositionInDrawingOfItemLogicPropertyName(enumPropertyName);
                maxPropertyNamePosition.X = Math.Max(maxPropertyNamePosition.X, positionOfEnum.X);
                maxPropertyNamePosition.Y = Math.Max(maxPropertyNamePosition.Y, positionOfEnum.Y);
            };
            // Init image
            itemSpriteMono = new Bitmap(Image.FromFile(Application.StartupPath + ITEM_SPRITE_MONO_PATH));
            itemSpriteColor = new Bitmap(Image.FromFile(Application.StartupPath + ITEM_SPRITE_COLOR_PATH));
            // Init json
            itemLogics = ItemLogicMethod.Deserialize(Application.StartupPath + ITEM_POSITION_MAPING_NAME);
            checkLogicCategories = MajoraMaskCheckLogicCategory.LoadFromFile(Application.StartupPath + ITEM_CHECK_LOGIC_CATEGORY_PATH)!;
            checkLogics = MajoraMaskCheckLogic.FromHeader(checkLogicCategories);
            logicFile = LogicFile<MajoraMaskJsonFormatLogicItem>.FromFile(ITEM_LOGIC_FILE_NAME)!;
            // Logic resolver
            logicResolver = new MajoraMaskLogicResolver(logicFile);
        }

        public void RefreshRegionInDrawingFollowingCheck(List<MajoraMaskCheckLogic> checkLogic)
        {
            logWrite?.Invoke($"Call RefreshRegionInDrawingFollowingCheck with {checkLogic.Count} check updated");
            // Get all region to update from the list of checkLogic
            foreach (var checkCategory in checkLogic.Select((it) => it.Zone).Distinct())
            {
                logWrite?.Invoke($"Updated check for the following category: [{checkCategory}]");
                RefreshRegionInDrawingFollowingCheck(checkCategory);
            }
        }

        public override void DrawSquareCategory(int rectWidthAndHeight)
        {
            foreach (var checkLogicCategory in checkLogicCategories)
            {
                if (checkLogicCategory.Name == null)
                    throw new Exception("ERROR: checkLogicCategory.Name is null");
                pictureBoxZoomMoveController?.AddRect(
                    checkLogicCategory.SquarePositionX - rectWidthAndHeight / 2,
                    checkLogicCategory.SquarePositionY - rectWidthAndHeight / 2,
                    rectWidthAndHeight, rectWidthAndHeight,
                    MajoraMaskCheckLogicZoneMethod.FromString(checkLogicCategory.Name)
                );
            }
        }

        // Call when change is trigger from memory
        public void OnItemLogicChange(List<Tuple<MajoraMaskItemLogicPopertyName, object>> listItemLogicProperty)
        {
            if (itemLogics == null || checkLogics == null)
            {
                return;
            }
            foreach (var itemLogicProperty in listItemLogicProperty)
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
                        break;
                    }
                }
            }
            // TODO: gerer les différent cas pour les enum
            pictureBoxItemList?.Refresh();
            // TODO: appeler la logicresolver pour mettre à jour les check avec le nouveau set d'items
            var listOfUpdateCheck = logicResolver.UpdateCheckAndReturnListOfUpdatedCheck(itemLogics, checkLogics, false);
            RefreshRegionInDrawingFollowingCheck(listOfUpdateCheck);
            pictureBoxItemList?.Refresh();
        }

        protected override Point GetPositionInDrawingOfItemLogicPropertyName(string propertyName)
        {
            return GetPositionInDrawingOfItemLogicPropertyName(MajoraMaskItemLogicPopertyNameMethod.FromString(propertyName));
        }

        private Point GetPositionInDrawingOfItemLogicPropertyName(MajoraMaskItemLogicPopertyName enumPropertyName)
        {
            if (mapPropertyNamePosition.TryGetValue(enumPropertyName, out var result))
                return result;
            throw new Exception($"Unknown property name: {enumPropertyName}");
        }
    }
}
