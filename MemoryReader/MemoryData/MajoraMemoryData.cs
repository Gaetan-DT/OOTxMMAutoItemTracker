using MajoraAutoItemTracker.Model.Enum;
using System.Reactive.Subjects;
using MajoraAutoItemTracker.MemoryReader.ModLoader64;

namespace MajoraAutoItemTracker.MemoryReader.MemoryData
{

    class MajoraMemoryData : AbstractMemoryData
    {
        #region Link
        public MagicMeter MagicMeter = MagicMeter.None;
        public bool HasDoubleDefense = false;
        #endregion

        #region Inventory Equipement
        public EquipmentWallet EquipmentWallet = Model.Enum.EquipmentWallet.Child;
        public EquipmentQuiver EquipmentQuiver = Model.Enum.EquipmentQuiver.None;
        public EquipmentBombBag EquipmentBombBag = Model.Enum.EquipmentBombBag.None;
        public bool HasBombersNoteBook = false;
        #endregion

        #region INVENTORY C-Button Items
        public bool HasOcarina = false;
        public bool HasHeroBow = false;
        public bool HasFireArrows = false;
        public bool HasIceArrows = false;
        public bool HasLightArrows = false;
        public bool HasBomb = false;
        public bool HasBombchus = false;
        public bool HasDekuSticks = false;
        public bool HasDekuNuts = false;
        public bool HasMagicBeans = false;
        public bool HasPowderKeg = false;
        public bool HasPictographBox = false;
        public bool HasLensOfTruth = false;
        public bool HasHookShot = false;
        public bool HasGreatFairySword = false;
        public bool HasTradingItem1 = false; // TODO add enum for trading item
        public bool HasTradingItem2 = false; // TODO add enum for trading item
        public bool HasTradingItem3 = false; // TODO add enum for trading item
        public bool HasBootle1 = false; // TODO add enum for bootle
        public bool HasBootle2 = false; // TODO add enum for bootle
        public bool HasBootle3 = false; // TODO add enum for bootle
        public bool HasBootle4 = false; // TODO add enum for bootle
        public bool HasBootle5 = false; // TODO add enum for bootle
        public bool HasBootle6 = false; // TODO add enum for bootle
        #endregion
        
        #region INVENTORY Masks
        public bool HasDekuMask = false;
        public bool HasGoronMask = false;
        public bool HasZoraMask = false;
        public bool HasFierceDeityMask = false;
        public bool HasPostmanHat = false;
        public bool HasAllNightMask = false;
        public bool HasBlastMask = false;
        public bool HasStoneMask = false;
        public bool HasGreatFairyMask = false;
        public bool HasKeatonMask = false;
        public bool HasBremenMask = false;
        public bool HasBunnyHood = false;
        public bool HasDonGeroMask = false;
        public bool HasMaskOfScents = false;
        public bool HasRomaniMask = false;
        public bool HasCircusLeaderMask = false;
        public bool HasKaefiMask = false;
        public bool HasCoupleMask = false;
        public bool HasMaskOfTruth = false;
        public bool HasKamaroMask = false;
        public bool HasGibdoMask = false;
        public bool HasGaroMask = false;
        public bool HasCaptainHat = false;
        public bool HasGiantMask = false;
        #endregion

        #region INVENTORY Quest Items
        public bool HasSongOfTime = false;
        public bool HasSongOfHealing = false;
        public bool HasEponaSong = false;
        public bool HasSongOfSoaring = false;
        public bool HasSongOfStorm = false;
        public bool HasSonataOfAwakening = false;
        public bool HasGoronLullaby = false;
        public bool HasNewWaveBossaNova = false;
        public bool HasElegyOfEmptyness = false;
        public bool HasSongOathToORder = false;
        public bool HasBossMaskOdolwa = false;
        public bool HasBoosMaskGoht = false;
        public bool HasBoosMaskGyorg = false;
        public bool HasBoosMaskTwinmold = false;
        #endregion
        
        #region Other
        public LinkTransformation CurrentLinkTransformation = LinkTransformation.Human;
        #endregion

        public MajoraMemoryData(ModLoader64Wrapper modLoader)
        {
            // Link
            MagicMeter = MagicMeterMethod.ReadFromMemory(modLoader.readInt8(MMOffsets.CST_LINKG_MAGIC_METER));
            var bDoubleDefense = modLoader.readByte(MMOffsets.CST_LINKG_DOUBLE_DEFENSE, 8);
            HasDoubleDefense = (bDoubleDefense[0] & 00010020) != bDoubleDefense[0];

            // Inventory Equipment
            EquipmentWallet = EquipmentWalletMethod.ReadFromMemory(modLoader.readInt8(MMOffsets.CST_INVENTORY_EQUIPEMENT_WALLET));
            HasBombersNoteBook = modLoader.CheckHexRaised(MMOffsets.CST_INVENTORY_EQUIPEMENT_BOMBERS_NOTEBOOK, 2);
            var byteQuiverAndBombBag = modLoader.readByte(MMOffsets.CST_INVENTORY_EQUIPEMENT_QUIVER_BOMBBAG, 1)[0];
            EquipmentQuiver = EquipmentQuiverMethod.ReadFromMemory(byteQuiverAndBombBag);
            EquipmentBombBag = EquipmentBombBagMethod.ReadFromMemory(byteQuiverAndBombBag);

            // INVENTORY C-Button Items
            HasOcarina = modLoader.ReadItem(MMOffsets.CST_INVENTORY_OCARINA, 0x00);
            HasHeroBow = modLoader.ReadItem(MMOffsets.CST_INVENTORY_HERO_BOW, 0x01);
            //
            HasHeroBow = modLoader.ReadItem(MMOffsets.CST_INVENTORY_FIRE_ARROWS, 0x02);
            HasIceArrows = modLoader.ReadItem(MMOffsets.CST_INVENTORY_ICE_ARROWS, 0x03);
            HasLightArrows = modLoader.ReadItem(MMOffsets.CST_INVENTORY_LIGHT_ARROWS, 0x04);
            HasBomb = modLoader.ReadItem(MMOffsets.CST_INVENTORY_BOMB, 0x06);
            HasBombchus = modLoader.ReadItem(MMOffsets.CST_INVENTORY_BOMBCHUS, 0x07);
            HasDekuSticks = modLoader.ReadItem(MMOffsets.CST_INVENTORY_DEKU_STICKS, 0x08);
            HasDekuNuts = modLoader.ReadItem(MMOffsets.CST_INVENTORY_DEKU_NUTS, 0x09);
            HasMagicBeans = modLoader.ReadItem(MMOffsets.CST_INVENTORY_MAGIC_BEANS, 0x0A);
            HasPowderKeg = modLoader.ReadItem(MMOffsets.CST_INVENTORY_POWDER_KEG, 0x0C);
            HasPictographBox = modLoader.ReadItem(MMOffsets.CST_INVENTORY_PICTOGRAPH_BOX, 0x0D);
            HasLensOfTruth = modLoader.ReadItem(MMOffsets.CST_INVENTORY_LENS_OF_TRUTH, 0x0E);
            HasHookShot = modLoader.ReadItem(MMOffsets.CST_INVENTORY_HOOKSHOT, 0x0F);
            HasGreatFairySword = modLoader.ReadItem(MMOffsets.CST_INVENTORY_GREAT_FAIRY_SWORD, 0x10);
            HasTradingItem1 = modLoader.ReadNotFF(MMOffsets.CST_INVENTORY_TRADING_ITEM_1);
            HasTradingItem2 = modLoader.ReadNotFF(MMOffsets.CST_INVENTORY_TRADING_ITEM_2);
            HasTradingItem3 = modLoader.ReadNotFF(MMOffsets.CST_INVENTORY_TRADING_ITEM_3);
            HasBootle1 = modLoader.ReadNotFF(MMOffsets.CST_INVENTORY_BOTTLE_1);
            HasBootle2 = modLoader.ReadNotFF(MMOffsets.CST_INVENTORY_BOTTLE_2);
            HasBootle3 = modLoader.ReadNotFF(MMOffsets.CST_INVENTORY_BOTTLE_3);
            HasBootle4 = modLoader.ReadNotFF(MMOffsets.CST_INVENTORY_BOTTLE_4);
            HasBootle5 = modLoader.ReadNotFF(MMOffsets.CST_INVENTORY_BOTTLE_5);
            HasBootle6 = modLoader.ReadNotFF(MMOffsets.CST_INVENTORY_BOTTLE_6);
            // INVENTORY Masks
            HasDekuMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_DEKU_MASK);
            HasGoronMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_GORON_MASK);
            HasZoraMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_ZORA_MASK);
            HasFierceDeityMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_FIERCE_DEITY_MASK);
            HasPostmanHat = modLoader.ReadNotFF(MMOffsets.CST_MASK_POSTMAN_HAT);
            HasAllNightMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_ALL_NIGHT_MASK);
            HasBlastMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_BLAST_MASK);
            HasStoneMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_STONE_MASK);
            HasGreatFairyMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_GREAT_FAIRY_MASK);
            HasKeatonMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_KEATON_MASK);
            HasBremenMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_BREMEN_MASK);
            HasBunnyHood = modLoader.ReadNotFF(MMOffsets.CST_MASK_BUNNY_HOOD);
            HasDonGeroMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_DON_GERO_MASK);
            HasMaskOfScents = modLoader.ReadNotFF(MMOffsets.CST_MASK_MASK_OF_SCENTS);
            HasRomaniMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_ROMANI_MASK);
            HasCircusLeaderMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_CIRCUS_LEADER_MASK);
            HasKaefiMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_KAFEI_MASK);
            HasCoupleMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_COUPLE_MASK);
            HasMaskOfTruth = modLoader.ReadNotFF(MMOffsets.CST_MASK_MASK_OF_TRUTH);
            HasKamaroMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_KAMARO_MASK);
            HasGibdoMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_GIBDO_MASK);
            HasGaroMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_GARO_MASK);
            HasCaptainHat = modLoader.ReadNotFF(MMOffsets.CST_MASK_CAPTAIN_HAT);
            HasGiantMask = modLoader.ReadNotFF(MMOffsets.CST_MASK_GIANT_MASK);
            // INVENTORY Quest Items
            HasSongOfTime = modLoader.CheckHexRaised(MMOffsets.CST_SONG_SONG_OF_TIME, 4);
            HasSongOfHealing = modLoader.CheckHexRaised(MMOffsets.CST_SONG_SONG_OF_HEALING, 5);
            HasEponaSong = modLoader.CheckHexRaised(MMOffsets.CST_SONG_EPONA_SONG, 6);
            HasSongOfSoaring = modLoader.CheckHexRaised(MMOffsets.CST_SONG_SONG_OF_SOARING, 7);
            HasSongOfStorm = modLoader.CheckHexRaised(MMOffsets.CST_SONG_SONG_OF_STORMS, 0);
            HasSonataOfAwakening = modLoader.CheckHexRaised(MMOffsets.CST_SONG_SONATA_OF_AWAKENING, 6);
            HasGoronLullaby = modLoader.CheckHexRaised(MMOffsets.CST_SONG_GORON_LULLABY_INTRO, 0);
            HasNewWaveBossaNova = modLoader.CheckHexRaised(MMOffsets.CST_SONG_NEW_WAVE_BOSSA_NOVA, 0);
            HasElegyOfEmptyness = modLoader.CheckHexRaised(MMOffsets.CST_SONG_ELEGY_OF_EMPTYNESS, 1);
            HasSongOathToORder = modLoader.CheckHexRaised(MMOffsets.CST_SONG_OATH_TO_ORDER, 2);
            // Boss Masks
            var bossMask = modLoader.readByte(MMOffsets.CST_BOSS_MASK, 1)[0];
            HasBossMaskOdolwa = (bossMask & (1 << 0)) != 0;
            HasBoosMaskGoht = (bossMask & (1 << 1)) != 0;
            HasBoosMaskGyorg = (bossMask & (1 << 2)) != 0;
            HasBoosMaskTwinmold = (bossMask & (1 << 3)) != 0;

            // Other
            CurrentLinkTransformation = LinkTransformationMethods.ReadFromMemory(modLoader.readInt8(MMOffsets.CURRENT_TRANSFORMATION));
        }

        public override void ReadDataFromEmulator(AbstractEmulatorWrapper emulatorWrapper)
        {
            throw new System.NotImplementedException();
        }
    }

    class MajoraMemoryDataObserver
    { 
        #region Other
        // ReplaySubject<>
        public ReplaySubject<LinkTransformation> CurrentLinkTransformation = new ReplaySubject<LinkTransformation>(1);
        #endregion

        #region Link
        public ReplaySubject<MagicMeter> MagicMeter = new ReplaySubject<MagicMeter>(1);
        public ReplaySubject<bool> HasDoubleDefense = new ReplaySubject<bool>(1);
        #endregion

        #region Inventory Equipement
        public ReplaySubject<EquipmentWallet> EquipmentWallet = new ReplaySubject<EquipmentWallet>(1);
        public ReplaySubject<EquipmentQuiver> EquipmentQuiver = new ReplaySubject<EquipmentQuiver>(1);
        public ReplaySubject<EquipmentBombBag> EquipmentBombBag = new ReplaySubject<EquipmentBombBag>(1);
        public ReplaySubject<bool> HasBombersNoteBook = new ReplaySubject<bool>(1);
        #endregion

        #region INVENTORY C-Button Items
        public ReplaySubject<bool> HasOcarina = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasHeroBow = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasFireArrows = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasIceArrows = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasLightArrows = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBomb = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBombchus = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasDekuSticks = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasDekuNuts = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasMagicBeans = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasPowderKeg = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasPictographBox = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasLensOfTruth = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasHookShot = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGreatFairySword = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasTradingItem1 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasTradingItem2 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasTradingItem3 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBootle1 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBootle2 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBootle3 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBootle4 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBootle5 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBootle6 = new ReplaySubject<bool>(1);
        #endregion

        #region INVENTORY Masks
        public ReplaySubject<bool> HasDekuMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGoronMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasZoraMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasFierceDeityMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasPostmanHat = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasAllNightMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBlastMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasStoneMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGreatFairyMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasKeatonMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBremenMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBunnyHood = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasDonGeroMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasMaskOfScents = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasRomaniMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasCircusLeaderMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasKaefiMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasCoupleMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasMaskOfTruth = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasKamaroMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGibdoMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGaroMask = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasCaptainHat = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGiantMask = new ReplaySubject<bool>(1);
        #endregion
        
        #region INVENTORY Quest Items
        public ReplaySubject<bool> HasSongOfTime = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSongOfHealing = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasEponaSong = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSongOfSoaring = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSongOfStorm = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSonataOfAwakening = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGoronLullaby = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasNewWaveBossaNova = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasElegyOfEmptyness = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSongOathToORder = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBossMaskOdolwa = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBoosMaskGoht = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBoosMaskGyorg = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBoosMaskTwinmold = new ReplaySubject<bool>(1);
        #endregion


    }
}
