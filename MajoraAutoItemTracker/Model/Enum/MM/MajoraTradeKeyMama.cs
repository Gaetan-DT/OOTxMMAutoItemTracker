namespace MajoraAutoItemTracker.Model.Enum.MM
{
    public enum MajoraTradeKeyMama
    {
        None,
        RoomKey,
        SpecialDeliveryToMama
    }

    public static class MajoraTradeKeyMamaMethod
    {
        public static MajoraTradeKeyMama FromMemory(uint value)
        {
            switch (value)
            {
                case 0x2D: return MajoraTradeKeyMama.RoomKey;
                case 0x2E: return MajoraTradeKeyMama.SpecialDeliveryToMama;
                default: return MajoraTradeKeyMama.None;
            }
        }

        public static int ToInterfaceMappingVariant(MajoraTradeKeyMama majoraTradeKeyMama)
        {
            switch (majoraTradeKeyMama)
            {
                default:
                case MajoraTradeKeyMama.None: return 0;
                case MajoraTradeKeyMama.RoomKey: return 0;
                case MajoraTradeKeyMama.SpecialDeliveryToMama: return 1;
            }
        }
    }
}
