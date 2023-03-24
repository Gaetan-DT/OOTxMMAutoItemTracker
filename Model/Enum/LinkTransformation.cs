using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum LinkTransformation
    {
        FierceDeity = 0,
        Goron = 1,
        Zora = 2,
        Deku = 3,
        Human = 4
    }

    static class LinkTransformationMethods
    {
        public static String GetString(this LinkTransformation eLinkTransformation)
        {
            switch (eLinkTransformation)
            {
                case LinkTransformation.FierceDeity:
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

        public static LinkTransformation ReadFromMemory(this int linkTransformation)
        {
            var enumValue = (LinkTransformation) linkTransformation;
            if (enumValue is LinkTransformation)
            {
                return enumValue;
            }
            
            throw new Exception("Unknown LinkTransformation");
        }
    }
}
