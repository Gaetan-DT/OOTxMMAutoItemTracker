using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

#nullable enable

namespace MajoraAutoItemTracker.Model.Item
{
    public class ItemLogicMethod
    {
        public const string CST_DEFAULT_FILE_NAME = "InterfaceItemsPositionsMapping.json";
        public const string CST_OOT_FILE_NAME = "oot_InterfaceItemsPositionsMapping.json";
        public const string CST_MM_FILE_NAME = CST_DEFAULT_FILE_NAME;
        
        public static List<ItemLogic>? DeserializeOOT()
        {
            return Deserialize(Application.StartupPath + @"\Resource\Mappings\" + CST_OOT_FILE_NAME);
        }
        
        public static List<ItemLogic>? Deserialize(String filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<ItemLogic>>(jsonFile);
        }
    }
}
