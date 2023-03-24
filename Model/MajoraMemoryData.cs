using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker
{
    using Model.Enum;
    using System.ComponentModel;
    using System.Diagnostics;

    class MajoraMemoryData
    {
        #region Other
        public LinkTransformation currentLinkTransformation = LinkTransformation.Human;
        #endregion

        #region Link
        public MagicMeter magicMeter = MagicMeter.None;
        public bool hasDoubleDefense = false;
        #endregion

        #region Inventory Equipement
        public EquipmentWallet hasEquipmentWallet = EquipmentWallet.Child;
        public EquipmentQuiver hasEquipmentQuiver = EquipmentQuiver.None;
        public EquipmentBombBag hasEquipmentBombBag = EquipmentBombBag.None;
        public bool hasBombersNoteBook = false;
        #endregion

        #region INVENTORY C-Button Items
        public bool hasOcarina = false;
        public bool hasHeroBow = false;
        public bool hasFireArrows = false;
        public bool hasIceArrows = false;
        public bool hasLightArrows = false;
        public bool hasBomb = false;
        public bool hasBombchus = false;
        public bool hasDekuSticks = false;
        public bool hasDekuNuts = false;
        public bool hasMagicBeans = false;
        public bool hasPowderKeg = false;
        public bool hasPictographBox = false;
        public bool hasLensOfTruth = false;
        public bool hasHookShot = false;
        public bool hasGreatFairySword = false;
        public bool hasTradingItem1 = false; // TODO add enum for trading item
        public bool hasTradingItem2 = false; // TODO add enum for trading item
        public bool hasTradingItem3 = false; // TODO add enum for trading item
        public bool hasBootle1 = false; // TODO add enum for bootle
        public bool hasBootle2 = false; // TODO add enum for bootle
        public bool hasBootle3 = false; // TODO add enum for bootle
        public bool hasBootle4 = false; // TODO add enum for bootle
        public bool hasBootle5 = false; // TODO add enum for bootle
        public bool hasBootle6 = false; // TODO add enum for bootle
        #endregion
        
        #region INVENTORY Masks
        public bool hasDekuMask = false;
        public bool hasGoronMask = false;
        public bool hasZoraMask = false;
        public bool hasFierceDeityMask = false;
        public bool hasPostmanHat = false;
        public bool hasAllNightMask = false;
        public bool hasBlastMask = false;
        public bool hasStoneMask = false;
        public bool hasGreatFairyMask = false;
        public bool hasKeatonMask = false;
        public bool hasBremenMask = false;
        public bool hasBunnyHood = false;
        public bool hasDonGeroMask = false;
        public bool hasMaskOfScents = false;
        public bool hasRomaniMask = false;
        public bool hasCircusLeaderMask = false;
        public bool hasKaefiMask = false;
        public bool hasCoupleMask = false;
        public bool hasMaskOfTruth = false;
        public bool hasKamaroMask = false;
        public bool hasGibdoMask = false;
        public bool hasGaroMask = false;
        public bool hasCaptainHat = false;
        public bool hasGiantMask = false;
        #endregion

        #region INVENTORY Quest Items
        public bool hasSongOfTime = false;
        public bool hasSongOfHealing = false;
        public bool hasEponaSong = false;
        public bool hasSongOfSoaring = false;
        public bool hasSongOfStorm = false;
        public bool hasSonataOfAwakening = false;
        public bool hasGoronLullaby = false;
        public bool hasNewWaveBossaNova = false;
        public bool hasElegyOfEmptyness = false;
        public bool hasSongOathToORder = false;
        public bool hasBossMaskOdolwa = false;
        public bool hasBoosMaskGoht = false;
        public bool hasBoosMaskGyorg = false;
        public bool hasBoosMaskTwinmold = false;
        #endregion

        public void UpdateStateData(ModLoader64Wrapper modLoader)
        {
            // Other
            currentLinkTransformation = LinkTransformationMethods.ReadFromMemory(modLoader.readInt8(MMOffsets.CURRENT_TRANSFORMATION));

            // Link
            magicMeter = MagicMeterMethod.ReadFromMemory(modLoader.readInt8(MMOffsets.CST_LINKG_MAGIC_METER));
            var bDoubleDefense = modLoader.readByte(MMOffsets.CST_LINKG_DOUBLE_DEFENSE, 8);
            hasDoubleDefense = (bDoubleDefense[0] & 00010020) != bDoubleDefense[0];

            // Inventory Equipment
            hasEquipmentWallet = EquipmentWalletMethod.ReadFromMemory(modLoader.readInt8(MMOffsets.CST_INVENTORY_EQUIPEMENT_WALLET));
            hasBombersNoteBook = checkHexRaised(modLoader, MMOffsets.CST_INVENTORY_EQUIPEMENT_BOMBERS_NOTEBOOK, 2);
            var byteQuiverAndBombBag = modLoader.readByte(MMOffsets.CST_INVENTORY_EQUIPEMENT_QUIVER_BOMBBAG, 1)[0];
            hasEquipmentQuiver = EquipmentQuiverMethod.ReadFromMemory(byteQuiverAndBombBag);
            hasEquipmentBombBag = EquipmentBombBagMethod.ReadFromMemory(byteQuiverAndBombBag);

            // INVENTORY C-Button Items
            hasOcarina = readItem(modLoader, MMOffsets.CST_INVENTORY_OCARINA, 0x00);
            hasHeroBow = readItem(modLoader, MMOffsets.CST_INVENTORY_HERO_BOW, 0x01);
            //
            hasHeroBow = readItem(modLoader, MMOffsets.CST_INVENTORY_FIRE_ARROWS, 0x02);
            hasIceArrows = readItem(modLoader, MMOffsets.CST_INVENTORY_ICE_ARROWS, 0x03);
            hasLightArrows = readItem(modLoader, MMOffsets.CST_INVENTORY_LIGHT_ARROWS , 0x04);
            hasBomb = readItem(modLoader, MMOffsets.CST_INVENTORY_BOMB , 0x06);
            hasBombchus = readItem(modLoader, MMOffsets.CST_INVENTORY_BOMBCHUS , 0x07);
            hasDekuSticks = readItem(modLoader, MMOffsets.CST_INVENTORY_DEKU_STICKS , 0x08);
            hasDekuNuts = readItem(modLoader, MMOffsets.CST_INVENTORY_DEKU_NUTS, 0x09);
            hasMagicBeans = readItem(modLoader, MMOffsets.CST_INVENTORY_MAGIC_BEANS , 0x0A);
            hasPowderKeg = readItem(modLoader, MMOffsets.CST_INVENTORY_POWDER_KEG , 0x0C);
            hasPictographBox = readItem(modLoader, MMOffsets.CST_INVENTORY_PICTOGRAPH_BOX , 0x0D);
            hasLensOfTruth = readItem(modLoader, MMOffsets.CST_INVENTORY_LENS_OF_TRUTH, 0x0E);
            hasHookShot = readItem(modLoader, MMOffsets.CST_INVENTORY_HOOKSHOT, 0x0F);
            hasGreatFairySword = readItem(modLoader, MMOffsets.CST_INVENTORY_GREAT_FAIRY_SWORD, 0x10);
            hasTradingItem1 = readNotFF(modLoader, MMOffsets.CST_INVENTORY_TRADING_ITEM_1);
            hasTradingItem2 = readNotFF(modLoader, MMOffsets.CST_INVENTORY_TRADING_ITEM_2);
            hasTradingItem3 = readNotFF(modLoader, MMOffsets.CST_INVENTORY_TRADING_ITEM_3);
            hasBootle1 = readNotFF(modLoader, MMOffsets.CST_INVENTORY_BOTTLE_1);
            hasBootle2 = readNotFF(modLoader, MMOffsets.CST_INVENTORY_BOTTLE_2);
            hasBootle3 = readNotFF(modLoader, MMOffsets.CST_INVENTORY_BOTTLE_3);
            hasBootle4 = readNotFF(modLoader, MMOffsets.CST_INVENTORY_BOTTLE_4);
            hasBootle5 = readNotFF(modLoader, MMOffsets.CST_INVENTORY_BOTTLE_5);
            hasBootle6 = readNotFF(modLoader, MMOffsets.CST_INVENTORY_BOTTLE_6);
            // INVENTORY Masks
            hasDekuMask = readNotFF(modLoader, MMOffsets.CST_MASK_DEKU_MASK);
            hasGoronMask = readNotFF(modLoader, MMOffsets.CST_MASK_GORON_MASK);
            hasZoraMask = readNotFF(modLoader, MMOffsets.CST_MASK_ZORA_MASK);
            hasFierceDeityMask = readNotFF(modLoader, MMOffsets.CST_MASK_FIERCE_DEITY_MASK);
            hasPostmanHat = readNotFF(modLoader, MMOffsets.CST_MASK_POSTMAN_HAT);
            hasAllNightMask = readNotFF(modLoader, MMOffsets.CST_MASK_ALL_NIGHT_MASK);
            hasBlastMask = readNotFF(modLoader, MMOffsets.CST_MASK_BLAST_MASK);
            hasStoneMask = readNotFF(modLoader, MMOffsets.CST_MASK_STONE_MASK);
            hasGreatFairyMask = readNotFF(modLoader, MMOffsets.CST_MASK_GREAT_FAIRY_MASK);
            hasKeatonMask = readNotFF(modLoader, MMOffsets.CST_MASK_KEATON_MASK);
            hasBremenMask = readNotFF(modLoader, MMOffsets.CST_MASK_BREMEN_MASK);
            hasBunnyHood = readNotFF(modLoader, MMOffsets.CST_MASK_BUNNY_HOOD);
            hasDonGeroMask = readNotFF(modLoader, MMOffsets.CST_MASK_DON_GERO_MASK);
            hasMaskOfScents = readNotFF(modLoader, MMOffsets.CST_MASK_MASK_OF_SCENTS);
            hasRomaniMask = readNotFF(modLoader, MMOffsets.CST_MASK_ROMANI_MASK);
            hasCircusLeaderMask = readNotFF(modLoader, MMOffsets.CST_MASK_CIRCUS_LEADER_MASK);
            hasKaefiMask = readNotFF(modLoader, MMOffsets.CST_MASK_KAFEI_MASK);
            hasCoupleMask = readNotFF(modLoader, MMOffsets.CST_MASK_COUPLE_MASK);
            hasMaskOfTruth = readNotFF(modLoader, MMOffsets.CST_MASK_MASK_OF_TRUTH);
            hasKamaroMask = readNotFF(modLoader, MMOffsets.CST_MASK_KAMARO_MASK);
            hasGibdoMask = readNotFF(modLoader, MMOffsets.CST_MASK_GIBDO_MASK);
            hasGaroMask = readNotFF(modLoader, MMOffsets.CST_MASK_GARO_MASK);
            hasCaptainHat = readNotFF(modLoader, MMOffsets.CST_MASK_CAPTAIN_HAT);
            hasGiantMask = readNotFF(modLoader, MMOffsets.CST_MASK_GIANT_MASK);
            // INVENTORY Quest Items
            hasSongOfTime = checkHexRaised(modLoader, MMOffsets.CST_SONG_SONG_OF_TIME, 4);
            hasSongOfHealing = checkHexRaised(modLoader, MMOffsets.CST_SONG_SONG_OF_HEALING, 5);
            hasEponaSong = checkHexRaised(modLoader, MMOffsets.CST_SONG_EPONA_SONG, 6);
            hasSongOfSoaring = checkHexRaised(modLoader, MMOffsets.CST_SONG_SONG_OF_SOARING, 7);
            hasSongOfStorm = checkHexRaised(modLoader, MMOffsets.CST_SONG_SONG_OF_STORMS, 0);
            hasSonataOfAwakening = checkHexRaised(modLoader, MMOffsets.CST_SONG_SONATA_OF_AWAKENING, 6);
            hasGoronLullaby = checkHexRaised(modLoader, MMOffsets.CST_SONG_GORON_LULLABY_INTRO, 0);
            hasNewWaveBossaNova = checkHexRaised(modLoader, MMOffsets.CST_SONG_NEW_WAVE_BOSSA_NOVA, 0);
            hasElegyOfEmptyness = checkHexRaised(modLoader, MMOffsets.CST_SONG_ELEGY_OF_EMPTYNESS, 1);
            hasSongOathToORder = checkHexRaised(modLoader, MMOffsets.CST_SONG_OATH_TO_ORDER, 2);
            // Boss Masks
            //CST_BOSS_MASK
            var bossMask = modLoader.readByte(MMOffsets.CST_BOSS_MASK, 1)[0];
            hasBossMaskOdolwa = (bossMask & (1 << 0)) != 0;
            hasBoosMaskGoht = (bossMask & (1 << 1)) != 0;
            hasBoosMaskGyorg = (bossMask & (1 << 2)) != 0;
            hasBoosMaskTwinmold = (bossMask & (1 << 3)) != 0;
            //Debug.WriteLine(this.toStringQuestItem());
            Debug.WriteLine(this.ToStringInventoryEquipment());
        }

        #region Utilit

        private bool readNotFF(ModLoader64Wrapper modLoader, int offset)
        {
            var address = modLoader.readInt8(offset);
            return address != 0xFF;
        }

        private bool readItem(ModLoader64Wrapper modLoader,  int offset, int itemValue)
        {
            var address = modLoader.readInt8(offset);
            //Debug.WriteLine("adress: " + adress);
            return (address & itemValue) == address;
        }

        private bool checkHexRaised(ModLoader64Wrapper modLoader, int offset, int bitRaised)
        {
            var b = modLoader.readByte(offset, 1)[0];
            //Debug.WriteLine("byteArray: " + b);
            //Debug.WriteLine("shift0: " + (b & (1 << 0)));
            //Debug.WriteLine("shift1: " + (b & (1 << 1)));
            //Debug.WriteLine("shift2: " + (b & (1 << 2)));
            //Debug.WriteLine("shift3: " + (b & (1 << 3)));
            //Debug.WriteLine("shift4: " + (b & (1 << 4)));
            //Debug.WriteLine("shift5: " + (b & (1 << 5)));
            //Debug.WriteLine("shift6: " + (b & (1 << 6)));
            //Debug.WriteLine("shift7: " + (b & (1 << 7)));
            return (b & (1 << bitRaised)) != 0;
        }

        #endregion

        public String ToStringInventoryEquipment()
        {
            return "" +
                "Inventory Equipement:" +
                "- equipementWallet:" + hasEquipmentWallet + "\r\n" +
                "- equipementQuiver:" + hasEquipmentQuiver + "\r\n" +
                "- equipementBombBag:" + hasEquipmentBombBag + "\r\n" +
                "- hasBombersNoteBook:" + hasBombersNoteBook + "\r\n" +
                "";
             
             
            
        }

        public String ToStringQuestItem()
        {
            return "" +
                "INVENTORY Quest Items\r\n" +
                "- hasSongOfTime:" + hasSongOfTime + "\r\n" +
                "- hasSongOfHealing:" + hasSongOfHealing + "\r\n" +
                "- hasEponaSong:" + hasEponaSong + "\r\n" +
                "- hasSongOfSoaring:" + hasSongOfSoaring + "\r\n" +
                "- hasSongOfStorm:" + hasSongOfStorm + "\r\n" +
                "- hasSonataOfAwakening:" + hasSonataOfAwakening + "\r\n" +
                "- hasGoronLullaby:" + hasGoronLullaby + "\r\n" +
                "- hasNewWaveBossaNova:" + hasNewWaveBossaNova + "\r\n" +
                "- hasElegyOfEmptyness:" + hasElegyOfEmptyness + "\r\n" +
                "- hasSongOathToORder:" + hasSongOathToORder + "\r\n" +
                "- hasBossMaskOdolwa:" + hasBossMaskOdolwa + "\r\n" +
                "- hasBoosMaskGoht:" + hasBoosMaskGoht + "\r\n" +
                "- hasBoosMaskGyorg:" + hasBoosMaskGyorg + "\r\n" +
                "- hasBoosMaskTwinmold:" + hasBoosMaskTwinmold + "\r\n" +
                "";
        }

        public override String ToString()
        {
            return "" +
                "Other:\r\n" +
                "- currentLinkTransformation="+ currentLinkTransformation + "\r\n" +
                "Link:\r\n" +
                "- magicMeter=" + magicMeter + "\r\n" +
                "- hasDoubleDefense=" + hasDoubleDefense + "\r\n" +
                "Inventory Equipement:\r\n" +
                "INVENTORY C-Button Items:\r\n" +
                "- hasOcarina=" + hasOcarina + "\r\n" +
                "- hasHeroBow=" + hasHeroBow + "\r\n" +
                "- hasFireArrows=" + hasFireArrows + "\r\n" +
                "- hasIceArrows=" + hasIceArrows + "\r\n" +
                "- hasLightArrows=" + hasLightArrows + "\r\n" +
                "- hasBomb=" + hasBomb + "\r\n" +
                "- hasBombchus=" + hasBombchus + "\r\n" +
                "- hasDekuSticks=" + hasDekuSticks + "\r\n" +
                "- hasDekuNuts=" + hasDekuNuts + "\r\n" +
                "- hasMagicBeans=" + hasMagicBeans + "\r\n" +
                "- hasPowderKeg=" + hasPowderKeg + "\r\n" +
                "- hasPictographBox=" + hasPictographBox + "\r\n" +
                "- hasLensOfTruth=" + hasLensOfTruth + "\r\n" +
                "- hasHookShot=" + hasHookShot + "\r\n" +
                "- hasGreatFairySword=" + hasGreatFairySword + "\r\n" +
                "- hasTradingItem1=" + hasTradingItem1 + "\r\n" +
                "- hasTradingItem2=" + hasTradingItem2 + "\r\n" +
                "- hasTradingItem3=" + hasTradingItem3 + "\r\n" +
                "- hasBootle1=" + hasBootle1 + "\r\n" +
                "- hasBootle2=" + hasBootle2 + "\r\n" +
                "- hasBootle3=" + hasBootle3 + "\r\n" +
                "- hasBootle4=" + hasBootle4 + "\r\n" +
                "- hasBootle5=" + hasBootle5 + "\r\n" +
                "- hasBootle6=" + hasBootle6 + "\r\n" +
                "INVENTORY Masks:\r\n" +
                "- hasDekuMask=" + hasDekuMask + "\r\n" +
                "- hasGoronMask=" + hasGoronMask + "\r\n" +
                "- hasZoraMask=" + hasZoraMask + "\r\n" +
                "- hasFierceDeityMask=" + hasFierceDeityMask + "\r\n" +
                "- hasPostmanHat=" + hasPostmanHat + "\r\n" +
                "- hasAllNightMask=" + hasAllNightMask + "\r\n" +
                "- hasBlastMask=" + hasBlastMask + "\r\n" +
                "- hasStoneMask=" + hasStoneMask + "\r\n" +
                "- hasGreatFairyMask=" + hasGreatFairyMask + "\r\n" +
                "- hasKeatonMask=" + hasKeatonMask + "\r\n" +
                "- hasBremenMask=" + hasBremenMask + "\r\n" +
                "- hasBunnyHood=" + hasBunnyHood + "\r\n" +
                "- hasDonGeroMask=" + hasDonGeroMask + "\r\n" +
                "- hasMaskOfScents=" + hasMaskOfScents + "\r\n" +
                "- hasRomaniMask=" + hasRomaniMask + "\r\n" +
                "- hasCircusLeaderMask=" + hasCircusLeaderMask + "\r\n" +
                "- hasKaefiMask=" + hasKaefiMask + "\r\n" +
                "- hasCoupleMask=" + hasCoupleMask + "\r\n" +
                "- hasMaskOfTruth=" + hasMaskOfTruth + "\r\n" +
                "- hasKamaroMask=" + hasKamaroMask + "\r\n" +
                "- hasGibdoMask=" + hasGibdoMask + "\r\n" +
                "- hasGaroMask=" + hasGaroMask + "\r\n" +
                "- hasCaptainHat=" + hasCaptainHat + "\r\n" +
                "- hasGiantMask=" + hasGiantMask + "\r\n" +
                ToStringQuestItem() +
                "";
        }
    }
}
