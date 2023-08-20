using MajoraAutoItemTracker.Model.Enum;
using System.Reactive.Subjects;
using System;

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
        public bool HasSunSong = false;

        public bool HasBossMaskOdolwa = false;
        public bool HasBoosMaskGoht = false;
        public bool HasBoosMaskGyorg = false;
        public bool HasBoosMaskTwinmold = false;
        #endregion
        
        #region Other
        public LinkTransformation CurrentLinkTransformation = LinkTransformation.Human;
        #endregion

        public override void ReadDataFromEmulator(AbstractRomController emulatorWrapper)
        {
            // Link
            // FIXME: MagicMeter = MagicMeterMethod.ReadFromMemory(emulatorWrapper.ReadUint8InEdianSizeAsInt(MMOffsets.CST_LINKG_MAGIC_METER));
            //var bDoubleDefense = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_LINKG_DOUBLE_DEFENSE);
            //HasDoubleDefense = (bDoubleDefense[0] & 00010020) != bDoubleDefense[0];

            // Inventory Equipment
            // FIXME: EquipmentWallet = EquipmentWalletMethod.ReadFromMemory(emulatorWrapper.ReadUint8InEdianSizeAsInt(MMOffsets.CST_INVENTORY_EQUIPEMENT_WALLET));

            // INVENTORY C-Button Items
            HasOcarina = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_OCARINA);
            HasHeroBow = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_HERO_BOW);
            HasHeroBow = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_HERO_BOW);
            HasIceArrows = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_ICE_ARROWS);
            HasLightArrows = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_LIGHT_ARROWS);
            HasBomb = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOMB);
            HasBombchus = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOMBCHUS);
            HasDekuSticks = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_DEKU_STICKS);
            HasDekuNuts = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_DEKU_NUTS);
            HasMagicBeans = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_MAGIC_BEANS);
            HasPowderKeg = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_POWDER_KEG);
            HasPictographBox = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_PICTOGRAPH_BOX);
            HasLensOfTruth = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_LENS_OF_TRUTH);
            HasHookShot = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_HOOKSHOT);
            HasGreatFairySword = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_GREAT_FAIRY_SWORD);
            HasTradingItem1 = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_TRADING_ITEM_1);
            HasTradingItem2 = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_TRADING_ITEM_2);
            HasTradingItem3 = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_TRADING_ITEM_3);
            HasBootle1 = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_1);
            HasBootle2 = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_2);
            HasBootle3 = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_3);
            HasBootle4 = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_4);
            HasBootle5 = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_5);
            HasBootle6 = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_INVENTORY_BOTTLE_6);
            // INVENTORY Masks
            HasDekuMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_DEKU_MASK);
            HasGoronMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_GORON_MASK);
            HasZoraMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_ZORA_MASK);
            HasFierceDeityMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_FIERCE_DEITY_MASK);
            HasPostmanHat = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_POSTMAN_HAT);
            HasAllNightMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_ALL_NIGHT_MASK);
            HasBlastMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_BLAST_MASK);
            HasStoneMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_STONE_MASK);
            HasGreatFairyMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_GREAT_FAIRY_MASK);
            HasKeatonMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_KEATON_MASK);
            HasBremenMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_BREMEN_MASK);
            HasBunnyHood = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_BUNNY_HOOD);
            HasDonGeroMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_DON_GERO_MASK);
            HasMaskOfScents = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_MASK_OF_SCENTS);
            HasRomaniMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_ROMANI_MASK);
            HasCircusLeaderMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_CIRCUS_LEADER_MASK);
            HasKaefiMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_KAFEI_MASK);
            HasCoupleMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_COUPLE_MASK);
            HasMaskOfTruth = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_MASK_OF_TRUTH);
            HasKamaroMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_KAMARO_MASK);
            HasGibdoMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_GIBDO_MASK);
            HasGaroMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_GARO_MASK);
            HasCaptainHat = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_CAPTAIN_HAT);
            HasGiantMask = emulatorWrapper.CheckIsNotFF(MMOffsets.CST_MASK_GIANT_MASK);
            // INVENTORY Quest Items //FIXME: C'est de la merde

            var valueQuiverAndBombBag = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_INVENTORY_ADDRESS_QUIVER_BOMB_BAG);
            var valueLulabyIntroAndHearthPieces = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_INVENTORY_ADDRESS_LULLABY_INTRO_AND_HEART_PIECES);
            var valueSongAndBomberNotebook = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_INVENTORY_ADDRESS_SONG_AND_BOMBER_NOTEBOOK);
            var valuePartialSong = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_INVENTORY_ADDRESS_PARTIAL_SONG);
            var valueSongAndRemains = emulatorWrapper.ReadUint8InEdianSizeAsByte(MMOffsets.CST_INVENTORY_ADDRESS_SONG_AND_REMAINS);

            EquipmentQuiver = EquipmentQuiverMethod.ReadFromMemory(valueQuiverAndBombBag);
            EquipmentBombBag = EquipmentBombBagMethod.ReadFromMemory(valueQuiverAndBombBag);

            HasBombersNoteBook = emulatorWrapper.CheckBitRaise(valueSongAndBomberNotebook, MMOffsets.CST_INVENTORY_VALUE_BOMBER_NOTEBOOK);

            HasSongOfTime = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_OF_TIME);
            HasSongOfHealing = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_OF_HEALING);
            HasEponaSong = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_EPONA_SONG);
            HasSongOfSoaring = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_OF_SOARING);
            HasSongOfStorm = emulatorWrapper.CheckBitRaise(valueSongAndBomberNotebook, MMOffsets.CST_INVENTORY_VALUE_SONG_OF_STORMS);
            HasSonataOfAwakening = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_SONG_SONATA_OF_AWAKENING);
            HasGoronLullaby = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_SONG_GORON_LULLABY);
            HasNewWaveBossaNova = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_NEW_WAVE_BOSSA_NOVA);
            HasElegyOfEmptyness = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_ELEGY_OF_EMPTINESS);
            HasSongOathToORder = emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_OATH_TO_ORDER);
            //Does not exist in MM: emulatorWrapper.CheckBitRaise(valuePartialSong, MMOffsets.CST_INVENTORY_VALUE_SONG_SARIA_SONG);
            HasSunSong = emulatorWrapper.CheckBitRaise(valueSongAndBomberNotebook, MMOffsets.CST_INVENTORY_VALUE_SUN_SONG);
            // Boss Masks

            HasBossMaskOdolwa = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_ODOLWA_REMAINS);
            HasBoosMaskGoht = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_GOHT_REMAINS);
            HasBoosMaskGyorg = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_GYORG_REMAINS);
            HasBoosMaskTwinmold = emulatorWrapper.CheckBitRaise(valueSongAndRemains, MMOffsets.CST_INVENTORY_VALUE_TWINMODL_REMAINS);

            // Other
            // FIXME: CurrentLinkTransformation = LinkTransformationMethods.ReadFromMemory(emulatorWrapper.ReadUint8InEdianSizeAsInt(MMOffsets.CURRENT_TRANSFORMATION));
        }
    }

    class MajoraMemoryDataObserver : AbstractMemoryDataObserver<MajoraMaskItemLogicPopertyName>
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
        public ReplaySubject<bool> HasSunSong = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBossMaskOdolwa = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBoosMaskGoht = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBoosMaskGyorg = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBoosMaskTwinmold = new ReplaySubject<bool>(1);
        #endregion

        public override void BindAllEvent(Action<Tuple<MajoraMaskItemLogicPopertyName, object>> replaySubject)
        {
            //observer.CurrentLinkTransformation.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName., value)));
            MagicMeter.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgMagic, value)));
            HasDoubleDefense.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgDoubleDefense, value)));
            EquipmentWallet.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgWallet, value)));
            EquipmentQuiver.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgQuiver, value)));
            EquipmentBombBag.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBombBag, value)));
            HasBombersNoteBook.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBombersNote, value)));
            HasOcarina.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgOcarina, value)));
            HasHeroBow.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBow, value)));
            HasFireArrows.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgFireArrow, value)));
            HasIceArrows.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgIceArrow, value)));
            HasLightArrows.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgLightArrow, value)));
            HasBomb.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBombBag, value)));
            HasBombchus.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBombchu, value)));
            HasDekuSticks.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgStick, value)));
            HasDekuNuts.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgNuts, value)));
            HasMagicBeans.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgBeans, value)));
            HasPowderKeg.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgKeg, value)));
            HasPictographBox.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgPicto, value)));
            HasLensOfTruth.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgLens, value)));
            HasHookShot.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgHook, value)));
            HasGreatFairySword.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgGfsword, value)));
            HasTradingItem1.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgScrubTrade, value)));
            HasTradingItem2.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgKeyMama, value)));
            HasTradingItem3.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgLetterpendant, value)));
            HasBootle1.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle1, value)));
            HasBootle2.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle2, value)));
            HasBootle3.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle3, value)));
            HasBootle4.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle4, value)));
            HasBootle5.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle5, value)));
            HasBootle6.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.Imgbottle6, value)));
            
            HasDekuMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.DekuMask, value)));
            HasGoronMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GoronMask, value)));
            HasZoraMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ZoraMask, value)));
            HasFierceDeityMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.FiercedeityMask, value)));
            
            HasPostmanHat.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.PostmanMask, value)));
            HasAllNightMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.AllnightMask, value)));
            HasBlastMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.BlastMask, value)));
            HasStoneMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.StoneMask, value)));
            HasGreatFairyMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GreatfairyMask, value)));
            HasKeatonMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.KeatonMask, value)));
            HasBremenMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.BremenMask, value)));
            HasBunnyHood.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.BunnyhoodMask, value)));
            HasDonGeroMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.DonGeroMask, value)));
            HasMaskOfScents.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ScentsMask, value)));
            HasRomaniMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.RomaniMask, value)));
            HasCircusLeaderMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.CircusleaderMask, value)));
            HasKaefiMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.KafeiMask, value)));
            HasCoupleMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.CoupleMask, value)));
            HasMaskOfTruth.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.TruthMask, value)));
            HasKamaroMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.KamaroMask, value)));
            HasGibdoMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GibdoMask, value)));
            HasGaroMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GaroMask, value)));
            HasCaptainHat.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.CaptainMask, value)));
            HasGiantMask.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GiantMask, value)));
            
            HasSongOfTime.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.SongOfTime, value)));
            HasSongOfHealing.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.SongOfHealing, value)));
            HasEponaSong.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.EponaSong, value)));
            HasSongOfSoaring.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.SongOfSoaring, value)));
            HasSongOfStorm.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.SongOfStorm, value)));
            HasSonataOfAwakening.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.SonataOfAwakening, value)));
            HasGoronLullaby.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GoronLullaby, value)));
            HasNewWaveBossaNova.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.NewWaveBossaNova, value)));
            HasElegyOfEmptyness.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ElegyOfEmptyness, value)));
            HasSongOathToORder.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.SongOathToOrder, value)));
            HasSunSong.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.SunSong, value)));

            HasBossMaskOdolwa.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.OdolwaMask, value)));
            HasBoosMaskGoht.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GohtMask, value)));
            HasBoosMaskGyorg.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.GyorgMask, value)));
            HasBoosMaskTwinmold.Subscribe(value => replaySubject(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.TwinmoldMask, value)));
        }

    }
}
