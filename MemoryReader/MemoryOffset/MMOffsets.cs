using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker
{
    class MMOffsets // Big Endian
    {
        // 0x8076D55C: Zeldaz check address for mm
        public const int ZELDAZ_CHECK_ADDRESS = 0x76D55C;
        public const int ZELDAZ_CHECK_BE = 0x5A454C44;
        public const int ZELDAZ_CHECK_LE = 0x444C455A;

        #region Link 

        // MEM 0x801EF6A9: [Byte] #Magic
        // 0x30 Full(Default)
        // 0x60 Full(Double)
        public const int CST_LINKG_MAGIC_METER = 0x1EF6AB; // Magic meter 1EF6AB // 0..2 = No magic, small, large


        public const int CST_LINKG_DOUBLE_DEFENSE = 0x1EF740; // Double Defense 1EF740 // Left part bit 4 and Right part bit 2

        #endregion

        #region INVENTORY Equipment

        // Equiped value
        // First byte for shield: 0..2=None, Hero, Mirror
        // Second byte for sword: 0..3=None, Kokiri, Razor, Gilded
        public const int CST_INVENTORY_EQUIPEMENT_SHIELD_SWORD = 0x1EF6DE; // SwordAndShield = 1EF6DE //

        // Sword = 1EF6BF // 4D..4F=Kokiri, Razor, Gilded FF=None
        // TODO: Find Shield only address if exist

        public const int CST_INVENTORY_EQUIPEMENT_WALLET = 0x1EF729; // Wallet 1EF729 // 00=Child, 10=Adult, 20=Giant

        // ___B B_QQ
        // 0000 0000
        public const int CST_INVENTORY_EQUIPEMENT_QUIVER_BOMBBAG = 0x1EF728; // Quiver and Bombbag 1EF728
        // Quiver 1EF728 // read two last byte = 0, 1, 2, 3 = None, Normal, Large, Largest
        // Bombbag 1EF728 // read bit 4 and 5 = 0, 1, 2, 3 = None, Normal, Big, Biggest
        // 000B B0QQ

        #endregion

        #region INVENTORY C-Button Items

        // MEM 0x801EF6E0: [Tble] #Item Slot Item ID Table
		//  Entries
        //      MEM 0x801EF6E0: #Ocarina, Hero's Bow, Fire Arrow, Ice Arrow
		//      MEM 0x801EF6E4: #Light Arrow, Quest Slot 1, Bomb, Bombchu
		//      MEM 0x801EF6E8: #Deku Stick, Deku Nut, Magical Beans, Quest Slot 2
		//      MEM 0x801EF6EC: #Powder Keg, Pictograph Box, Lens of Truth, Hookshot
		//      MEM 0x801EF6F0: #Great Fairy's Sword, Quest Slot 3, Bottle 1, Bottle 2
		//      MEM 0x801EF6F4: #Bottle 3, Bottle 4, Bottle 5, Bottle 6
		//      MEM 0x801EF6F8: #Postman's Hat, All-Night Mask, Blast Mask, Stone Mask
		//      MEM 0x801EF6FC: #Great Fairy's Mask, Deku Mask, Keaton Mask, Bremen Mask
		//      MEM 0x801EF700: #Bunny Hood, Don Gero's Mask, Mask of Scents, Goron Mask
		//      MEM 0x801EF704: #Romani's Mask, Circus Leader's Mask, Kafei's Mask, Couple's Mask
		//      MEM 0x801EF708: #Mask of Truth, Zora Mask, Kamaro's Mask, Gibdo Mask
		//      MEM 0x801EF70C: #Garo's Mask, Captain's Hat, Giant's Mask, Fierce Deity's Mask
        public const int CST_INVENTORY_OCARINA = 0x1EF6E0; // 00=Got, FF=Nothing
        public const int CST_INVENTORY_HERO_BOW = 0x1EF6E1; // 01=Got, FF=Nothing
        public const int CST_INVENTORY_FIRE_ARROWS = 0x1EF6E2; // 02=Got, FF=Nothing
        public const int CST_INVENTORY_ICE_ARROWS = 0x1EF6E3; // 03=Got, FF=Nothing
        public const int CST_INVENTORY_LIGHT_ARROWS = 0x1EF6E4; // 04=Got, FF=Nothing
        public const int CST_INVENTORY_BOMB = 0x1EF6E6; // Bomb 1EF6E5 // 06=Got, FF=Nothing        
        public const int CST_INVENTORY_BOMBCHUS = 0x1EF6E7; // Bombchus 1EF6E4 // 07, FF
        public const int CST_INVENTORY_DEKU_STICKS = 0x1EF6E8; // Deku Sticks = 1EF6EB // 08, FF
        public const int CST_INVENTORY_DEKU_NUTS = 0x1EF6E9; // Deku nuts = 1EF6EA // 09, FF
        public const int CST_INVENTORY_MAGIC_BEANS = 0x1EF6EA;// Magic Beans = 1EF6E9 // 0A, FF
        public const int CST_INVENTORY_POWDER_KEG = 0x1EF6EC;// Powder Keg 1EF6EF // 0C, FF
        public const int CST_INVENTORY_PICTOGRAPH_BOX = 0x1EF6ED;// Pictograph Box 1EF6EE // 0D, FF
        public const int CST_INVENTORY_LENS_OF_TRUTH = 0x1EF6EE;// Lens Of truth 1EF6ED // 0E, FF
        public const int CST_INVENTORY_HOOKSHOT = 0x1EF6EF;// Hooksot 1EF6EC // 0F, FF

        public const int CST_INVENTORY_GREAT_FAIRY_SWORD = 0x1EF6F3;// Great Fairy's 1EF6F3 Sword // 10, FF

        public const int CST_INVENTORY_TRADING_ITEM_1 = 0x1EF6F0;// Trading Item 1 1EF6E6 // 28..2C=Moon's Tear, Land Title Deed, Swmap Title Deed, Mountain Tiutle Deed, Ocean Title Deed, FF=Nothing
        public const int CST_INVENTORY_TRADING_ITEM_2 = 0x1EF6EB;// Trading Item 2 1EF6E8 // 2D..2E=Room Key, Special Delivery To Mama, FF=Nothing
        public const int CST_INVENTORY_TRADING_ITEM_3 = 0x1EF6F1;// Trading Item 3 1EF6F2 // 2F..30=Letter to Kafei, Pendant Of Memories, FF=Nothing
        public const int CST_INVENTORY_BOTTLE_1 = 0x1EF6F2;// Bottle 1 1EF6F1 // Lazy to find value, FF=Nothing
        public const int CST_INVENTORY_BOTTLE_2 = 0x1EF6F3;// Bottle 2 1EF6F0 // Lazy to find value, FF=Nothing
        public const int CST_INVENTORY_BOTTLE_3 = 0x1EF6F4;// Bottle 3 1EF6F7 // Lazy to find value, FF=Nothing
        public const int CST_INVENTORY_BOTTLE_4 = 0x1EF6F5;// Bottle 4 1EF6F6 // Lazy to find value, FF=Nothing
        public const int CST_INVENTORY_BOTTLE_5 = 0x1EF6F6;// Bottle 5 1EF6F5 // Lazy to find value, FF=Nothing
        public const int CST_INVENTORY_BOTTLE_6 = 0x1EF6F7;// Bottle 6 1EF6F4 // Lazy to find value, FF=Nothing

        #endregion

        #region INVENTORY Masks

        public const int CST_MASK_DEKU_MASK = 0x1EF6FE; // Deku mask 1EF6FE // 32, FF
        public const int CST_MASK_GORON_MASK = 0x1EF700; // Goron Mask 1EF700 // 33, FF
        public const int CST_MASK_ZORA_MASK = 0x1EF70A; // Zora Mask 1EF70A // 34, FF
        public const int CST_MASK_FIERCE_DEITY_MASK = 0x1EF70C; // Fierce Deity's Mask 1EF70C // 35, FF
        public const int CST_MASK_POSTMAN_HAT = 0x1EF6F8; // Postman's Hat 1EF6FB // 3E, FF
        public const int CST_MASK_ALL_NIGHT_MASK = 0x1EF6F9; // All-Night Mask 1EF6FA // 38, FF
        public const int CST_MASK_BLAST_MASK = 0x1EF6FA; // Blast Mask 1EF6F9 // 47, FF
        public const int CST_MASK_STONE_MASK = 0x1EF6FB; // Stone Mask 1EF6F8 // 45, FF
        public const int CST_MASK_GREAT_FAIRY_MASK = 0x1EF6FC; // Great Fairy's Mask 1EF6FF // 40, FF
        public const int CST_MASK_KEATON_MASK = 0x1EF6FE; // Keaton Mask 1EF6FD // 3A, FF
        public const int CST_MASK_BREMEN_MASK = 0x1EF6FF; // Bremen Mask 1EF6FC // 46, FF
        public const int CST_MASK_BUNNY_HOOD = 0x1EF700; // Bunny Hood 1EF703 // 39, FF
        public const int CST_MASK_DON_GERO_MASK = 0x1EF701; // Don Gero's Mask 1EF702 // 42, FF
        public const int CST_MASK_MASK_OF_SCENTS = 0x1EF702; // Mask of SCents 1EF701 // 48, FF
        public const int CST_MASK_ROMANI_MASK = 0x1EF704; // Romani's Mask 1EF707 // 3C, FF
        public const int CST_MASK_CIRCUS_LEADER_MASK = 0x1EF705; // Circus Leader's Mask 1EF706 // 3D, FF
        public const int CST_MASK_KAFEI_MASK = 0x1EF706; // Kafei's Mask 1EF705 // 37, FF
        public const int CST_MASK_COUPLE_MASK = 0x1EF707; // Couple's Mask 1EF704 // 3F, FF
        public const int CST_MASK_MASK_OF_TRUTH = 0x1EF708; // Mask of Truth 1EF70B // 36, FF
        public const int CST_MASK_KAMARO_MASK = 0x11EF70A; // Kamaro's Mask 1EF709 // 43, FF
        public const int CST_MASK_GIBDO_MASK = 0x1EF70B; // Gibdo Mask 1EF708 // 41, FF
        public const int CST_MASK_GARO_MASK = 0x1EF70C; // Garo's Mask 1EF70F // 3B, FF
        public const int CST_MASK_CAPTAIN_HAT = 0x1EF70D; // Captain's Hat 1EF70E // 44, FF
        public const int CST_MASK_GIANT_MASK = 0x1EF70E; // Giant's Mask 1EF70D // 49, FF

        #endregion

        #region INVENTORY Quest Items

        // Dugeon Items TODO


        // MEM 0x801EF72B: [Byte] #Quiver & Bomb Bag
        // 0x01 Quiver(Holds 30)
        // 0x02 Quiver(Holds 40)
        // 0x03 Quiver(Holds 50)
        // 0x08 Bomb Bag(Holds 20)
        // 0x10 Bomb Bag(Holds 30)
        // 0x18 Bomb Bag(Holds 40)
        public const int CST_INVENTORY_ADDRESS_QUIVER_BOMB_BAG = 0x1EF72B;
        public const int CST_INVENTORY_VALUE_QUIVER_30 = 0x01; 
        public const int CST_INVENTORY_VALUE_QUIVER_40 = 0x02; 
        public const int CST_INVENTORY_VALUE_QUIVER_50 = 0x03; 
        public const int CST_INVENTORY_VALUE_BOMB_BAG_20 = 0x20;
        public const int CST_INVENTORY_VALUE_BOMB_BAG_30 = 0x30;
        public const int CST_INVENTORY_VALUE_BOMB_BAG_40 = 0x40;

        // MEM 0x801EF72C: [Byte] #Lullaby Intro & Heart Pieces
        // 0x01 Lullaby Intro
        // 0x10 1 Heart Container
        // 0x20 2 Heart Containers
        // 0x30 3 Heart Containers
        public const int CST_INVENTORY_ADDRESS_LULLABY_INTRO_AND_HEART_PIECES = 0x1EF72C;
        public const int CST_INVENTORY_VALUE_LULLABY_INTRO = 0x01;

        // MEM 0x801EF72D: [Byte] #Song of Storms, Sun's Song & Bomber's Notebook
        // 0x01 Song of Storms
        // 0x02 Sun's Song
        // 0x04 Bomber's Notebook
        public const int CST_INVENTORY_ADDRESS_SONG_AND_BOMBER_NOTEBOOK = 0x1EF72D;
        public const int CST_INVENTORY_VALUE_SONG_OF_STORMS = 0x01;
        public const int CST_INVENTORY_VALUE_SUN_SONG = 0x02;
        public const int CST_INVENTORY_VALUE_BOMBER_NOTEBOOK = 0x04;

        // MEM 0x801EF72E: [Byte] #Songs
        // 0x01 New Wave Bossa Nova
        // 0x02 Elegy of Emptiness
        // 0x04 Oath to Order
        // 0x08 Saria's Song
        // 0x10 Song of Time
        // 0x20 Song of Healing
        // 0x40 Epona's Song
        // 0x80 Song of Soaring
        public const int CST_INVENTORY_ADDRESS_PARTIAL_SONG = 0x1EF72E;
        public const int CST_INVENTORY_VALUE_SONG_NEW_WAVE_BOSSA_NOVA = 0x01;
        public const int CST_INVENTORY_VALUE_SONG_ELEGY_OF_EMPTINESS = 0x02;
        public const int CST_INVENTORY_VALUE_SONG_OATH_TO_ORDER = 0x04;
        public const int CST_INVENTORY_VALUE_SONG_SARIA_SONG = 0x08;
        public const int CST_INVENTORY_VALUE_SONG_OF_TIME = 0x10;
        public const int CST_INVENTORY_VALUE_SONG_OF_HEALING = 0x20;
        public const int CST_INVENTORY_VALUE_EPONA_SONG = 0x40;
        public const int CST_INVENTORY_VALUE_SONG_OF_SOARING = 0x80;

        // MEM 0x801EF72F: [Byte] #Sonata of Awakening, Goron Lullaby & Remains
        // 0x01 Odolwa's Remains
        // 0x02 Goht's Remains
        // 0x04 Gyorg's Remains
        // 0x08 Twinmold's Remains
        // 0x40 Sonata of Awakening
        // 0x80 Goron Lullaby
        public const int CST_INVENTORY_ADDRESS_SONG_AND_REMAINS = 0x1EF72F;
        public const int CST_INVENTORY_VALUE_ODOLWA_REMAINS = 0x01;
        public const int CST_INVENTORY_VALUE_GOHT_REMAINS = 0x02;
        public const int CST_INVENTORY_VALUE_GYORG_REMAINS = 0x04;
        public const int CST_INVENTORY_VALUE_TWINMODL_REMAINS = 0x08;
        public const int CST_INVENTORY_VALUE_SONG_SONATA_OF_AWAKENING = 0x40;
        public const int CST_INVENTORY_VALUE_SONG_GORON_LULLABY = 0x80;

        #endregion

        #region Dungeon Items

        // Woodfall
        // Map
        // Compass
        // Boss Key
        // Key
        // Fairies

        // Snow Head
        // Map
        // Compass
        // Boss Key
        // Key
        // Fairies

        // Great Bay
        // Map
        // Compass
        // Boss Key
        // Key
        // Fairies

        // Stone Tower
        // Map
        // Compass
        // Boss Key
        // Key
        // Fairies

        #endregion

        #region Other

        // MEM 0x801EF690: [Byte] #Form
		// 0x00 Fierce Deity
		// 0x01 Goron
		// 0x02 Zora
		// 0x03 Deku
		// 0x04 Link
        public const int CURRENT_TRANSFORMATION = 0x1EF690;

        public const int CST_ADDRESS_CURRENT_RUPEE = 0x1EF6A;

        #endregion
    }
}
