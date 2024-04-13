using MajoraAutoItemTracker.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

#nullable enable

namespace MajoraAutoItemTracker.Model.Item
{
    public class ItemLogicMethod
    {
        public static List<ItemLogic> LoadOcarinaOfTimeItemLogicFromRessource()
        {
            var data = Ressources.Properties.Resources.oot_InterfaceItemsPositionsMapping;
            return JsonConvertUtils.DeserializeObjectFromByteOrThrow<List<ItemLogic>>(data);
        }

        public static List<ItemLogic> LoadMajoraMaskItemLogicFromRessource()
        {
            var data = Ressources.Properties.Resources.mm_InterfaceItemsPositionsMapping;
            return JsonConvertUtils.DeserializeObjectFromByteOrThrow<List<ItemLogic>>(data);
        }

        public static List<ItemLogic>? Deserialize(String filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<ItemLogic>>(jsonFile);
        }
    }
}
