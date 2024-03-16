using MajoraAutoItemTracker.Model.Enum;
using System.Reactive.Subjects;
using System;
using System.Collections.Generic;

namespace MajoraAutoItemTracker.MemoryReader.MemoryData
{

    class MajoraMemoryData : AbstractMemoryData<MajoraMaskItemLogicPopertyName>
    {
        public Dictionary<MajoraMaskItemLogicPopertyName, object> mapPropertyNameAny = new Dictionary<MajoraMaskItemLogicPopertyName, object>()
        {
            { MajoraMaskItemLogicPopertyName.ImgMagic , MagicMeter.None },
            { MajoraMaskItemLogicPopertyName.ImgDoubleDefense, false },
            { MajoraMaskItemLogicPopertyName.ImgWallet, EquipmentWallet.Child },
            { MajoraMaskItemLogicPopertyName.ImgQuiver, EquipmentQuiver.None },
            { MajoraMaskItemLogicPopertyName.ImgBombBag, EquipmentBombBag.None },
            { MajoraMaskItemLogicPopertyName.ImgBombersNote, false },
            { MajoraMaskItemLogicPopertyName.ImgOcarina, false },
            { MajoraMaskItemLogicPopertyName.ImgBow, false },
            { MajoraMaskItemLogicPopertyName.ImgFireArrow, false },
            { MajoraMaskItemLogicPopertyName.ImgIceArrow, false },
            { MajoraMaskItemLogicPopertyName.ImgLightArrow, false },
            { MajoraMaskItemLogicPopertyName.ImgBomb, false },
            { MajoraMaskItemLogicPopertyName.ImgBombchu, false },
            { MajoraMaskItemLogicPopertyName.ImgStick, false },
            { MajoraMaskItemLogicPopertyName.ImgNuts, false },
            { MajoraMaskItemLogicPopertyName.ImgBeans, false },
            { MajoraMaskItemLogicPopertyName.ImgKeg, false },
            { MajoraMaskItemLogicPopertyName.ImgPicto, false },
            { MajoraMaskItemLogicPopertyName.ImgLens, false },
            { MajoraMaskItemLogicPopertyName.ImgHook, false },
            { MajoraMaskItemLogicPopertyName.ImgGfsword, false }, // TODO Gerer great fairy sword
            { MajoraMaskItemLogicPopertyName.ImgScrubTrade, false }, // TODO add enum for trading item
            { MajoraMaskItemLogicPopertyName.ImgKeyMama, false }, // TODO add enum for trading item
            { MajoraMaskItemLogicPopertyName.ImgLetterpendant, false }, // TODO add enum for trading item
            { MajoraMaskItemLogicPopertyName.Imgbottle1, false }, // TODO add enum for bootle
            { MajoraMaskItemLogicPopertyName.Imgbottle2, false }, // TODO add enum for bootle
            { MajoraMaskItemLogicPopertyName.Imgbottle3, false }, // TODO add enum for bootle
            { MajoraMaskItemLogicPopertyName.Imgbottle4, false }, // TODO add enum for bootle
            { MajoraMaskItemLogicPopertyName.Imgbottle5, false }, // TODO add enum for bootle
            { MajoraMaskItemLogicPopertyName.Imgbottle6, false }, // TODO add enum for bootle
            { MajoraMaskItemLogicPopertyName.DekuMask, false },
            { MajoraMaskItemLogicPopertyName.GoronMask, false },
            { MajoraMaskItemLogicPopertyName.ZoraMask, false },
            { MajoraMaskItemLogicPopertyName.FiercedeityMask, false },
            { MajoraMaskItemLogicPopertyName.PostmanMask, false },
            { MajoraMaskItemLogicPopertyName.AllnightMask, false },
            { MajoraMaskItemLogicPopertyName.BlastMask, false },
            { MajoraMaskItemLogicPopertyName.StoneMask, false },
            { MajoraMaskItemLogicPopertyName.GreatfairyMask, false },
            { MajoraMaskItemLogicPopertyName.KeatonMask, false },
            { MajoraMaskItemLogicPopertyName.BremenMask, false },
            { MajoraMaskItemLogicPopertyName.BunnyhoodMask, false },
            { MajoraMaskItemLogicPopertyName.DonGeroMask, false },
            { MajoraMaskItemLogicPopertyName.ScentsMask, false },
            { MajoraMaskItemLogicPopertyName.RomaniMask, false },
            { MajoraMaskItemLogicPopertyName.CircusleaderMask, false },
            { MajoraMaskItemLogicPopertyName.KafeiMask, false },
            { MajoraMaskItemLogicPopertyName.CoupleMask, false },
            { MajoraMaskItemLogicPopertyName.TruthMask, false },
            { MajoraMaskItemLogicPopertyName.KamaroMask, false },
            { MajoraMaskItemLogicPopertyName.GibdoMask, false },
            { MajoraMaskItemLogicPopertyName.GaroMask, false },
            { MajoraMaskItemLogicPopertyName.CaptainMask, false },
            { MajoraMaskItemLogicPopertyName.GiantMask, false },
            { MajoraMaskItemLogicPopertyName.SongOfTime, false },
            { MajoraMaskItemLogicPopertyName.SongOfHealing, false },
            { MajoraMaskItemLogicPopertyName.EponaSong, false },
            { MajoraMaskItemLogicPopertyName.SongOfSoaring, false },
            { MajoraMaskItemLogicPopertyName.SongOfStorm, false },
            { MajoraMaskItemLogicPopertyName.SonataOfAwakening, false },
            { MajoraMaskItemLogicPopertyName.GoronLullaby, false },
            { MajoraMaskItemLogicPopertyName.NewWaveBossaNova, false },
            { MajoraMaskItemLogicPopertyName.ElegyOfEmptyness, false },
            { MajoraMaskItemLogicPopertyName.SongOathToOrder, false },
            { MajoraMaskItemLogicPopertyName.SunSong, false },
            { MajoraMaskItemLogicPopertyName.OdolwaMask, false },
            { MajoraMaskItemLogicPopertyName.GohtMask, false },
            { MajoraMaskItemLogicPopertyName.GyorgMask, false },
            { MajoraMaskItemLogicPopertyName.TwinmoldMask, false },
            //{ MajoraMaskItemLogicPopertyName., LinkTransformation.Human }
        };

        public override Dictionary<MajoraMaskItemLogicPopertyName, object> GetMemoryDataMap()
        {
            return mapPropertyNameAny;
        }

        public override void ReadDataFromEmulator(AbstractRomController emulatorWrapper)
        {
            // Link
            // FIXME: MagicMeter = MagicMeterMethod.ReadFromMemory(emulatorWrapper.ReadUint8InEdianSizeAsInt(MMOffsets.CST_LINKG_MAGIC_METER));
            //var bDoubleDefense = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_LINKG_DOUBLE_DEFENSE);
            //HasDoubleDefense = (bDoubleDefense[0] & 00010020) != bDoubleDefense[0];

            // Inventory Equipment
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgWallet] = EquipmentWalletMethod
                .ReadFromMemory(emulatorWrapper.ReadUint8InEdianSizeAsInt(MMOffsets.CST_INVENTORY_EQUIPEMENT_WALLET));

            // INVENTORY C-Button Items
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgOcarina] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_OCARINA);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgBow] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_HERO_BOW);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgIceArrow] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_ICE_ARROWS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgLightArrow] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_LIGHT_ARROWS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgFireArrow] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_FIRE_ARROWS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgBomb] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOMB);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgBombchu] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOMBCHUS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgStick] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_DEKU_STICKS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgNuts] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_DEKU_NUTS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgBeans] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_MAGIC_BEANS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgKeg] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_POWDER_KEG);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgPicto] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_PICTOGRAPH_BOX);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgLens] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_LENS_OF_TRUTH);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgHook] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_HOOKSHOT);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgGfsword] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_GREAT_FAIRY_SWORD);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgScrubTrade] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_TRADING_ITEM_1);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgKeyMama] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_TRADING_ITEM_2);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgLetterpendant] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_TRADING_ITEM_3);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.Imgbottle1] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_1);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.Imgbottle2] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_2);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.Imgbottle3] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_3);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.Imgbottle4] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_4);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.Imgbottle5] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_5);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.Imgbottle6] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_6);
            // INVENTORY Masks
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.DekuMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_DEKU_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.GoronMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_GORON_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ZoraMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_ZORA_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.FiercedeityMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_FIERCE_DEITY_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.PostmanMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_POSTMAN_HAT);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.AllnightMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_ALL_NIGHT_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.BlastMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_BLAST_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.StoneMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_STONE_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.GreatfairyMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_GREAT_FAIRY_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.KeatonMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_KEATON_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.BremenMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_BREMEN_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.BunnyhoodMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_BUNNY_HOOD);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.DonGeroMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_DON_GERO_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ScentsMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_MASK_OF_SCENTS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.RomaniMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_ROMANI_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.CircusleaderMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_CIRCUS_LEADER_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.KafeiMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_KAFEI_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.CoupleMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_COUPLE_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.TruthMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_MASK_OF_TRUTH);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.KamaroMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_KAMARO_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.GibdoMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_GIBDO_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.GaroMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_GARO_MASK);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.CaptainMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_CAPTAIN_HAT);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.GiantMask] = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_GIANT_MASK);
            // INVENTORY Quest Items //FIXME: C'est de la merde

            var valueQuiverAndBombBag = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_INVENTORY_ADDRESS_QUIVER_BOMB_BAG);
            var valueLulabyIntroAndHearthPieces = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_INVENTORY_ADDRESS_LULLABY_INTRO_AND_HEART_PIECES);
            var valueSongAndBomberNotebook = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_INVENTORY_ADDRESS_SONG_AND_BOMBER_NOTEBOOK);
            var valuePartialSong = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_INVENTORY_ADDRESS_PARTIAL_SONG);
            var valueSongAndRemains = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_INVENTORY_ADDRESS_SONG_AND_REMAINS);

            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgQuiver] = EquipmentQuiverMethod.ReadFromMemory(valueQuiverAndBombBag);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgBombBag] = EquipmentBombBagMethod.ReadFromMemory(valueQuiverAndBombBag);

            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ImgBombersNote] = emulatorWrapper.CheckBitRaise(valueSongAndBomberNotebook, MMOffsets.CST_INVENTORY_VALUE_BOMBER_NOTEBOOK);

            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.SongOfTime] = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_OF_TIME);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.SongOfHealing] = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_OF_HEALING);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.EponaSong] = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_EPONA_SONG);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.SongOfSoaring] = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_OF_SOARING);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.SongOfStorm] = emulatorWrapper.CheckBitRaise(valueSongAndBomberNotebook, MMOffsets.CST_INVENTORY_VALUE_SONG_OF_STORMS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.SonataOfAwakening] = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_SONG_SONATA_OF_AWAKENING);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.GoronLullaby] = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_SONG_GORON_LULLABY);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.NewWaveBossaNova] = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_NEW_WAVE_BOSSA_NOVA);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ElegyOfEmptyness] = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_ELEGY_OF_EMPTINESS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.SongOathToOrder] = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_OATH_TO_ORDER);
            //Does not exist in MM: emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_SARIA_SONG);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.SunSong] = emulatorWrapper.CheckBitRaise(valueSongAndBomberNotebook, MMOffsets.CST_INVENTORY_VALUE_SUN_SONG);
            // Boss Masks

            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.OdolwaMask] = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_ODOLWA_REMAINS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.GohtMask] = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_GOHT_REMAINS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.GyorgMask] = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_GYORG_REMAINS);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.TwinmoldMask] = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_TWINMODL_REMAINS);

            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ItemSkulltulaSwampSpiderHouseCount] = emulatorWrapper.ReadUint8InEdianSizeAsInt(MMOffsets.CST_SKULLTULA_SWAMP_SPIDER_HOUSE_COUNT);
            mapPropertyNameAny[MajoraMaskItemLogicPopertyName.ItemSkulltulaOceanSideSouderHouseCount] = emulatorWrapper.ReadUint8InEdianSizeAsInt(MMOffsets.CST_SKULLTULA_OCEANSIDE_SPIDER_HOUSE_COUNT);

            // Other
            // FIXME: CurrentLinkTransformation = LinkTransformationMethods.ReadFromMemory(emulatorWrapper.ReadUint8InEdianSizeAsInt(MMOffsets.CURRENT_TRANSFORMATION));
        }
    }
}
