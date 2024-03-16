using System.Security.Policy;

namespace MajoraAutoItemTracker.Model.Enum.MM
{
    public enum MajoraTradeScrubTrade
    {
        None,
        MoonsTear,
        LandTitleDeed,
        SwampTitleDeed,
        MountainTitleDeed,
        OceanTitleDeed
    }

    public static class MajoraTradeScrubTradeMethod
    {
        public static MajoraTradeScrubTrade FromMemory(uint value)
        {
            switch (value)
            {
                case 0x28: return MajoraTradeScrubTrade.MoonsTear;
                case 0x29: return MajoraTradeScrubTrade.LandTitleDeed;
                case 0x2A: return MajoraTradeScrubTrade.SwampTitleDeed;
                case 0x2B: return MajoraTradeScrubTrade.MountainTitleDeed;
                case 0x2C: return MajoraTradeScrubTrade.OceanTitleDeed;
                default: return MajoraTradeScrubTrade.None;
            }
        }

        public static int ToInterfaceMappingVariant(MajoraTradeScrubTrade majoraTradeScrubTrade)
        {
            switch (majoraTradeScrubTrade)
            {
                default: 
                case MajoraTradeScrubTrade.None: return 0;
                case MajoraTradeScrubTrade.MoonsTear: return 0;
                case MajoraTradeScrubTrade.LandTitleDeed: return 1;
                case MajoraTradeScrubTrade.SwampTitleDeed: return 2;
                case MajoraTradeScrubTrade.MountainTitleDeed: return 3;
                case MajoraTradeScrubTrade.OceanTitleDeed: return 4;
            }
        }
    }
}
