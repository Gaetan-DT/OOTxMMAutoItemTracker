using Json.Net;
using System;
using System.IO;

namespace MajoraAutoItemTracker.Model.Item
{
    public class ItemLogic
    {
        public String displayName { get; set; }

        public String propertyName { get; set; }

        public ItemLogicVariant[] variants { get; set; }
    }

    public class ItemLogicVariant
    {
        public String idLogic { get; set; }
        public int positionX { get; set; }
        public int positionY { get; set; }
        public bool hasItem { get; set; }
    }

    public static class ItemLogicMethod
    {
        public static ItemLogic Deserialize(String filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            return JsonNet.Deserialize<ItemLogic>(jsonFile);
        }
    }
}
