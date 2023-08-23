using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;
using System;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.MemoryReader.MemoryData
{
    class OcarinaOfTimeMemoryData : AbstractMemoryData<OcarinaOfTimeItemLogicPopertyName>
    {
        public Dictionary<OcarinaOfTimeItemLogicPopertyName, object> mapPropertyNameBool = new Dictionary<OcarinaOfTimeItemLogicPopertyName, object>()
        {
            { OcarinaOfTimeItemLogicPopertyName.Deku_Stick, false },
            { OcarinaOfTimeItemLogicPopertyName.Deku_Nut, false },
            { OcarinaOfTimeItemLogicPopertyName.Bomb,  false },
            { OcarinaOfTimeItemLogicPopertyName.Bow, false },
            { OcarinaOfTimeItemLogicPopertyName.Fire_Arrow, false },
            { OcarinaOfTimeItemLogicPopertyName.Din_Fire, false },
            { OcarinaOfTimeItemLogicPopertyName.Fairy_Slingshot, false },
            { OcarinaOfTimeItemLogicPopertyName.Ocarina, false },
            { OcarinaOfTimeItemLogicPopertyName.Bombchu, false },
            { OcarinaOfTimeItemLogicPopertyName.Hookshot, false },
            { OcarinaOfTimeItemLogicPopertyName.Ice_Arrow, false },
            { OcarinaOfTimeItemLogicPopertyName.Farore_Wind, false },
            { OcarinaOfTimeItemLogicPopertyName.Boomerang, false },
            { OcarinaOfTimeItemLogicPopertyName.Lens_of_Truth, false },
            { OcarinaOfTimeItemLogicPopertyName.Magic_Bean, false },
            { OcarinaOfTimeItemLogicPopertyName.Megaton_Hammer, false },
            { OcarinaOfTimeItemLogicPopertyName.Light_Arrow, false },
            { OcarinaOfTimeItemLogicPopertyName.Nayru_Love, false },
            { OcarinaOfTimeItemLogicPopertyName.Bottle_1, false },
            { OcarinaOfTimeItemLogicPopertyName.Bottle_2, false },
            { OcarinaOfTimeItemLogicPopertyName.Bottle_3, false },
            { OcarinaOfTimeItemLogicPopertyName.Bottle_4, false },
            { OcarinaOfTimeItemLogicPopertyName.Weird_Egg, false },
            { OcarinaOfTimeItemLogicPopertyName.Mask_Quest, false },
            { OcarinaOfTimeItemLogicPopertyName.Kokiri_Sword, false },
            { OcarinaOfTimeItemLogicPopertyName.Master_Sword, false },
            { OcarinaOfTimeItemLogicPopertyName.Giant_Knife_Biggoron_Sword, false },
            { OcarinaOfTimeItemLogicPopertyName.Stone_of_Agony, false },
            { OcarinaOfTimeItemLogicPopertyName.Gerudo_Card, false },
            { OcarinaOfTimeItemLogicPopertyName.Gold_Skulltula, false },
            { OcarinaOfTimeItemLogicPopertyName.Deku_Shield, false },
            { OcarinaOfTimeItemLogicPopertyName.Hylian_Shield, false },
            { OcarinaOfTimeItemLogicPopertyName.Mirror_Shield, false },
            { OcarinaOfTimeItemLogicPopertyName.Goron_Bracelet, false },
            { OcarinaOfTimeItemLogicPopertyName.Scale, false },
            { OcarinaOfTimeItemLogicPopertyName.Wallet, false },
            { OcarinaOfTimeItemLogicPopertyName.Kokiri_Tunic, false },
            { OcarinaOfTimeItemLogicPopertyName.Goron_Tunic, false },
            { OcarinaOfTimeItemLogicPopertyName.Zora_Tunic, false },
            { OcarinaOfTimeItemLogicPopertyName.Heart_Container, false },
            { OcarinaOfTimeItemLogicPopertyName.Magic, false },
            { OcarinaOfTimeItemLogicPopertyName.Kokiri_Boots, false },
            { OcarinaOfTimeItemLogicPopertyName.Iron_Boots, false },
            { OcarinaOfTimeItemLogicPopertyName.Hover_Boots, false },
            { OcarinaOfTimeItemLogicPopertyName.Kokiri_Emerald, false },
            { OcarinaOfTimeItemLogicPopertyName.Goron_Ruby, false },
            { OcarinaOfTimeItemLogicPopertyName.Zora_Sapphire, false },
            { OcarinaOfTimeItemLogicPopertyName.Forest_Medallion, false },
            { OcarinaOfTimeItemLogicPopertyName.Fire_Medallion, false },
            { OcarinaOfTimeItemLogicPopertyName.Water_Medallion, false },
            { OcarinaOfTimeItemLogicPopertyName.Spirit_Medallion, false },
            { OcarinaOfTimeItemLogicPopertyName.Shadow_Medallion, false },
            { OcarinaOfTimeItemLogicPopertyName.Light_Medallion, false },
            { OcarinaOfTimeItemLogicPopertyName.Minuet_of_Forest, false },
            { OcarinaOfTimeItemLogicPopertyName.Bolero_of_Fire, false },
            { OcarinaOfTimeItemLogicPopertyName.Serenade_of_Water, false },
            { OcarinaOfTimeItemLogicPopertyName.Requiem_of_Spirit, false },
            { OcarinaOfTimeItemLogicPopertyName.Nocturne_of_Shadow, false },
            { OcarinaOfTimeItemLogicPopertyName.Prelude_of_Light, false },
            { OcarinaOfTimeItemLogicPopertyName.Zelda_Lullaby, false },
            { OcarinaOfTimeItemLogicPopertyName.Epona_Song, false },
            { OcarinaOfTimeItemLogicPopertyName.Saria_Song, false },
            { OcarinaOfTimeItemLogicPopertyName.Sun_Song, false },
            { OcarinaOfTimeItemLogicPopertyName.Song_of_Time, false },
            { OcarinaOfTimeItemLogicPopertyName.Song_of_Storms, false }
        };

        public override Dictionary<OcarinaOfTimeItemLogicPopertyName, object> GetMemoryDataMap()
        {
            return mapPropertyNameBool;
        }

        public override void ReadDataFromEmulator(AbstractRomController emulatorWrapper)
        {
            // INVENTORY C-Button Items
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Deku_Stick] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_DEKU_STICK);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Deku_Nut] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_DEKU_NUT);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Bomb] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOMBS);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Bow] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOW);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Fire_Arrow] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_FIRE_ARROW);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Din_Fire] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_DIN_FIRE);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Fairy_Slingshot] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_SLINGSHOT);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Ocarina] = emulatorWrapper.CheckAnyHexValueEqualTo(Model.OOTOffsets.CST_INVENTORY_ADDRESS_OCARINA, new byte[] {
                Model.OOTOffsets.CST_INVENTORY_VALUE_FAIRY_OCARINA,
                Model.OOTOffsets.CST_INVENTORY_VALUE_OCARINA_OF_TIME,
            });
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Bombchu] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOMBCHU);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Hookshot] = emulatorWrapper.CheckAnyHexValueEqualTo(Model.OOTOffsets.CST_INVENTORY_ADDRESS_HOOKSHOT, new byte[] {
                Model.OOTOffsets.CST_INVENTORY_VALUE_HOOKSHOT,
                Model.OOTOffsets.CST_INVENTORY_VALUE_LONGSHOT
            });
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Ice_Arrow] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_ICE_ARROW);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Farore_Wind] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_FAIRIES_WINDS);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Boomerang] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOOMERANG);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Lens_of_Truth] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_LENS_OF_TRUTH);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Magic_Bean] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_MAGIC_BEANS);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Megaton_Hammer] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_MEGATON_HAMMER);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Light_Arrow] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_LIGHT_ARROW);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Nayru_Love] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_NAYRU_LOVE);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Bottle_1] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOTTLE_1);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Bottle_2] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOTTLE_2);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Bottle_3] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOTTLE_3);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Bottle_4] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_BOTTLE_4);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Weird_Egg] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_ITEM_MODIFIER_1);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Mask_Quest] = emulatorWrapper.CheckIsNotFF(Model.OOTOffsets.CST_INVENTORY_ADDRESS_ITEM_MODIFIER_2);

            // Stuff
            var addressEquipementModifier1 = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRESS_EQUIPEMENT_MODIFIER_1);
            var addressEquipementModifier2 = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRESS_EQUIPEMENT_MODIFIER_2);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Goron_Bracelet] = emulatorWrapper.CheckAnyHexValueRaised(addressEquipementModifier1, new byte[] {
                Model.OOTOffsets.CST_INVENTORY_ADDRESS_GORON_BRACELET,
                Model.OOTOffsets.CST_INVENTORY_ADDRESS_SILVER_GAUNTLETS,
                Model.OOTOffsets.CST_INVENTORY_ADDRESS_GOLDEN_GAUNTLETS
            });
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Scale] = emulatorWrapper.CheckAnyHexValueRaised(addressEquipementModifier1, new byte[] {
                Model.OOTOffsets.CST_INVENTORY_ADDRESS_SILVER_SCALE,
                Model.OOTOffsets.CST_INVENTORY_ADDRESS_GOLDEN_SCALE
            });

            //TODO: Find Address
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Wallet] = emulatorWrapper.CheckAnyHexValueRaised(Model.OOTOffsets.CST_INVENTORY_ADDRESS_WALLET, new byte[] {
                Model.OOTOffsets.CST_INVENTORY_DEFAULT_WALLET,
                Model.OOTOffsets.CST_INVENTORY_ADULT_WALLET,
                Model.OOTOffsets.CST_INVENTORY_GIANT_WALLET
            });
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Magic] = emulatorWrapper.CheckBitRaise(Model.OOTOffsets.CST_INVENTORY_ADDRESS_CAN_USE_MAGIC, 0x01);
            //HasHeartContainer = 

            var addressTunicAndBoot = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRESS_TUNIC_BOOTS);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Kokiri_Tunic] = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_KOKIRI_TUNIC);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Goron_Tunic] = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_GORON_TUNIC);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Zora_Tunic] = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_ZORA_TUNIC);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Kokiri_Boots] = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_KOKIRI_BOOTS);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Iron_Boots] = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_IRON_BOOTS);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Hover_Boots] = emulatorWrapper.CheckBitRaise(addressTunicAndBoot, Model.OOTOffsets.CST_INVENTORY_ITEM_HOVER_BOOTS);

            var addressSwordAndShield = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRESS_SWORD_SHIELD);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Kokiri_Sword] = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_KOKIRI_SWORD);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Master_Sword] = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_MASTER_SWORD);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Giant_Knife_Biggoron_Sword] = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_BIGGORON_GIANT_KNIFE);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Deku_Shield] = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_KOKIRI_SHIELD);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Hylian_Shield] = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_HYLIAN_SHIELD);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Mirror_Shield] = emulatorWrapper.CheckBitRaise(addressSwordAndShield, Model.OOTOffsets.CST_INVENTORY_ITEM_MIRROR_SHIELD);

            var addressSongAndQuestItem = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRES_SONG_AND_QUEST_ITEM);
            var addressParialSong = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRES_PARTIAL_SONG);
            var addressMedallionAndSong = emulatorWrapper.ReadUint8InEdianSizeAsByte(Model.OOTOffsets.CST_INVENTORY_ADDRESS_MEDALLION_AND_SONG);

            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Stone_of_Agony] = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_STONE_OF_AGONY);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Gerudo_Card] = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_GERUDA_CARD);
            //HasGoldSkulltula = emulatorWrapper.CheckHexValue(Model.OOTOffsets., );

            // Quest Item
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Kokiri_Emerald] = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_KOKIRI_EMERAD);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Goron_Ruby] = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_GORON_RUBY);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Zora_Sapphire] = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_ZORA_SAPPHIRE);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Forest_Medallion] = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_FOREST_MEDALLION);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Fire_Medallion] = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_FIRE_MEDALLION);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Water_Medallion] = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_WATER_MEDALLION);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Spirit_Medallion] = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_SPIRIT_MEDALLION);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Shadow_Medallion] = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_SHADOW_MEDALLION);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Light_Medallion] = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_LIGHT_MEDALLION);

            // Song
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Minuet_of_Forest] = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_MINUET_OF_FOREST);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Bolero_of_Fire] = emulatorWrapper.CheckBitRaise(addressMedallionAndSong, Model.OOTOffsets.CST_INVENTORY_ITEM_BOLERO_OF_FIRE);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Serenade_of_Water] = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_SERENADE_OF_WATER);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Requiem_of_Spirit] = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_REQUIEM_OF_SPIRIT);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Nocturne_of_Shadow] = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_NOCTURNE_OF_SHADOW);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Prelude_of_Light] = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_PRELUDE_OF_LIGHT);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Zelda_Lullaby] = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_ZLDA_LULABY);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Epona_Song] = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_EPONA_SONG);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Saria_Song] = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_SARIA_SONG);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Sun_Song] = emulatorWrapper.CheckBitRaise(addressParialSong, Model.OOTOffsets.CST_INVENTORY_ITEM_SUN_SONG);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Song_of_Time] = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_SONG_OF_TIME);
            mapPropertyNameBool[OcarinaOfTimeItemLogicPopertyName.Song_of_Storms] = emulatorWrapper.CheckBitRaise(addressSongAndQuestItem, Model.OOTOffsets.CST_INVENTORY_ITEM_SONG_OF_STORM);
        }
    }
}
