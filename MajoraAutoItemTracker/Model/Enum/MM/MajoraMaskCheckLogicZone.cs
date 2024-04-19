using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace MajoraAutoItemTracker.Model.Enum
{
    public enum MajoraMaskCheckLogicZone
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

    public class MajoraMaskCheckLogicZoneMethod
    {
        public static MajoraMaskCheckLogicZone FromString(string zoneStr)
        {
            switch (zoneStr)
            {
                case "South Clock Town":
                    return MajoraMaskCheckLogicZone.SOUTH_CLOCK_TOWN;
                case "Laundry Pool":
                    return MajoraMaskCheckLogicZone.LAUNDRY_POOL;
                case "East Clock Town":
                    return MajoraMaskCheckLogicZone.EAST_CLOCK_TOWN;
                case "Stock Pot Inn":
                    return MajoraMaskCheckLogicZone.STOCK_POT_INN;
                case "West Clock Town":
                    return MajoraMaskCheckLogicZone.WEST_CLOCK_TOWN;
                case "North Clock Town":
                    return MajoraMaskCheckLogicZone.NORTH_CLOCK_TOWN;
                case "Termina Field":
                    return MajoraMaskCheckLogicZone.TERMINA_FIELD;
                case "Road to Southern Swamp":
                    return MajoraMaskCheckLogicZone.ROAD_TO_SOUTHERN_SWAMP;
                case "Southern Swamp":
                    return MajoraMaskCheckLogicZone.SOUTHERN_SWAMP;
                case "Swamp Spider House Items":
                    return MajoraMaskCheckLogicZone.SWAMP_SPIDER_HOUSE_ITEMS;
                case "Deku Palace":
                    return MajoraMaskCheckLogicZone.DEKU_PALACE;
                case "Woodfall":
                    return MajoraMaskCheckLogicZone.WOODFALL;
                case "Woodfall Temple":
                    return MajoraMaskCheckLogicZone.WOOFCALL_TEMPLE;
                case "Mountain Village":
                    return MajoraMaskCheckLogicZone.MOUNTAIN_VILLAGE;
                case "Twin Islands":
                    return MajoraMaskCheckLogicZone.TWIN_ISLANDS;
                case "Goron Village":
                    return MajoraMaskCheckLogicZone.GORON_VILLAGE;
                case "Path to Snowhead":
                    return MajoraMaskCheckLogicZone.PATH_TO_SNOWHEAD;
                case "Snowhead":
                    return MajoraMaskCheckLogicZone.SNOWHEAD;
                case "Snowhead Temple":
                    return MajoraMaskCheckLogicZone.SNOWHEAD_TEMPLE;
                case "Milk Road":
                    return MajoraMaskCheckLogicZone.MILK_ROAD;
                case "Romani Ranch":
                    return MajoraMaskCheckLogicZone.ROMANI_RANCH;
                case "Great Bay Coast":
                    return MajoraMaskCheckLogicZone.GREAT_BAY_COAST;
                case "Ocean Spider House Items":
                    return MajoraMaskCheckLogicZone.OCEAN_SPIDER_HOUSE_ITEMS;
                case "Zora Cape":
                    return MajoraMaskCheckLogicZone.ZORA_CAPE;
                case "Zora Hall":
                    return MajoraMaskCheckLogicZone.ZORA_HALL;
                case "Pirates Fortress Exterior":
                    return MajoraMaskCheckLogicZone.PIRATES_FORTRESS_EXTERIOR;
                case "Pirates Fortress Sewer":
                    return MajoraMaskCheckLogicZone.PIRATES_FORTRESS_SEWER;
                case "Pirates Fortress Interior":
                    return MajoraMaskCheckLogicZone.PIRATES_FORTRESS_INTERIOR;
                case "Pinnacle Rock":
                    return MajoraMaskCheckLogicZone.PINNACLE_ROCK;
                case "Great Bay Temple":
                    return MajoraMaskCheckLogicZone.GREAT_BAY_TEMPLE;
                case "Road To Ikana":
                    return MajoraMaskCheckLogicZone.ROAD_TO_IKANA;
                case "Ikana Graveyard":
                    return MajoraMaskCheckLogicZone.IKANA_GRAVEYARD;
                case "Ikana Canyon":
                    return MajoraMaskCheckLogicZone.IKANA_CANYON;
                case "Secret Shrine":
                    return MajoraMaskCheckLogicZone.SECRET_SHRINE;
                case "Beneath the Well":
                    return MajoraMaskCheckLogicZone.BENEATH_THE_WELL;
                case "Ikana Castle":
                    return MajoraMaskCheckLogicZone.IKANA_CASTLE;
                case "Stone Tower":
                    return MajoraMaskCheckLogicZone.STONE_TOWER;
                case "Stone Tower Temple":
                    return MajoraMaskCheckLogicZone.STONE_TOWER_TEMPLE;
                case "The Moon":
                    return MajoraMaskCheckLogicZone.THE_MOON;
                default:
                    throw new Exception($"Unknown case: {zoneStr}");
            }
        }

        public static IEnumerable<MajoraMaskCheckLogicZone> ToList()
        {
            return System.Enum.GetValues(typeof(MajoraMaskCheckLogicZone)).Cast<MajoraMaskCheckLogicZone>();
        }
    }
}
