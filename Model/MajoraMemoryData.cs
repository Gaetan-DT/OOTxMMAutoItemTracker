using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker
{
    using Model.Enum;

    class MajoraMemoryData
    {
        public LinkTransformation currentLinkTransformation = LinkTransformation.Human;
        // TODO: Magic meter
        public bool hasDoubleDefense = false;

        public bool hasOcarina = false;

        public void UdpateStateData(ModLoader64Wrapper modLoader)
        {
            currentLinkTransformation = LinkTransformationMethods.ReadFromMemory(modLoader.readInt8(MMOffsets.CURRENT_TRANSFORMATION));
            // Link
            // MMOffsets.CST_LINKG_MAGIC_METER
            var bDoubleDefense = modLoader.readByte(MMOffsets.CST_LINKG_DOUBLE_DEFENSE, 8);

            // Inventory Equipement
            /*
            hasDoubleDefense = CST_INVENTORY_EQUIPEMENT_SHIELD_SWORD
            CST_INVENTORY_EQUIPEMENT_WALLET
            CST_INVENTORY_EQUIPEMENT_QUIVER_BOMBBAG
            CST_INVENTORY_EQUIPEMENT_BOMBERS_NOTEBOOK
            // INVENTORY C-Button Items
            CST_INVENTORY_OCARINA
            CST_INVENTORY_HERO_BOW
            CST_INVENTORY_FIRE_AARROWS
            CST_INVENTORY_ICE_ARROWS
            CST_INVENTORY_LIGHT_ARROWS 
            CST_INVENTORY_BBOMB 
            CST_INVENTORY_BOMBCHUS 
            CST_INVENTORY_DEKU_STICKS 
            CST_INVENTORY_DEKU_NUTS 
            CST_INVENTORY_MAGIC_BEANS 
            CST_INVENTORY_POWDER_KEG 
            CST_INVENTORY_PICTOGRAPH_BOX 
            CST_INVENTORY_LENS_OF_TRUTH 
            CST_INVENTORY_HOOKSHOT 
            CST_INVENTORY_GREAT_FAIRY_SWORD 
            CST_INVENTORY_TRADING_ITEM_1 
            CST_INVENTORY_TRADING_ITEM_2 
            CST_INVENTORY_TRADING_ITEM_3 
            CST_INVENTORY_BOTTLE_1 
            CST_INVENTORY_BOTTLE_2 
            CST_INVENTORY_BOTTLE_3 
            CST_INVENTORY_BOTTLE_4 
            CST_INVENTORY_BOTTLE_5 
            CST_INVENTORY_BOTTLE_6
            // INVENTORY Masks
            CST_MASK_DEKU_MASK 
            CST_MASK_GORON_MASK 
            CST_MASK_ZORA_MASK 
            CST_MASK_FIERCE_DEITY_MASK 
            CST_MASK_POSTMAN_HAT 
            CST_MASK_ALL_NIGHT_MASK 
            CST_MASK_BLAST_MASK 
            CST_MASK_STONE_MASK 
            CST_MASK_GREAT_FAIRY_MASK 
            CST_MASK_KEATON_MASK 
            CST_MASK_BREMEN_MASK 
            CST_MASK_BUNNY_HOOD
            CST_MASK_DON_GERO_MASK 
            CST_MASK_MASK_OF_SCENTS 
            CST_MASK_ROMANI_MASK 
            CST_MASK_CIRCUS_LEADER_MASK 
            CST_MASK_KAFEI_MASK 
            CST_MASK_COUPLE_MASK 
            CST_MASK_MASK_OF_TRUTH 
            CST_MASK_KAMARO_MASK 
            CST_MASK_GIBDO_MASK 
            CST_MASK_GARO_MASK 
            CST_MASK_CAPTAIN_HAT 
            CST_MASK_GIANT_MASK
            // INVENTORY Quest Items
            CST_SONG_SONG_OF_TIME 
            CST_SONG_SONG_OF_HEALING 
            CST_SONG_EPONA_SONG 
            CST_SONG_SONG_OF_SOARING
            CST_SONG_SONG_OF_STORMS 
            CST_SONG_SONATA_OF_AWAKENING
            CST_SONG_GORON_LULLABY_INTRO
            CST_SONG_GORON_LULLABY_FULL 
            CST_SONG_NEW_WAVE_BOSSA_NOVA
            CST_SONG_ELEGY_OF_EMPTYNESS 
            CST_SONG_OATH_TO_ORDER
            // Boss Masks
            CST_BOSS_MASK
            */
        }
    }
}
