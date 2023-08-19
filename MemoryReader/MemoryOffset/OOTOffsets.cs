namespace MajoraAutoItemTracker.Model
{
    class OOTOffsets // Address set in Little endian
    {
        // To find it we need to check 32byte that match:   'ZELD' ->  0x5A454C44 (1514490948)
        // If done the next 32 byte should match :          'AZ  ' ->  0x415A0000 (1096417280)
        public const int ZELDAZ_CHECK_BE = 0x5A454C44;   // = 
        public const int ZELDAZ_CHECK_2_BE = 0x415A0000; // = 

        public const int ZELDAZ_CHECK_LE = 0x444C455A;

        // Src: https://www.gamegenie.com/cheats/gameshark/n64/legend_of_zelda_oot.html
        // Game shark usage, first part is emulator address (need to remove '80') second part is value to set

        //8011A64B 0007     Have Fairy Ocarina
        //8011A64B 0008     Have Ocarina of Time
        public const int CST_INVENTORY_ADDRESS_OCARINA = 0x11A64B;
        public const int CST_INVENTORY_VALUE_OCARINA_VALUE_FAIRY_OCARINA = 0x07;
        public const int CST_INVENTORY_VALUE_OCARINA_VALUE_OCARINA_OF_TIME = 0x08;


        //8011A80B 0007     Always Have Fairy Ocarina
        //8011A80B 0008     Have Ocarina of Time

        //Version 1.0
        //8011B9E3 0020     Beta Quest
        //8111A605 03E7     Unlimited Rupees
        //8011B9A1 003B     Infinite Time To Ride Epona at Lon Lon's Ranch

        //8011A64D 000A     Have Hookshot
        //8011A64D 000B     Have Longshot
        //8011A650 000E     Have Boomerang
        //8011A651 000F     Have Lens of Truth
        //8011A652 0010     Have Magic Beans
        //8011A66A 0009     Infinite Magic Beans
        //8011A653 0011     Have Megaton Hammer
        //8011A60E 0001     Turn Giant's Knife Into Biggoron's Sword 
        //8011A671 0001     Have Quiver(Holds 30)
        //8011A699 0009     Infinite Small Keys
        //8011A678 0007     Have Big Key, Compass, & Map 

        //8011A649 0005     Have Din's Fire (MP6)
        //8011A64F 000D     Have Fairies Wind(MP6)
        //8011A655 0013     Have Nayru's Love (MP12)
        //8011A644 0000     Have Deku Stick
        //8011A65C 0009     Infinite Deku Sticks
        //8011A645 0001     Have Deku Nut
        //8011A65D 0009     Infinite Deku Nuts
        //8011A646 0002     Have Bombs
        //8011A65E 0009     Infinite Bombs
        //8011A647 0003     Have Fairy Bow
        //8011A65F 0009     Infinite Arrows
        //8011A64A 0006     Have Fairy Slingshot
        //8011A662 0009     Infinite Slingshot Ammo
        //8011A64C 0009     Have Bombchu
        //8011A664 0009     Infinite Bombchu's
        //8011A648 0004     Have Fire Arrow(MP2)
        //8011A64E 000C     Have Ice Arrow(MP2)
        //8011A654 0012     Have Light Arrow(MP4)
        //8111A600 0140     Infinite Energy
        //8111A5FE 0140     Max Heart
        //8011A6A1 00FF     Skulltulas Killed
        //8111A66C 7777     All Equipment

        //8111A7C4 03E7     Have 999 Rupees
        //8133F1DE 03E7

        //8111A674 30FF     All Quest/Status Items
        //8111A676 FFFF

        //D01C84B5 0020     L Button For Moon Jump
        //811DAA90 40CB

        //D01C84B5 0030     Hover Boots Last While Holding L & R Buttons
        //811DB2B2 000D

        //D011A609 0008     Infinite Magic
        //8011A60A 0001
        //8011A60C 0001
        //8011A603 0060

        //8011A639 0011     C Left to Use Hammer
        //NOTE: You will be able to use the Hammer when you are a kid, but you will
        //not see it.

        //8011A656 00xx Have Bottle 1 Modifier
        //8011A657 00xx Have Bottle 2 Modifier
        //8011A658 00xx Have Bottle 3 Modifier
        //8011A659 00xx Have Bottle 4 Modifier
        //Replace xx with:
        //14     Empty Bottle
        //15     Red Potion
        //16     Green Potion
        //17     Blue Potion
        //18     Bottled Fairy
        //19     Fish
        //1A Lon Lon Milk
        //1B Letter
        //1C Blue Fire
        //1D     Bug
        //1E     Big Poe
        //1F     Lon Lon Milk (Half)
        //20     Poe

        //8011A65A 00xx Item Modifier 1
        //Replace xx with:
        //2D     Pocket Egg
        //2E     Pocket Cucco
        //2F     Cojiro
        //30     Odd Mushroom
        //31     Odd Potion
        //32     Poacher's Saw
        //33     Goron's Sword (Broken)
        //34     Prescription
        //35     Eyeball Frog
        //36     Eye Drops
        //37     Claim Check

        //8011A65B 00xx Item Modifier 2
        //Replace xx with:
        //21     Weird Egg
        //22     Chicken
        //23     Zelda's Letter
        //24     Keaton Mask
        //25     Skull Mask
        //26     Spooky Mask
        //27     Bunny Hood
        //28     Goron Mask
        //29     Zora Mask
        //2A Gerudo Mask
        //2B Mask of Truth
        //2C SOLD OUT

        //8011A672 00xx Equipment Modifier 1
        //Replace xx with:
        //02     Silver Scale
        //04     Golden Scale
        //06     Giant's Knife (Broken)
        //40     Bullet Bag (Holds 30)
        //80     Bullet Bag(Holds 40)
        //C0 Bullet Bag(Holds 50)

        //8011A673 00xx Equipment Modifier 2
        //Replace xx with:
        //08     Bomb Bag(Holds 20)
        //10     Bomb Bag(Holds 30)
        //18     Bomb Bag(Holds 40)
        //20     Goron's Bracelet
        //28     Silver Gauntlets
        //30     Silver Scale

        //8011A640 00xx Equipped Stuff Modifier
        //Replace xx with:
        //11     Kokiri Tunic & Kokiri Boots
        //12     Goron Tunic & Kokiri Boots
        //13     Zora Tunic & Kokiri Boots
        //21     Kokiri Tunic & Iron Boots
        //22     Goron Tunic & Iron Boots
        //23     Zora Tunic & Iron Boots
        //31     Kokiri Tunic & Hover Boots
        //32     Goron Tunic & Hover Boots
        //33     Zora Tunic & Hover Boots

        //8111A5DC xxxx     Time of Day Modifier
        //Replace xxxx with:
        //4000     At Sunrise
        //5800     Daylight Out
        //7000     Very Bright Out
        //C000     At Sunset
        //D000 Fairly Dark

        //Version 1.1


        //8011A80D 000A Always Have Hookshot
        //8011A80D 000B Always Have Longshot
        //8011A810 000E     Always Have Boomerang
        //8011A811 000F     Always Have Lens of Truth
        //8011A812 0010     Always Have Magic Beans
        //8011A82A 0009     Infinite Magic Beans
        //8011A813 0011     Always Have Megaton Hammer 
        //8011A7CE 0001     Turn Giant's Knife Into Biggoron's Sword 
        //8011A831 0001     Have Quiver(Holds 30)
        //8011A859 0009     Infinite Small Keys
        //8011A838 0007     Have Big Key, Compass, & Map 

        //8011A809 0005     Have Din's Fire (MP6)
        //8011A80F 000D     Have Fairies Wind(MP6)
        //8011A815 0013     Have Nayru's Love (MP12)
        //8011A804 0000     Have Deku Stick
        //8011A81C 0009     Infinite Deku Sticks
        //8011A805 0001     Have Deku Nut
        //8011A81D 0009     Infinite Deku Nuts
        //8011A806 0002     Have Bombs
        //8011A81E 0009     Infinite Bombs
        //8011A807 0003     Have Fairy Bow
        //8011A81F 0009     Infinite Arrows
        //8011A80A 0006     Have Fairy Slingshot
        //8011A822 0009     Infinite Slingshot Ammo
        //8011A80C 0009     Have Bombchu
        //8011A824 0009     Infinite Bombchu's
        //8011A808 0004     Have Fire Arrow(MP2)
        //8011A80E 000C Have Ice Arrow(MP2)
        //8011A814 0012     Have Light Arrow(MP4)
        //8111A7C0 0140     Infinite Energy
        //8111A7BE 0140     Max Heart
        //8011A861 00FF Skulltulas Killed
        //8111A82C 7777     All Equipment

        //D01C8675 0020     L Button For Moon Jump
        //811DAC50 40CB

        //D01C8675 0030     Hover Boots Last While Holding L & R Buttons
        //811DB472 000D

        //D011A7C9 0008     Infinite Magic
        //8011A7CA 0001
        //8011A7CC 0001
        //8011A7C3 0060

        //8111A834 30FF All Quest/Status Items
        //8111A836 FFFF

        //8011A7F9 0011     C Left to Use Hammer
        //NOTE: You will be able to use the Hammer when you are a kid, but you
        //will not see it.

        //8011A816 00xx Always Have Bottle 1 Modifier
        //8011A817 00xx Always Have Bottle 2 Modifier
        //8011A818 00xx Always Have Bottle 3 Modifier
        //8011A819 00xx Always Have Bottle 4 Modifier
        //Replace xx with:
        //14     Empty Bottle
        //15     Red Potion
        //16     Green Potion
        //17     Blue Potion
        //18     Bottled Fairy
        //19     Fish
        //1A Lon Lon Milk
        //1B Letter
        //1C Blue Fire
        //1D     Bug
        //1E     Big Poe
        //1F     Lon Lon Milk (Half)
        //20     Poe

        //8011A81A 00xx Item Modifier 1
        //Replace xx with:
        //2D     Pocket Egg
        //2E     Pocket Cucco
        //2F     Cojiro
        //30     Odd Mushroom
        //31     Odd Potion
        //32     Poacher's Saw
        //33     Goron's Sword (Broken)
        //34     Prescription
        //35     Eyeball Frog
        //36     Eye Drops
        //37     Claim Check

        //8011A81B 00xx Item Modifier 2
        //Replace xx with:
        //21     Weird Egg
        //22     Chicken
        //23     Zelda's Letter
        //24     Keaton Mask
        //25     Skull Mask
        //26     Spooky Mask
        //27     Bunny Hood
        //28     Goron Mask
        //29     Zora Mask
        //2A Gerudo Mask
        //2B Mask of Truth
        //2C SOLD OUT

        //8011A832 00xx Equipment Modifier 1
        //Replace xx with:
        //02     Silver Scale
        //04     Golden Scale
        //06     Giant's Knife (Broken)
        //40     Bullet Bag (Holds 30)
        //80     Bullet Bag(Holds 40)
        //C0 Bullet Bag(Holds 50)

        //8011A833 00xx Equipment Modifier 2
        //Replace xx with:
        //08     Bomb Bag(Holds 20)
        //10     Bomb Bag(Holds 30)
        //18     Bomb Bag(Holds 40)
        //20     Goron's Bracelet
        //28     Silver Gauntlets
        //30     Silver Scale

        //8011A800 00xx Equipped Stuff Modifier
        //Replace xx with:
        //11     Kokiri Tunic & Kokiri Boots
        //12     Goron Tunic & Kokiri Boots
        //13     Zora Tunic & Kokiri Boots
        //21     Kokiri Tunic & Iron Boots
        //22     Goron Tunic & Iron Boots
        //23     Zora Tunic & Iron Boots
        //31     Kokiri Tunic & Hover Boots
        //32     Goron Tunic & Hover Boots
        //33     Zora Tunic & Hover Boots

        //8111A79C xxxx     Time of Day Modifier
        //Replace xxxx with:
        //4000     At Sunrise
        //5800     Daylight Out
        //7000     Very Bright Out
        //C000     At Sunset
        //D000 Fairly Dark

        //To activate the keycode:

        //Insert any game besides Diddy Kong Racing, 1080* Snowboarding, Ken
        //Griffey Baseball, Banjo-Kazooie or Yoshi Story.Then, on the main menu
        //select the Keycode option to open the Keycode selection screen. Next,
        //select the correct Keycode and follow the on screen instructions.
    }
}
