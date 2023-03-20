using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum LinkTransformation
    {
        Fierce_Deity,
        Goron,
        Zora,
        Deku,
        Human
    }

    static class LinkTransformationMethods
    {
        public static String GetString(this LinkTransformation eLinkTransformation)
        {
            switch (eLinkTransformation)
            {
                case LinkTransformation.Fierce_Deity:
                    return "Fierce Deity";
                case LinkTransformation.Goron:
                    return "Goron";
                case LinkTransformation.Zora:
                    return "Zora";
                case LinkTransformation.Deku:
                    return "Deku";
                case LinkTransformation.Human:
                    return "Human";
                default:
                    return "????";
            }
        }

        public static LinkTransformation ReadFromMemory(this int LinkTransformation)
        {
            switch (LinkTransformation)
            {
                case 0: // 
                    return Enum.LinkTransformation.Fierce_Deity;
                case 1: // Goron
                    return Enum.LinkTransformation.Goron;
                case 2: // Zora
                    return Enum.LinkTransformation.Zora;
                case 3: // Deku
                    return Enum.LinkTransformation.Deku;
                case 4:
                    return Enum.LinkTransformation.Human;
                default:
                    throw new Exception("Unknown link transformation");
            }
        }
    }
}
