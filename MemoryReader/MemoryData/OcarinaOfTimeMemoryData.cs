using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;
using System;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.MemoryReader.MemoryData
{
    class OcarinaOfTimeMemoryData : AbstractMemoryData
    {

        #region INVENTORY C-Button Items

        public bool HasDekuStick = false;
        public bool HasDekuNut = false;
        public bool HasBomb = false;
        public bool HasBow = false;
        public bool HasFireArrow = false;
        public bool HasDinFire = false;
        public bool HasSlingshot = false;
        public bool HasOcarina = false;
        public bool HasBombchu = false;
        public bool HasHookshot = false;
        public bool HasIceArrow = false;
        public bool HasFaroreWind = false;
        public bool HasBoomerang = false;
        public bool HasLensOfTruth = false;
        public bool HasMagicBean = false;
        public bool HasMegatonHammer = false;
        public bool HasLightArrow = false;
        public bool HasNayruLove = false;
        public bool HasBottle1 = false;
        public bool HasBottle2 = false;
        public bool HasBottle3 = false;
        public bool HasBottle4 = false;
        public bool HasWeirdEgg = false;
        public bool HasWeirdEgg2 = false;

        #endregion

        #region Stuff

        public bool HasKokiriSword = false;
        public bool HasMasterSword = false;
        public bool HasGiantKnifeBiggoronSword = false;
        public bool HasStoneOfAgony = false;
        public bool HasGerudoCard = false;
        public bool HasGoldSkulltula = false;
        public bool HasDekuShield = false;
        public bool HasHylianShield = false;
        public bool HasMirrorShield = false;
        public bool HasGoronBracelet = false;
        public bool HasSilverScale = false;
        public bool HasWallet = false;
        public bool HasKokiriTunic = false;
        public bool HasGoronTunic = false;
        public bool HasZoraTunic = false;
        public bool HasHeartContainer = false;
        public bool HasMagic = false;
        public bool HasKokiriBoots = false;
        public bool HasIronBoots = false;
        public bool HasHoverBoots = false;

        #endregion

        #region Quest Item

        public bool HasKokiriEmerald = false;
        public bool HasGoronRuby = false;
        public bool HasZoraSapphire = false;
        public bool HasForestMedallion = false;
        public bool HasFireMedallion = false;
        public bool HasWaterMedallion = false;
        public bool HasSpiritMedallion = false;
        public bool HasShadowMedallion = false;
        public bool HasLightMedallion = false;

        #endregion

        #region Song

        public bool HasMinuetOfForest = false;
        public bool HasBoleroOfFire = false;
        public bool HasSerenadeOfWater = false;
        public bool HasRequiemOfSpirit = false;
        public bool HasNocturneOfShadow = false;
        public bool HasPreludeOfLight = false;
        public bool HasZeldaLullaby = false;
        public bool HasEponaSong = false;
        public bool HasSariaSong = false;
        public bool HasSunSong = false;
        public bool HasSongOfTime = false;
        public bool HasSongOfStorms = false;

        #endregion



        public override void ReadDataFromEmulator(AbstractRomController emulatorWrapper)
        {
            // INVENTORY C-Button Items
            HasDekuStick = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_DEKU_STICK);
            HasDekuNut = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_DEKU_NUT);
            HasBomb = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOMBS);
            HasBow = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOW);
            HasFireArrow = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_FIRE_ARROW);
            HasDinFire = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_DIN_FIRE);
            HasSlingshot = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_SLINGSHOT);
            HasOcarina = emulatorWrapper.CheckAnyHexValueEqualTo(Model.OOTOffsets.CST_INVENTORY_ADDRESS_OCARINA, new byte[] {
                Model.OOTOffsets.CST_INVENTORY_VALUE_FAIRY_OCARINA,
                Model.OOTOffsets.CST_INVENTORY_VALUE_OCARINA_OF_TIME,
            });
            HasBombchu = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOMBCHU);
            HasHookshot = emulatorWrapper.CheckAnyHexValueEqualTo(Model.OOTOffsets.CST_INVENTORY_ADDRESS_HOOKSHOT, new byte[] {
                Model.OOTOffsets.CST_INVENTORY_VALUE_HOOKSHOT,
                Model.OOTOffsets.CST_INVENTORY_VALUE_LONGSHOT
            });
            HasIceArrow = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_ICE_ARROW);
            HasFaroreWind = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_FAIRIES_WINDS);
            HasBoomerang = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOOMERANG);
            HasLensOfTruth = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_LENS_OF_TRUTH);
            HasMagicBean = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_MAGIC_BEANS);
            HasMegatonHammer = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_MEGATON_HAMMER);
            HasLightArrow = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_LIGHT_ARROW);
            HasNayruLove = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_NAYRU_LOVE);
            HasBottle1 = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOTTLE_1);
            HasBottle2 = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOTTLE_2);
            HasBottle3 = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOTTLE_3);
            HasBottle4 = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOTTLE_4);
            HasWeirdEgg = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_ITEM_MODIFIER_1);
            HasWeirdEgg2 = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_ITEM_MODIFIER_2);

            // Stuff
            var addressEquipementModifier1 = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRESS_EQUIPEMENT_MODIFIER_1);
            var addressEquipementModifier2 = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRESS_EQUIPEMENT_MODIFIER_2);
            HasGoronBracelet = emulatorWrapper.CheckAnyHexValueRaised(addressEquipementModifier1, new byte[] {
                Model.OOTOffsets.CST_INVENTORY_ADDRESS_GORON_BRACELET,
                Model.OOTOffsets.CST_INVENTORY_ADDRESS_SILVER_GAUNTLETS,
                Model.OOTOffsets.CST_INVENTORY_ADDRESS_GOLDEN_GAUNTLETS
            });
            HasSilverScale = emulatorWrapper.CheckAnyHexValueRaised(addressEquipementModifier1, new byte[] {
                Model.OOTOffsets.CST_INVENTORY_ADDRESS_SILVER_SCALE,
                Model.OOTOffsets.CST_INVENTORY_ADDRESS_GOLDEN_SCALE
            });

            //TODO: Find Address
            HasWallet = emulatorWrapper.CheckAnyHexValueRaised(Model.OOTOffsets.CST_INVENTORY_ADDRESS_WALLET, new byte[] {
                Model.OOTOffsets.CST_INVENTORY_DEFAULT_WALLET,
                Model.OOTOffsets.CST_INVENTORY_ADULT_WALLET,
                Model.OOTOffsets.CST_INVENTORY_GIANT_WALLET
            });
            HasMagic = emulatorWrapper.CheckBitRaise(Model.OOTOffsets.CST_INVENTORY_ADDRESS_CAN_USE_MAGIC, 0x01);
            //HasHeartContainer = 

            var addressTunicAndBoot = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRESS_TUNIC_BOOTS);
            HasKokiriTunic = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_KOKIRI_TUNIC);
            HasGoronTunic = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_GORON_TUNIC);
            HasZoraTunic = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_ZORA_TUNIC);
            HasKokiriBoots = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_KOKIRI_BOOTS);
            HasIronBoots = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_IRON_BOOTS);
            HasHoverBoots = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_HOVER_BOOTS);

            var addressSwordAndShield = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRESS_SWORD_SHIELD);
            HasKokiriSword = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_KOKIRI_SWORD);
            HasMasterSword = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_MASTER_SWORD);
            HasGiantKnifeBiggoronSword = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_BIGGORON_GIANT_KNIFE);
            HasDekuShield = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_KOKIRI_SHIELD);
            HasHylianShield = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_HYLIAN_SHIELD);
            HasMirrorShield = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_MIRROR_SHIELD);

            var addressSongAndQuestItem = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRES_SONG_AND_QUEST_ITEM);
            var addressParialSong = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRES_PARTIAL_SONG);
            var addressMedallionAndSong = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRESS_MEDALLION_AND_SONG);

            HasStoneOfAgony = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_STONE_OF_AGONY);
            HasGerudoCard = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_GERUDA_CARD);
            //HasGoldSkulltula = emulatorWrapper.CheckHexValue(Model.OOTOffsets., );

            // Quest Item
            HasKokiriEmerald = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_KOKIRI_EMERAD);
            HasGoronRuby = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_GORON_RUBY);
            HasZoraSapphire = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_ZORA_SAPPHIRE);
            HasForestMedallion = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_FOREST_MEDALLION);
            HasFireMedallion = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_FIRE_MEDALLION);
            HasWaterMedallion = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_WATER_MEDALLION);
            HasSpiritMedallion = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_SPIRIT_MEDALLION);
            HasShadowMedallion = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_SHADOW_MEDALLION);
            HasLightMedallion = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_LIGHT_MEDALLION);

            // Song
            HasMinuetOfForest = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_MINUET_OF_FOREST);
            HasBoleroOfFire = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_BOLERO_OF_FIRE);
            HasSerenadeOfWater = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_SERENADE_OF_WATER);
            HasRequiemOfSpirit = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_REQUIEM_OF_SPIRIT);
            HasNocturneOfShadow = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_NOCTURNE_OF_SHADOW);
            HasPreludeOfLight = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_PRELUDE_OF_LIGHT);
            HasZeldaLullaby = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_ZLDA_LULABY);
            HasEponaSong = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_EPONA_SONG);
            HasSariaSong = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_SARIA_SONG);
            HasSunSong = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_SUN_SONG);
            HasSongOfTime = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_SONG_OF_TIME);
            HasSongOfStorms = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_SONG_OF_STORM);
        }
    }

    class OcarinaOfTimeMemoryDataObserver : AbstractMemoryDataObserver<OcarinaOfTimeItemLogicPopertyName>
    {
        #region INVENTORY C-Button Items

        public ReplaySubject<bool> HasDekuStick = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasDekuNut = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBomb = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBow = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasFireArrow = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasDinFire = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSlingshot = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasOcarina = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBombchu = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasHookshot = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasIceArrow = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasFaroreWind = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBoomerang = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasLensOfTruth = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasMagicBean = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasMegatonHammer = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasLightArrow = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasNayruLove = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBottle1 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBottle2 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBottle3 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBottle4 = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasWeirdEgg = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasWeirdEgg2 = new ReplaySubject<bool>(1);

        #endregion

        #region Stuff

        public ReplaySubject<bool> HasKokiriSword = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasMasterSword = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGiantKnifeBiggoronSword = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasStoneOfAgony = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGerudoCard = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGoldSkulltula = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasDekuShield = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasHylianShield = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasMirrorShield = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGoronBracelet = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSilverScale = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasWallet = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasKokiriTunic = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGoronTunic = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasZoraTunic = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasHeartContainer = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasMagic = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasKokiriBoots = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasIronBoots = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasHoverBoots = new ReplaySubject<bool>(1);

        #endregion

        #region Quest Item

        public ReplaySubject<bool> HasKokiriEmerald = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasGoronRuby = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasZoraSapphire = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasForestMedallion = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasFireMedallion = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasWaterMedallion = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSpiritMedallion = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasShadowMedallion = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasLightMedallion = new ReplaySubject<bool>(1);

        #endregion

        #region Quest Item

        public ReplaySubject<bool> HasMinuetOfForest = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasBoleroOfFire = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSerenadeOfWater = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasRequiemOfSpirit = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasNocturneOfShadow = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasPreludeOfLight = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasZeldaLullaby = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasEponaSong = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSariaSong = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSunSong = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSongOfTime = new ReplaySubject<bool>(1);
        public ReplaySubject<bool> HasSongOfStorms = new ReplaySubject<bool>(1);

        #endregion

        public override void BindAllEvent(ReplaySubject<Tuple<OcarinaOfTimeItemLogicPopertyName, object>> replaySubject)
        {
            HasDekuStick.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Deku_Stick, value)));
            HasDekuNut.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Deku_Nut, value)));
            HasBomb.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Bomb, value)));
            HasBow.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Bow, value)));
            HasFireArrow.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Fire_Arrow, value)));
            HasDinFire.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Din_Fire, value)));
            HasSlingshot.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Fairy_Slingshot, value)));
            HasOcarina.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Ocarina, value)));
            HasBombchu.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Bombchu, value)));
            HasHookshot.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Hookshot, value)));
            HasIceArrow.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Ice_Arrow, value)));
            HasFaroreWind.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Farore_Wind, value)));
            HasBoomerang.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Boomerang, value)));
            HasLensOfTruth.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Lens_of_Truth, value)));
            HasMagicBean.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Magic_Bean, value)));
            HasMegatonHammer.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Megaton_Hammer, value)));
            HasLightArrow.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Light_Arrow, value)));
            HasNayruLove.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Nayru_Love, value)));
            HasBottle1.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Bottle_1, value)));
            HasBottle2.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Bottle_2, value)));
            HasBottle3.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Bottle_3, value)));
            HasBottle4.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Bottle_4, value)));
            HasWeirdEgg.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Weird_Egg, value)));
            HasWeirdEgg2.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Weird_Egg_2, value)));
            HasKokiriSword.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Kokiri_Sword, value)));
            HasMasterSword.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Master_Sword, value)));
            HasGiantKnifeBiggoronSword.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Giant_Knife_Biggoron_Sword, value)));
            HasStoneOfAgony.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Stone_of_Agony, value)));
            HasGerudoCard.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Gerudo_Card, value)));
            HasGoldSkulltula.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Gold_Skulltula, value)));
            HasDekuShield.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Deku_Shield, value)));
            HasHylianShield.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Hylian_Shield, value)));
            HasMirrorShield.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Mirror_Shield, value)));
            HasGoronBracelet.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Goron_Bracelet, value)));
            HasSilverScale.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Silver_Scale, value)));
            HasWallet.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Wallet, value)));
            HasKokiriTunic.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Kokiri_Tunic, value)));
            HasGoronTunic.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Goron_Tunic, value)));
            HasZoraTunic.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Zora_Tunic, value)));
            HasHeartContainer.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Heart_Container, value)));
            HasMagic.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Magic, value)));
            HasKokiriBoots.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Kokiri_Boots, value)));
            HasIronBoots.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Iron_Boots, value)));
            HasHoverBoots.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Hover_Boots, value)));
            HasKokiriEmerald.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Kokiri_Emerald, value)));
            HasGoronRuby.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Goron_Ruby, value)));
            HasZoraSapphire.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Zora_Sapphire, value)));
            HasForestMedallion.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Forest_Medallion, value)));
            HasFireMedallion.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Fire_Medallion, value)));
            HasWaterMedallion.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Water_Medallion, value)));
            HasSpiritMedallion.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Spirit_Medallion, value)));
            HasShadowMedallion.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Shadow_Medallion, value)));
            HasLightMedallion.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Light_Medallion, value)));
            HasMinuetOfForest.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Minuet_of_Forest, value)));
            HasBoleroOfFire.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Bolero_of_Fire, value)));
            HasSerenadeOfWater.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Serenade_of_Water, value)));
            HasRequiemOfSpirit.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Requiem_of_Spirit, value)));
            HasNocturneOfShadow.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Nocturne_of_Shadow, value)));
            HasPreludeOfLight.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Prelude_of_Light, value)));
            HasZeldaLullaby.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Zelda_Lullaby, value)));
            HasEponaSong.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Epona_Song, value)));
            HasSariaSong.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Saria_Song, value)));
            HasSunSong.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Sun_Song, value)));
            HasSongOfTime.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Song_of_Time, value)));
            HasSongOfStorms.Subscribe(value => replaySubject.OnNext(new Tuple<OcarinaOfTimeItemLogicPopertyName, object>(OcarinaOfTimeItemLogicPopertyName.Song_of_Storms, value)));
        }
    }
}
