namespace MajoraAutoItemTracker.Model.Enum.MM
{
    public enum MajoraTradeLetterpendant
    {
        None,
        LetterToKafei,
        PendantOfMemories
    }

    public static class MajoraTradeLetterpendantMethod
    {
        public static MajoraTradeLetterpendant FromMemory(uint value)
        {
            switch (value)
            {
                case 0x28: return MajoraTradeLetterpendant.LetterToKafei;
                case 0x29: return MajoraTradeLetterpendant.PendantOfMemories;
                default: return MajoraTradeLetterpendant.None;
            }
        }

        public static int ToInterfaceMappingVariant(MajoraTradeLetterpendant majoraTradeLetterpendant)
        {
            switch (majoraTradeLetterpendant)
            {
                default:
                case MajoraTradeLetterpendant.None: return 0;
                case MajoraTradeLetterpendant.LetterToKafei: return 0;
                case MajoraTradeLetterpendant.PendantOfMemories: return 1;
            }
        }
    }
}
