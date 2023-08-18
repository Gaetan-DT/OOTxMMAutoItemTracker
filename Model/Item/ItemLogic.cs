using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MajoraAutoItemTracker.Model.Item
{
    public class ItemLogic
    {
        public String displayName { get; set; }

        public String propertyName { get; set; }

        public ItemLogicVariant[] variants { get; set; }

        public bool hasItem { get; set; }

        public int CurrentVariant { get; set; }

        public bool IsVariantClaim(string idStr)
        {
            // Check if we have the item
            if (!hasItem)
                return false;
            // Check if we have the correct variant or any superior variant for the json
            for (int variant = CurrentVariant; variant >= 0; variant--)
                if (variants[variant].idLogic == idStr)
                    return true; // we have the correct variant or higher
            return false; // We didn't have the correct variant
        }
    }

    public class ItemLogicVariant
    {
        public String idLogic { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
    }

    public static class ItemLogicMethod
    {
        public const string CST_DEFAULT_FILE_NAME = "InterfaceItemsPositionsMapping.json";
        public static List<ItemLogic> Deserialize(String filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<ItemLogic>>(jsonFile);
        }
    }
}
