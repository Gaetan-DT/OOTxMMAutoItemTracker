using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    public enum OcarinaOfTimeCheckLogicZone
    {
        Spirit_Temple_V,
        Spirit_Temple_MQ,
        Desert_Colossus,
        Haunted_Wastelar,
        Gerudo_Fortress,
        Gerudo_Training_Grounds_V,
        Gerudo_Training_Grounds_MQ,
        Gerudo_Valley,
        Water_Temple_V,
        Water_Temple_MQ,
        Lake_Hylia,
        Lon_Lon_Ranch,
        Hyrule_Field,
        Castle_Town_Entrance,
        Castle_Town,
        Temple_of_Time,
        Hyrule_Castle_Grounds,
        Ganon_Castle_round,
        Ganons_Castle_V,
        Ganons_Castle_MQ,
        Kokiri_Forest,
        Deku_Tree_V,
        Deku_Tree_MQ,
        Lost_Woods,
        Sacred_Forest_Meadow,
        Forest_Temple_V,
        Forest_Temple_MQ,
        Zora_River,
        Zoras_Domain,
        Zora_Fountain,
        Jabu_Jabus_Belly_V,
        Jabu_Jabus_Belly_MQ,
        Ice_Cavern_V,
        Ice_Cavern_MQ,
        Kakariko_Village,
        Bottom_of_the_Well_V,
        Bottom_of_the_Well_MQ,
        Graveyard,
        Shadow_Temple_V,
        Shadow_Temple_MQ,
        Dodongos_Cavern_V,
        Dodongos_Cavern_MQ,
        Death_Mountain,
        Goron_City,
        Fire_Temple_V,
        Fire_Temple_MQ,
        Death_Mountain_Crater
    }

    class OcarinaOfTimeCheckLogicZoneMethod
    {
        public static OcarinaOfTimeCheckLogicZone FromString(string zoneStr)
        {
            switch (zoneStr)
            {
                case "Spirit Temple V":
                    return OcarinaOfTimeCheckLogicZone.Spirit_Temple_V;
                case "Spirit Temple MQ":
                    return OcarinaOfTimeCheckLogicZone.Spirit_Temple_MQ;
                case "Desert Colossus":
                    return OcarinaOfTimeCheckLogicZone.Desert_Colossus;
                case "Haunted Wastelar":
                    return OcarinaOfTimeCheckLogicZone.Haunted_Wastelar;
                case "Gerudo Fortress":
                    return OcarinaOfTimeCheckLogicZone.Gerudo_Fortress;
                case "Gerudo Training Grounds V":
                    return OcarinaOfTimeCheckLogicZone.Gerudo_Training_Grounds_V;
                case "Gerudo Training Grounds MQ":
                    return OcarinaOfTimeCheckLogicZone.Gerudo_Training_Grounds_MQ;
                case "Gerudo Valley":
                    return OcarinaOfTimeCheckLogicZone.Gerudo_Valley;
                case "Water Temple V":
                    return OcarinaOfTimeCheckLogicZone.Water_Temple_V;
                case "Water Temple MQ":
                    return OcarinaOfTimeCheckLogicZone.Water_Temple_MQ;
                case "Lake Hylia":
                    return OcarinaOfTimeCheckLogicZone.Lake_Hylia;
                case "Lon Lon Ranch":
                    return OcarinaOfTimeCheckLogicZone.Lon_Lon_Ranch;
                case "Hyrule Field":
                    return OcarinaOfTimeCheckLogicZone.Hyrule_Field;
                case "Castle Town Entrance":
                    return OcarinaOfTimeCheckLogicZone.Castle_Town_Entrance;
                case "Castle Town":
                    return OcarinaOfTimeCheckLogicZone.Castle_Town;
                case "Temple of Time":
                    return OcarinaOfTimeCheckLogicZone.Temple_of_Time;
                case "Hyrule Castle Grounds":
                    return OcarinaOfTimeCheckLogicZone.Hyrule_Castle_Grounds;
                case "Ganon's Castle Ground":
                    return OcarinaOfTimeCheckLogicZone.Ganon_Castle_round;
                case "Ganon's Castle V":
                    return OcarinaOfTimeCheckLogicZone.Ganons_Castle_V;
                case "Ganon's Castle MQ":
                    return OcarinaOfTimeCheckLogicZone.Ganons_Castle_MQ;
                case "Kokiri Forest":
                    return OcarinaOfTimeCheckLogicZone.Kokiri_Forest;
                case "Deku Tree V":
                    return OcarinaOfTimeCheckLogicZone.Deku_Tree_V;
                case "Deku Tree MQ":
                    return OcarinaOfTimeCheckLogicZone.Deku_Tree_MQ;
                case "Lost Woods":
                    return OcarinaOfTimeCheckLogicZone.Lost_Woods;
                case "Sacred Forest Meadow":
                    return OcarinaOfTimeCheckLogicZone.Sacred_Forest_Meadow;
                case "Forest Temple V":
                    return OcarinaOfTimeCheckLogicZone.Forest_Temple_V;
                case "Forest Temple MQ":
                    return OcarinaOfTimeCheckLogicZone.Forest_Temple_MQ;
                case "Zora River":
                    return OcarinaOfTimeCheckLogicZone.Zora_River;
                case "Zora's Domain":
                    return OcarinaOfTimeCheckLogicZone.Zoras_Domain;
                case "Zora Fountain":
                    return OcarinaOfTimeCheckLogicZone.Zora_Fountain;
                case "Jabu Jabu's Belly V":
                    return OcarinaOfTimeCheckLogicZone.Jabu_Jabus_Belly_V;
                case "Jabu Jabu's Belly MQ":
                    return OcarinaOfTimeCheckLogicZone.Jabu_Jabus_Belly_MQ;
                case "Ice Cavern V":
                    return OcarinaOfTimeCheckLogicZone.Ice_Cavern_V;
                case "Ice Cavern MQ":
                    return OcarinaOfTimeCheckLogicZone.Ice_Cavern_MQ;
                case "Kakariko Village":
                    return OcarinaOfTimeCheckLogicZone.Kakariko_Village;
                case "Bottom of the Well V":
                    return OcarinaOfTimeCheckLogicZone.Bottom_of_the_Well_V;
                case "Bottom of the Well MQ":
                    return OcarinaOfTimeCheckLogicZone.Bottom_of_the_Well_MQ;
                case "Graveyard":
                    return OcarinaOfTimeCheckLogicZone.Graveyard;
                case "Shadow Temple V":
                    return OcarinaOfTimeCheckLogicZone.Shadow_Temple_V;
                case "Shadow Temple MQ":
                    return OcarinaOfTimeCheckLogicZone.Shadow_Temple_MQ;    
                case "Dodongo's Cavern V":
                    return OcarinaOfTimeCheckLogicZone.Dodongos_Cavern_V;
                case "Dodongo's Cavern MQ":
                    return OcarinaOfTimeCheckLogicZone.Dodongos_Cavern_MQ;
                case "Death Mountain":
                    return OcarinaOfTimeCheckLogicZone.Death_Mountain;
                case "Goron City":
                    return OcarinaOfTimeCheckLogicZone.Goron_City;
                case "Fire Temple V":
                    return OcarinaOfTimeCheckLogicZone.Fire_Temple_V;
                case "Fire Temple MQ":
                    return OcarinaOfTimeCheckLogicZone.Fire_Temple_MQ;
                case "Death Mountain Crater":
                    return OcarinaOfTimeCheckLogicZone.Death_Mountain_Crater;
                default:
                    throw new Exception($"Unknown case: {zoneStr}");
            }
        }

        public static IEnumerable<OcarinaOfTimeCheckLogicZone> ToList()
        {
            return System.Enum.GetValues(typeof(OcarinaOfTimeCheckLogicZone)).Cast<OcarinaOfTimeCheckLogicZone>();
        }
    }
}
