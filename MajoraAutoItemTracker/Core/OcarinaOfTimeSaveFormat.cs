using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Core
{
    //Src: https://wiki.cloudmodding.com/oot/Save_Format#Save_Context
    internal class OcarinaOfTimeSaveFormat
    {

    }

    //Save Format
    struct SaveFormat
    {
        //0x0000	int32	Entrance index	Stores the entrance Link starts/respawns at. Check the Entrance Table for a listing of all values.
        Int32 EntranceIndex;
        //0x0004	int32	Age Modifier	0 = Adult Link, 1 = Child Link
        Int32 AgeModifier;
        //0x000A	int16	Cutscene Number	Used to trigger cutscenes. Values FFF0 - FFFF trigger cutscenes 0-F.
        Int16 CutsceneNumber;
        //0x000C	int16	World Time	Sets the current time for the world clock
        //0x0010	int32	Night Flag	Denotes that it's night time.
        //0x001C	char[6]	Unknown	Contains the string "ZELDAZ". If different, the save will be considered corrupt even if the checksum is valid
        //0x0022	int16	Death Counter	
        //0x0024	char[8]	Player Name	If the player name is less than 8 characters, the remaining char values will be DF. NTSC and PAL use different character sets to represent player name.
        //0x002C	int16	Disk Drive Only flag	Setting to 1+ will flag the save as a Disk Drive only file. The file cannot be accessed normally (but can be forced), and will crash on copy attempt on a release build
        //0x002E	int16	Heart containers	0x10 is equivalent to 1 heart container
        //0x0030	int16	Health	0x10 is equivalent to 1 full heart
        //0x0032	int8	Magic meter size	automatically sets itself to 0,1 or 2 depending on your upgrades
        //0x0033	int8	Current magic amount	0x30 = half bar, 0x60 = full bar
        //0x0034	uint16_t	Rupees	
        //0x0035	 ?	Biggoron's Sword Flag #1	Set to 01 in conjunction with Biggoron's Sword Flag #2 to prevent having to do the Biggoron's Sidequest
        //0x0038	int16_t	Navi Timer	Increments every cycle, unless the game is paused. Resets whenever a new map is loaded when under a certain value
        //0x003A	int8	Magic Flag #1	first magic upgrade obtained
        //0x003C	int8	Magic Flag #2	Second magic upgrade obtained (pair with 3A)
        //0x003E	int8	Biggoron's Sword Flag #2	The Giant's Knife becomes the Biggoron Sword when this byte is set
        //0x0066	int16	Saved Scene Index	Only set on saving. Used to determine where to spawn when reloading a save.
        //0x0068	byte[7]	Current Button Equips	Stores what items are currently equipped to the buttons. Indexes 0x00-0x03 store B, C-Left, C-Down, C-Right item indexes in that order, while indexes 0x04-0x06 store the offset into the inventory that the C-Left/Down/Right equips are stored at.
        //0x0070	uint16	Currently Equipped Equipment	& 0x000F = Swords
        //& 0x00F0 = Shields
        //& 0x0F00 = Tunics
        //& 0xF000 = Boots
        //0x0074	byte[24]	Inventory	Stores obtained items, from top left to bottom right.
        //0x008C	byte[0xF]	Item Amounts	Stores ammo counts for inventory items, following the same order as the inventory slots. Thus, some are left unused
        //0x009B	byte	Magic Beans Bought	Stores number of Magic Beans that have been bought by the Bean Seller
        //0x009C	uint16	Obtained Equipment	& 0x000F = Swords
        //& 0x0070 = Shields
        //& 0x0700 = Tunics
        //& 0x7000 = Boots
        //0x00A0	uint32	Obtained Upgrades	& 0x0070_0000 = Deku Nut capacity
        //& 0x000E_0000 = Deku Stick capacity
        //& 0x0001_C000 = Bullet Bag
        //& 0x0000_3000 = Wallet
        //& 0x0000_0E00 = Dive Meter
        //& 0x0000_01C0 = Strength Upgrades
        //& 0x0000_0038 = Bomb Bag
        //& 0x0000_0007 = Quiver
        //0x00A4	uint32	Quest Status Items	& 0x0080_0000 = Gold Skulltula Token (Set the first time one is collected)
        //& 0x0040_0000 = Gerudo card
        //& 0x0020_0000 = Stone of Agony
        //& 0x0010_0000 = Zora Sapphire
        //& 0x0008_0000 = Goron Ruby
        //& 0x0004_0000 = Kokiri Emerald
        //& 0x0002_0000 = Song of Storms
        //& 0x0001_0000 = Song of Time
        //& 0x0000_8000 = Sun's Song
        //& 0x0000_4000 = Saria's Song
        //& 0x0000_2000 = Epona's Song
        //& 0x0000_1000 = Zelda's Lullaby
        //& 0x0000_0800 = Prelude of Light
        //& 0x0000_0400 = Nocturne of Shadow
        //& 0x0000_0200 = Requiem of Spirit
        //& 0x0000_0100 = Serenade of Water
        //& 0x0000_0080 = Bolero of Fire
        //& 0x0000_0040 = Minuet of Forest
        //& 0x0000_0020 = Light Medallion
        //& 0x0000_0010 = Shadow Medallion
        //& 0x0000_0008 = Spirit Medallion
        //& 0x0000_0004 = Water Medallion
        //& 0x0000_0002 = Fire Medallion
        //& 0x0000_0001 = Forest Medallion
        //0x00A8	byte[0x14]	Dungeon Items	Indexed by the Scene Index. Each byte contains the following:
        //& 0x01 = Boss Key
        //& 0x02 = Compass
        //& 0x04 = Dungeon Map
        //0x00BC	byte[0x14]	Small Key Amounts	Initialized to 0xFF to not display key icon
        //0x00CF	byte	Double Defense Hearts	Sets how many hearts should be displayed as being "Double Defense" hearts.
        //0x00D0	int16	Gold Skulltula Tokens
        //0x00D4	struct[101] (0x1C bytes)	Permanent Scene Flags	Stores the permanent flags for all scenes. See below.
        //0x0E64	struct (0x20? bytes)	Farore's Wind Warp	If modifying values in-game, the warp point must be unloaded for the new values to take effect
        //0x0E64	long	X Coordinate
        //0x0E68	long	Y Coordinate
        //0x0E6B	long	Z Coordinate
        //0x0E72	short	Y-Axis Rotation	Direction that Link Faces on returning
        //0x0E7A	int16	Entrance Index	Determines which scene Link is transported to. See the Entrance Table.
        //0x0E7F		Map Number	Determines which map of the scene to load
        //0x0E83		Warp Point Set	1 = Warp point set, 0 = unset.
        //0x0EBC	uint32	Big Poe Points	100 * the number of big Poes sold
        //0x0ED4	uint16_t[14]	event_chk_inf	flags for various events (entrance cutscenes)
        //0x0EF0	uint16_t[4]	item_get_inf	likely flags for checking that certain items have been obtained for the first time
        //0x0EF8	uint16_t[30]	inf_table	unknown flags
        //0x1352	uint16_t	Checksum	Checksum of previous 0x9A9 shorts (0x1352 bytes)
    }
}
