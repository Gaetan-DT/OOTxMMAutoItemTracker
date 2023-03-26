using System;
using System.Collections.Generic;
using System.Linq;

namespace MajoraAutoItemTracker.Model.Enum
{
    public enum CheckLogicZone
    {
        SOUTH_CLOCK_TOWN,
        LAUNDRY_POOL,
        EAST_CLOCK_TOWN,
        STOCK_POT_INN,
        WEST_CLOCK_TOWN,
        NORTH_CLOCK_TOWN,
        TERMINA_FIELD,
        ROAD_TO_SOUTHERN_SWAMP,
        SOUTHERN_SWAMP,
        SWAMP_SPIDER_HOUSE_ITEMS,
        DEKU_PALACE,
        WOODFALL,
        WOOFCALL_TEMPLE,
        MOUNTAIN_VILLAGE,
        TWIN_ISLANDS,
        GORON_VILLAGE,
        PATH_TO_SNOWHEAD,
        SNOWHEAD,
        SNOWHEAD_TEMPLE,
        MILK_ROAD,
        ROMANI_RANCH,
        GREAT_BAY_COAST,
        OCEAN_SPIDER_HOUSE_ITEMS,
        ZORA_CAPE,
        ZORA_HALL,
        PIRATES_FORTRESS_EXTERIOR,
        PIRATES_FORTRESS_SEWER,
        PIRATES_FORTRESS_INTERIOR,
        PINNACLE_ROCK,
        GREAT_BAY_TEMPLE,
        ROAD_TO_IKANA,
        IKANA_GRAVEYARD,
        IKANA_CANYON,
        SECRET_SHRINE,
        BENEATH_THE_WELL,
        IKANA_CASTLE,
        STONE_TOWER,
        STONE_TOWER_TEMPLE,
        THE_MOON,
    }

    public class CheckLogicZoneMethod
    {
        public static CheckLogicZone FromString(string zoneStr)
        {
            switch (zoneStr)
            {
                case "South Clock Town":
                    return CheckLogicZone.SOUTH_CLOCK_TOWN;
                case "Laundry Pool":
                    return CheckLogicZone.LAUNDRY_POOL;
                case "East Clock Town":
                    return CheckLogicZone.EAST_CLOCK_TOWN;
                case "Stock Pot Inn":
                    return CheckLogicZone.STOCK_POT_INN;
                case "West Clock Town":
                    return CheckLogicZone.WEST_CLOCK_TOWN;
                case "North Clock Town":
                    return CheckLogicZone.NORTH_CLOCK_TOWN;
                case "Termina Field":
                    return CheckLogicZone.TERMINA_FIELD;
                case "Road to Southern Swamp":
                    return CheckLogicZone.ROAD_TO_SOUTHERN_SWAMP;
                case "Southern Swamp":
                    return CheckLogicZone.SOUTHERN_SWAMP;
                case "Swamp Spider House Items":
                    return CheckLogicZone.SWAMP_SPIDER_HOUSE_ITEMS;
                case "Deku Palace":
                    return CheckLogicZone.DEKU_PALACE;
                case "Woodfall":
                    return CheckLogicZone.WOODFALL;
                case "Woodfall Temple":
                    return CheckLogicZone.WOOFCALL_TEMPLE;
                case "Mountain Village":
                    return CheckLogicZone.MOUNTAIN_VILLAGE;
                case "Twin Islands":
                    return CheckLogicZone.TWIN_ISLANDS;
                case "Goron Village":
                    return CheckLogicZone.GORON_VILLAGE;
                case "Path to Snowhead":
                    return CheckLogicZone.PATH_TO_SNOWHEAD;
                case "Snowhead":
                    return CheckLogicZone.SNOWHEAD;
                case "Snowhead Temple":
                    return CheckLogicZone.SNOWHEAD_TEMPLE;
                case "Milk Road":
                    return CheckLogicZone.MILK_ROAD;
                case "Romani Ranch":
                    return CheckLogicZone.ROMANI_RANCH;
                case "Great Bay Coast":
                    return CheckLogicZone.GREAT_BAY_COAST;
                case "Ocean Spider House Items":
                    return CheckLogicZone.OCEAN_SPIDER_HOUSE_ITEMS;
                case "Zora Cape":
                    return CheckLogicZone.ZORA_CAPE;
                case "Zora Hall":
                    return CheckLogicZone.ZORA_HALL;
                case "Pirates' Fortress Exterior":
                    return CheckLogicZone.PIRATES_FORTRESS_EXTERIOR;
                case "Pirates' Fortress Sewer":
                    return CheckLogicZone.PIRATES_FORTRESS_INTERIOR;
                case "Pirates' Fortress Interior":
                    return CheckLogicZone.PIRATES_FORTRESS_SEWER;
                case "Pinnacle Rock":
                    return CheckLogicZone.PINNACLE_ROCK;
                case "Great Bay Temple":
                    return CheckLogicZone.GREAT_BAY_TEMPLE;
                case "Road To Ikana":
                    return CheckLogicZone.ROAD_TO_IKANA;
                case "Ikana Graveyard":
                    return CheckLogicZone.IKANA_GRAVEYARD;
                case "Ikana Canyon":
                    return CheckLogicZone.IKANA_CANYON;
                case "Secret Shrine":
                    return CheckLogicZone.SECRET_SHRINE;
                case "Beneath the Well":
                    return CheckLogicZone.BENEATH_THE_WELL;
                case "Ikana Castle":
                    return CheckLogicZone.IKANA_CASTLE;
                case "Stone Tower":
                    return CheckLogicZone.STONE_TOWER;
                case "Stone Tower Temple":
                    return CheckLogicZone.STONE_TOWER_TEMPLE;
                case "The Moon":
                    return CheckLogicZone.THE_MOON;
                default:
                    throw new Exception($"Unknown case: {zoneStr}");
            }
        }

        public static IEnumerable<CheckLogicZone> ToList()
        {
            return System.Enum.GetValues(typeof(CheckLogicZone)).Cast<CheckLogicZone>();
        }
    }
}
