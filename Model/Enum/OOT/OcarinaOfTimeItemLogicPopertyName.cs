using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OcarinaOfTimeItemLogicPopertyName
    {
        Deku_Stick,
        Deku_Nut,
        Bomb,
        Bow,
        Fire_Arrow,
        Din_Fire,
        Fairy_Slingshot,
        Ocarina,
        Bombchu,
        Hookshot,
        Ice_Arrow,
        Farore_Wind,
        Boomerang,
        Lens_of_Truth,
        Magic_Bean,
        Megaton_Hammer,
        Light_Arrow,
        Nayru_Love,
        Bottle_1,
        Bottle_2,
        Bottle_3,
        Bottle_4,
        Weird_Egg,
        Mask_Quest,
        Kokiri_Sword,
        Master_Sword,
        Giant_Knife_Biggoron_Sword,
        Stone_of_Agony,
        Gerudo_Card,
        Gold_Skulltula,
        Deku_Shield,
        Hylian_Shield,
        Mirror_Shield,
        Goron_Bracelet,
        Scale,
        Wallet,
        Kokiri_Tunic,
        Goron_Tunic,
        Zora_Tunic,
        Heart_Container,
        Magic,
        Kokiri_Boots,
        Iron_Boots,
        Hover_Boots,
        Kokiri_Emerald,
        Goron_Ruby,
        Zora_Sapphire,
        Forest_Medallion,
        Fire_Medallion,
        Water_Medallion,
        Spirit_Medallion,
        Shadow_Medallion,
        Light_Medallion,
        Minuet_of_Forest,
        Bolero_of_Fire,
        Serenade_of_Water,
        Requiem_of_Spirit,
        Nocturne_of_Shadow,
        Prelude_of_Light,
        Zelda_Lullaby,
        Epona_Song,
        Saria_Song,
        Sun_Song,
        Song_of_Time,
        Song_of_Storms

    }

    class OcarinaOfTimeItemLogicPopertyNameMethod
    {
        public static OcarinaOfTimeItemLogicPopertyName FromString(string value)
        {
            return (OcarinaOfTimeItemLogicPopertyName) System.Enum.Parse(typeof(OcarinaOfTimeItemLogicPopertyName), value);
        }

        public static String ToString(OcarinaOfTimeItemLogicPopertyName value)
        {
            return value.ToString();
        }
    }
}
