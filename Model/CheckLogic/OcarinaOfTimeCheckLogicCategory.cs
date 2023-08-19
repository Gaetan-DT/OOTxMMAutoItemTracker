using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public class OcarinaOfTimeCheckLogicCategory
    {
        public const string CST_DEFAULT_FILE_NAME = "oot_CheckLogicCategory.json";

        public string Name { get; set; }
        public int SquarePositionX { get; set; }
        public int SquarePositionY { get; set; }
        public List<string> CheckLogicId { get; set; }

        public static List<OcarinaOfTimeCheckLogicCategory> fromJson(string jsonStr)
        {
            return JsonConvert.DeserializeObject<List<OcarinaOfTimeCheckLogicCategory>>(jsonStr);
        }

        public static List<OcarinaOfTimeCheckLogicCategory> LoadFromFile(string filepath)
        {
            return fromJson(File.ReadAllText(filepath));
        }

    }
}
