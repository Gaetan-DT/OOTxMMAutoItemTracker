using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker
{
    class MMOffsets
    {
        // Stored in Litte Endian, need Big Endian converter
        const int CST_LINK_INSTANCE = 0x3FFDB0; //Default: 0x803FFDB0

        //link_state: number = 0xA6C;
        //current_scene: number = 0x803e6bc4;
        //scene_framecount: number = 0x803FF360;
        //checksum: number = 0x801EF694;
        //paused: number = 0x801D1500;
        //interface_shown: number = 0x803FD77B;
        //save_context: number = 0x801EF670;
        //mask_offset: number = 0x0020;
        //anim: number = 0x400500;

        //continue_state_addr: number = 0x0; //TODO: Find for MM

        //sword_addr: number = 0x801EF6DD;
        //shield_addr: number = 0x801EF6DD;

        //current_room_addr: number = 0x803FF20C;

        //global_context_pointer: number = 0x801F9C60;

        //overlay_table: number = 0x801AEFD0;
        //gui_isShown: number = 0x803FD77B;
        //Save Context

        //intro_flag: number = 0x801EF675; //0x1
        //have_tatl: number = 0x801EF692; //0x1
        /*
        0x0000 = 12:00 AM
        0x1000 = 01:30 AM
        0x2000 = 03:00 AM
        0x3000 = 04:30 AM
        0x4000 = 06:00 AM
        0x402D = Dawn of Day
        0x5000 = 07:30 AM
        0x6000 = 09:00 AM
        0x7000 = 10:30 AM
        0x8000 = 12:00 PM
        0x9000 = 01:30 PM
        0xA000 = 03:00 PM
        0xB000 = 04:30 PM
        0xC000 = 06:00 PM
        0xD000 = 07:30 PM
        0xE000 = 09:00 PM
        0xF000 = 10:30 PM
        0xFFFF = 11:59 PM
        */
        //day_time: number = 0x801EF67C; //0x2 
        //day_night: number = 0x801EF680; //0x4 // set to 0 during day, 1 at night
        //time_speed: number = 0x801EF684; //0x4 // normally 1 when inverted song of time and 3 at normal speed; rando can change this
        //current_day: number = 0x801EF688; //0x4 //0 to 4. modulo 5?

        public const int CURRENT_TRANSFORMATION = 0x1EF693; //BE=1EF693 Default:0x801EF690 Length:0x1 from 0: fierce deity, goron, zora, deku, human

        //pictograph_photo_addr: number = 0x801F0750; //0x2BC0
        //pictograph_spec: number = 0x801F04EA; //0x1
        //pictograph_quality: number = 0x801F04EB; //0x1
        //pictograph_unk: number = 0x801F04EC; //0x1

        //map_visited: number = 0x801F05CC; //0x4
        //map_visible: number = 0x801F05D0; //0x4
        //minimap_flags: number = 0x801F0514; //0xE

        //max_heart_flag: number = 0x801EF6A4; //0x2
        //hearts: number = 0x801EF6A6; //0x2
        //health_mod: number = 0x801F35CA; //0x1
        //magic: number = 0x801EF6A9; //0x1
        //rupees: number = 0x801EF6AA; //0x2

        //magic_meter_size_addr: number = 0x801EF6A8;
        //magic_current_addr: number = 0x801F35A0;
        //magic_limit_ad    dr: number = 0x801F359E;
        //magic_flag_1_addr: number = 0x801EF6B0;
        //magic_flag_2_addr: number = 0x801EF6B1;

        //deku_b_addr: number = 0x801EF6C8;

        //razor_hits: number = 0x801EF6AC; // 0x2

        //owl_statues: number = 0x801EF6B6; //0x2
        //sword_equip: number = 0x801EF6BC; // 0x1
        //tunic_boots: number = 0x801EF6DC; //0x1
        //sword_sheild: number = 0x801EF6DD;
        // public const int CST_INVENTORY = 0x1EF6E0; // Length: 0x18 //inventory: number = 0x801EF6E0; //0x18

        #region Link 

        // Magic meter 1EF6AB // 0..2 = No magic, small, large
        // Double Defense 1EF740 // Left part bit 4 and Right part bit 2

        #endregion

        #region INVENTORY Equipment

        // Equiped value
        // First byte for shield: 0..2=None, Hero, Mirror
        // Second byte for sword: 0..3=None, Kokiri, Razor, Gilded
        // SwordAndShield = 1EF6DE //

        // Sword = 1EF6BF // 4D..4F=Kokiri, Razor, Gilded FF=None
        // TODO: Find Shield only address if exist

        // Wallet 1EF729 // 00=Child, 10=Adult, 20=Giant

        // ___B B_QQ
        // 0000 0000
        // Quiver and Bombbag 1EF728
        // Quiver 1EF728 // read two last byte = 0, 1, 2, 3 = None, Normal, Large, Largest
        // Bombbag 1EF728 // read bit 4 and 5 = 0, 1, 2, 3 = None, Normal, Big, Biggest

        // Bomber's Notebook 1EF72E // right part bit 2: Bomber's

        #endregion

        #region INVENTORY C-Button Items
        public const int CST_INVENTORY_OCARINA = 0x1EF6E3; // 00=Got, FF=Nothing
        public const int CST_INVENTORY_HERO_BOW = 0x1EF6E2; // 01=Got, FF=Nothing
        public const int CST_INVENTORY_FIRE_AARROWS = 0x1EF6E0; // 02=Got, FF=Nothing
        public const int CST_INVENTORY_ICE_ARROWS = 0x1EF6E1; // 03=Got, FF=Nothing
        public const int CST_INVENTORY_LIGHT_ARROWS = 0x1EF6E7; // 04=Got, FF=Nothing

        // TODO
        // Bomb 1EF6E5 // 06=Got, FF=Nothing
        // Bombchus 1EF6E4 // 07, FF
        // Deku Sticks = 1EF6EB // 08, FF
        // Deku nuts = 1EF6EA // 09, FF
        // Magic Beans = 1EF6E9 // 0A, FF
        // Powder Keg 1EF6EF // 0C, FF
        // Pictograpg Box 1EF6EE // 0D, FF
        // Lens Of truth 1EF6ED // 0E, FF
        // Hooksot 1EF6EC // 0F, FF
        // Great Fairy's 1EF6F3 Sword // 10, FF
        // Trading Item 1 1EF6E6 // 28..2C=Moon's Tear, Land Title Deed, Swmap Title Deed, Mountain Tiutle Deed, Ocean Title Deed, FF=Nothing
        // Trading Item 2 1EF6E8 // 2D..2E=Room Key, Special Delivery To Mama, FF=Nothing
        // Trading Item 3 1EF6F2 // 2F..30=Letter to Kafei, Pendant Of Memories, FF=Nothing
        // Bottle 1 1EF6F1 // Lazy to find value, FF=Nothing
        // Bottle 2 1EF6F0 // Lazy to find value, FF=Nothing
        // Bottle 3 1EF6F7 // Lazy to find value, FF=Nothing
        // Bottle 4 1EF6F6 // Lazy to find value, FF=Nothing
        // Bottle 5 1EF6F5 // Lazy to find value, FF=Nothing
        // Bottle 6 1EF6F4 // Lazy to find value, FF=Nothing

        #endregion

        #region INVENTORY Masks

        // Deku mask 1EF6FE // 32, FF
        // Goron Mask 1EF700 // 33, FF
        // Zora Mask 1EF70A // 34, FF
        // Fierce Deity's Mask 1EF70C // 35, FF
        // Postman's Hat 1EF6FB // 3E, FF
        // All-Night Mask 1EF6FA // 38, FF
        // Blast Mask 1EF6F9 // 47, FF
        // Stone Mask 1EF6F8 // 45, FF
        // Great Fairy's Mask 1EF6FF // 40, FF
        // Keaton Mask 1EF6FD // 3A, FF
        // Bremen Mask 1EF6FC // 46, FF
        // Bunny Hood 1EF703 // 39, FF
        // Don Gero's Mask 1EF702 // 42, FF
        // Mask of SCents 1EF701 // 48, FF
        // Romani's Mask 1EF707 // 3C, FF
        // Circus Leader's Mask 1EF706 // 3D, FF
        // Kafei's Mask 1EF705 // 37, FF
        // Couple's Mask 1EF704 // 3F, FF
        // Mask of Truth 1EF70B // 36, FF
        // Kamaro's Mask 1EF709 // 43, FF
        // Gibdo Mask 1EF708 // 41, FF
        // Garo's mMask 1EF70F // 3B, FF
        // Captain's Hat 1EF70E // 44, FF
        // Giant's Mask 1EF70D // 49, FF

        #endregion

        #region INVENTORY Quest Items

        // Dugeon Items TODO

        //   1EF72C     1EF72D     1EF72E    1EF72F
        // 0000 0000  0000 0000  0000 1010  0011 0000 = Nothing/Default value
        //                 X -> Song of time
        // Songs [1EF72C, 1EF72D, 1EF72E, 1EF72F]

        // Bit read left to right (ex 1234 1234)
        // Song of Time 1EF72D // Right part bit 1
        // Song of Healing 1EF72D // Left part bit 3
        // Epona's Song 1EF72D // Left part bit 2
        // Song of Soaring 1EF72D // Left part bit 1
        // Song of Storms 1EF72E // Right part bit 4
        // Sonata of Awakening 1EF72C // Left part bit 2
        // Goron Lullaby - Lullaby Intro 1EF72F // Right part bit 4 (0=none, 1=Lullaby)
        // Goron Lullaby - Goron Lullaby 1EF72C // Left part bit 1 (0=None, 1=Lullaby (Intro must be mandatory))
        // New Wave Bossa Nova 1EF72D // Right part bit 4
        // Elegy of EMptyness 1EF72D // Right part bit 3
        // Oath to Order 1EF72D // Right part bit 2

        // Boss Masks

        // Odolwa 1EF72C // Right part bit 4
        // Goht 1EF72C // Right part bit 3
        // Gyorg 1EF72C // Right part bit 2
        // Twinmold 1EF72C // Right part bit 1

        #endregion

        //masks: number = 0x801EF6F8; //0x18
        //item_amts: number = 0x801EF710; //0x18
        //upgrades: number = 0x801EF728; //0x4

        //quest items
        //questflg1: number = 0x801EF72C; //0x1 bit 0: Lullaby Intro; bits 4-7: heart pieces
        //questflg2: number = 0x801EF72D; //0x1 bits 0-1: songs; bit 2: Bomber's Notebook; bit 3: unknown
        //questflg3: number = 0x801EF72E; //0x1 bits 0-7: songs
        //questflg4: number = 0x801EF72F; //0x1 bits 0-3: Remains; bits 6-7: songs

        //woodfall_item: number = 0x801EF730; //0x1 bitfield
        //snowhead_item: number = 0x801EF731; //0x1 bitfield
        //bay_item: number = 0x801EF732; //0x1 bitfield
        //stone_item: number = 0x801EF733; //0x1 bitfield

        //double_defense: number = 0x801EF743; //0x1
        //scene_flags = 0x801EF768; //0xD20 dig chest flags out of here
        //bank_rupees = 0x801F054E; //0x2

        //event_flg: number = 0x801F0568;
        //event_inf: number = 0x801F067C;

        //switch_flags_addr = 0x803E8978; //Might be wrong
        //temp_switch_flags_addr = 0x803E8988; //Wrong
        //chest_flags_addr = 0x803E8988;
        //room_clear_flags_addr = 0x803E8994; //Wrong
        //collectable_flag_addr = 0x803E8994;

        //woodfall_fairies = 0x801EF744; //0x1
        //snowhead_fairies = 0x801EF745; //0x1
        //bay_fairies = 0x801EF746; //0x1
        //stone_fairies = 0x801EF747; //0x1

        //swamp_skulltula = 0x801F0530; //0x2
        //bay_skulltula = 0x801F0532; //0x2

        //misc
        //mask_object_vram = 0x80402B50;
        //mask_props = 0x801F58B0;

        //lottery_numbers_day1 = 0x801F065C; //0x3
        //lottery_numbers_day2 = 0x801F065F; //0x3
        //lottery_numbers_day3 = 0x801F0662; //0x3
        //spider_house_mask_order = 0x801F0665; //0x6
        //bomber_code = 0x801F066B; //0x5

        //permFlags = 0x801F35D8; // 0x960
    }
}
