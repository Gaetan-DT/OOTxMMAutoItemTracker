using MajoraAutoItemTracker.Core.Extensions;
using MajoraAutoItemTracker.Logic;
using MajoraAutoItemTracker.Model.CheckLogic;
using MajoraAutoItemTracker.Model.Enum.OOT;
using MajoraAutoItemTracker.Model.Item;
using MajoraAutoItemTracker.Model.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class OcarinaOfTimeController : AbstractUIRoomController<OcarinaOfTimeCheckLogic, OcarinaOfTimeCheckLogicZone>
    {
        private readonly Dictionary<OcarinaOfTimeItemLogicPopertyName, Point> mapPropertyNamePosition = 
            new Dictionary<OcarinaOfTimeItemLogicPopertyName, Point>()
        {
            { OcarinaOfTimeItemLogicPopertyName.Deku_Stick, new Point(0, 0) },
            { OcarinaOfTimeItemLogicPopertyName.Deku_Nut, new Point(1, 0) },
            { OcarinaOfTimeItemLogicPopertyName.Bomb, new Point(2, 0) },
            { OcarinaOfTimeItemLogicPopertyName.Bow, new Point(3, 0) },
            { OcarinaOfTimeItemLogicPopertyName.Fire_Arrow, new Point(4, 0) },
            { OcarinaOfTimeItemLogicPopertyName.Din_Fire, new Point(5, 0) },
            { OcarinaOfTimeItemLogicPopertyName.Fairy_Slingshot, new Point(0, 1) },
            { OcarinaOfTimeItemLogicPopertyName.Ocarina, new Point(1, 1) },
            { OcarinaOfTimeItemLogicPopertyName.Bombchu, new Point(2, 1) },
            { OcarinaOfTimeItemLogicPopertyName.Hookshot, new Point(3, 1) },
            { OcarinaOfTimeItemLogicPopertyName.Ice_Arrow, new Point(4, 1) },
            { OcarinaOfTimeItemLogicPopertyName.Farore_Wind, new Point(5, 1) },
            { OcarinaOfTimeItemLogicPopertyName.Boomerang, new Point(0, 2) },
            { OcarinaOfTimeItemLogicPopertyName.Lens_of_Truth, new Point(1, 2) },
            { OcarinaOfTimeItemLogicPopertyName.Magic_Bean, new Point(2, 2) },
            { OcarinaOfTimeItemLogicPopertyName.Megaton_Hammer, new Point(3, 2) },
            { OcarinaOfTimeItemLogicPopertyName.Light_Arrow, new Point(4, 2) },
            { OcarinaOfTimeItemLogicPopertyName.Nayru_Love, new Point(5, 2) },
            { OcarinaOfTimeItemLogicPopertyName.Bottle_1, new Point(0, 3) },
            { OcarinaOfTimeItemLogicPopertyName.Bottle_2, new Point(1, 3) },
            { OcarinaOfTimeItemLogicPopertyName.Bottle_3, new Point(2, 3) },
            { OcarinaOfTimeItemLogicPopertyName.Bottle_4, new Point(3, 3) },
            { OcarinaOfTimeItemLogicPopertyName.Weird_Egg, new Point(4, 3) },
            { OcarinaOfTimeItemLogicPopertyName.Mask_Quest, new Point(5, 3) },
            { OcarinaOfTimeItemLogicPopertyName.Kokiri_Sword, new Point(0, 4) },
            { OcarinaOfTimeItemLogicPopertyName.Master_Sword, new Point(1, 4) },
            { OcarinaOfTimeItemLogicPopertyName.Giant_Knife_Biggoron_Sword, new Point(2, 4)},
            { OcarinaOfTimeItemLogicPopertyName.Stone_of_Agony, new Point(3, 4)},
            { OcarinaOfTimeItemLogicPopertyName.Gerudo_Card, new Point(4, 4)},
            { OcarinaOfTimeItemLogicPopertyName.Gold_Skulltula, new Point(5, 4) },
            { OcarinaOfTimeItemLogicPopertyName.Deku_Shield, new Point(0, 5) },
            { OcarinaOfTimeItemLogicPopertyName.Hylian_Shield, new Point(1, 5) },
            { OcarinaOfTimeItemLogicPopertyName.Mirror_Shield, new Point(2, 5) },
            { OcarinaOfTimeItemLogicPopertyName.Goron_Bracelet, new Point(3, 5) },
            { OcarinaOfTimeItemLogicPopertyName.Scale, new Point(4, 5) },
            { OcarinaOfTimeItemLogicPopertyName.Wallet, new Point(5, 5) },
            { OcarinaOfTimeItemLogicPopertyName.Kokiri_Tunic, new Point(0, 6) },
            { OcarinaOfTimeItemLogicPopertyName.Goron_Tunic, new Point(1, 6) },
            { OcarinaOfTimeItemLogicPopertyName.Zora_Tunic, new Point(2, 6) },
            { OcarinaOfTimeItemLogicPopertyName.Heart_Container, new Point(4, 6) },
            { OcarinaOfTimeItemLogicPopertyName.Magic, new Point(5, 6) },
            { OcarinaOfTimeItemLogicPopertyName.Kokiri_Boots, new Point(0, 7) },
            { OcarinaOfTimeItemLogicPopertyName.Iron_Boots, new Point(1, 7) },
            { OcarinaOfTimeItemLogicPopertyName.Hover_Boots, new Point(2, 7) },
            { OcarinaOfTimeItemLogicPopertyName.Kokiri_Emerald, new Point(3, 7) },
            { OcarinaOfTimeItemLogicPopertyName.Goron_Ruby, new Point(4, 7) },
            { OcarinaOfTimeItemLogicPopertyName.Zora_Sapphire, new Point(5, 7) },
            { OcarinaOfTimeItemLogicPopertyName.Forest_Medallion, new Point(0, 8) },
            { OcarinaOfTimeItemLogicPopertyName.Fire_Medallion, new Point(1, 8) },
            { OcarinaOfTimeItemLogicPopertyName.Water_Medallion, new Point(2, 8) },
            { OcarinaOfTimeItemLogicPopertyName.Spirit_Medallion, new Point(3, 8) },
            { OcarinaOfTimeItemLogicPopertyName.Shadow_Medallion, new Point(4, 8) },
            { OcarinaOfTimeItemLogicPopertyName.Light_Medallion, new Point(5, 8) },
            { OcarinaOfTimeItemLogicPopertyName.Minuet_of_Forest, new Point(0, 10) },
            { OcarinaOfTimeItemLogicPopertyName.Bolero_of_Fire, new Point(1, 10) },
            { OcarinaOfTimeItemLogicPopertyName.Serenade_of_Water, new Point(2, 10) },
            { OcarinaOfTimeItemLogicPopertyName.Requiem_of_Spirit, new Point(3, 10) },
            { OcarinaOfTimeItemLogicPopertyName.Nocturne_of_Shadow, new Point(4, 10) },
            { OcarinaOfTimeItemLogicPopertyName.Prelude_of_Light, new Point(5, 10) },
            { OcarinaOfTimeItemLogicPopertyName.Zelda_Lullaby, new Point(0, 9) },
            { OcarinaOfTimeItemLogicPopertyName.Epona_Song, new Point(1, 9) },
            { OcarinaOfTimeItemLogicPopertyName.Saria_Song, new Point(2, 9) },
            { OcarinaOfTimeItemLogicPopertyName.Sun_Song, new Point(3, 9) },
            { OcarinaOfTimeItemLogicPopertyName.Song_of_Time, new Point(4, 9) },
            { OcarinaOfTimeItemLogicPopertyName.Song_of_Storms, new Point(5, 9) }
    };
        
        public readonly OcarinaOfTimeLogicResolver logicResolver = 
            new OcarinaOfTimeLogicResolver(LogicFileUtils.LoadOcarinaOfTimeFromRessource());

        public readonly List<OcarinaOfTimeCheckLogicCategory> checkLogicCategories;

        private readonly Bitmap ootItem = Ressources.Properties.Resources.oot_items.ConvertToBitmap();
        private readonly Bitmap ootItemMono = Ressources.Properties.Resources.oot_items_mono.ConvertToBitmap();
        private readonly List<ItemLogic> itemLogics = ItemLogicMethod.LoadOcarinaOfTimeItemLogicFromRessource();
        private readonly List<OcarinaOfTimeCheckLogic> checkLogics;

        public OcarinaOfTimeController()
        {
            checkLogicCategories = CheckLogicCategoryUtils.LoadOcarinaOfTimeFromRessource();
            checkLogicCategories = CheckLogicCategoryUtils.LoadOcarinaOfTimeFromRessource();
            checkLogics = OcarinaOfTimeCheckLogic.FromHeader(checkLogicCategories);
            // Init max point
            foreach (var enumPropertyName in OcarinaOfTimeItemLogicPopertyNameMethod.GetAsList())
            {
                var positionOfEnum = GetPositionInDrawingOfItemLogicPropertyName(enumPropertyName);
                maxPropertyNamePosition.X = Math.Max(maxPropertyNamePosition.X, positionOfEnum.X);
                maxPropertyNamePosition.Y = Math.Max(maxPropertyNamePosition.Y, positionOfEnum.Y);
            };
        }

        protected override Bitmap GetItemSpriteMono()
        {
            return ootItemMono;
        }

        protected override Bitmap GetItemSpriteColor()
        {
            return ootItem;
        }

        protected override List<ItemLogic> GetItemLogics()
        {
            return itemLogics;
        }

        protected override List<OcarinaOfTimeCheckLogic> GetCheckLogics()
        {
            return checkLogics;
        }

        public void RefreshRegionInDrawingFollowingCheck(List<OcarinaOfTimeCheckLogic> checkLogic)
        {
            logWrite?.Invoke($"Call RefreshRegionInDrawingFollowingCheck with {checkLogic.Count} check updated");
            // Get all region to update from the list of checkLogic
            foreach (var checkCategory in checkLogic.Select((it) => it.Zone).Distinct())
            {
                logWrite?.Invoke($"Updated check for the following category: [{checkCategory}]");
                RefreshRegionInDrawingFollowingCheck(checkCategory);
            }
        }

        /// <summary>
        /// Call when change is trigger from memory
        /// </summary>
        /// <param name="listItemLogicProperty">List of updated propery with new value</param>
        public void OnItemLogicChange(List<Tuple<OcarinaOfTimeItemLogicPopertyName, object>> listItemLogicProperty)
        {
            if (itemLogics == null || checkLogics == null)
                return;
            foreach(var itemLogicProperty in listItemLogicProperty)
            {
                var strItemLogicPropertyName = OcarinaOfTimeItemLogicPopertyNameMethod.ToString(itemLogicProperty.Item1);
                foreach (var itemLogic in itemLogics)
                {
                    if (strItemLogicPropertyName == itemLogic.propertyName)
                    {
                        if (itemLogicProperty.Item2 is bool)
                        {
                            itemLogic.hasItem = (bool)itemLogicProperty.Item2;
                            itemLogic.CurrentVariant = 0;
                        }
                        else if (itemLogicProperty.Item2 is uint)
                        {
                            var itemCount = itemLogicProperty.Item2 as uint? ?? 0;
                            itemLogic.hasItem = itemCount > 0;
                            itemLogic.ItemCount = itemCount;
                        }
                        else if (itemLogicProperty.Item2 is OotItemTradingItem)
                        {
                            OotItemTradingItem ootItemTradingItem = (OotItemTradingItem)itemLogicProperty.Item2;
                            itemLogic.hasItem = ootItemTradingItem != OotItemTradingItem.ItemNone;
                            itemLogic.CurrentVariant = OotItemTradingItemMethod.ToInterfaceMappingVariant(ootItemTradingItem);
                        }
                        else if (itemLogicProperty.Item2 is OotItemMaskQuest)
                        {
                            OotItemMaskQuest ootItemMaskQuest = (OotItemMaskQuest)itemLogicProperty.Item2;
                            itemLogic.hasItem = ootItemMaskQuest != OotItemMaskQuest.ItemNone;
                            itemLogic.CurrentVariant = OotItemMaskQuestMethod.ToInterfaceMappingVariant(ootItemMaskQuest);
                        }
                        break;
                    }
                }
                // TODO: gerer les différent cas pour les enum
            }
            //logicResolver.UpdateCheckForItem(itemLogics, checkLogics, false);
            var listOfUpdatedCheck = logicResolver.UpdateCheckAndReturnListOfUpdatedCheck(itemLogics, checkLogics, false);
            RefreshRegionInDrawingFollowingCheck(listOfUpdatedCheck);
            pictureBoxItemList?.Refresh();
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
                    OcarinaOfTimeCheckLogicZoneMethod.FromString(checkLogicCategory.Name)
                );
            }
        }

        protected override Point GetPositionInDrawingOfItemLogicPropertyName(string propertyName)
        {
            return GetPositionInDrawingOfItemLogicPropertyName(OcarinaOfTimeItemLogicPopertyNameMethod.FromString(propertyName));
        }

        private Point GetPositionInDrawingOfItemLogicPropertyName(OcarinaOfTimeItemLogicPopertyName enumPropertyName)
        {
            if (mapPropertyNamePosition.TryGetValue(enumPropertyName, out var result))
                return result;
            throw new Exception($"Unknown property name: {enumPropertyName}");
        }

        protected override AbstractsonFormatLogicItem? FindLogicItemFromCheckLogic(OcarinaOfTimeCheckLogic checkLogic)
        {
            if (checkLogic.Id == null)
                return null;
            return logicResolver.FindLogicOrNull(checkLogic.Id);
        }
    }
}
