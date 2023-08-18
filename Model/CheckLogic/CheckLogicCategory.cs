using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public class CheckLogicCategory
    {
        public const string CST_DEFAULT_FILE_NAME = "CheckLogicCategory.json";

        public string Name { get; set; }
        public int SquarePositionX { get; set; }
        public int SquarePositionY { get; set; }
        public List<string> CheckLogicId { get; set; }

        public static List<CheckLogicCategory> fromJson(string jsonStr)
        {
            return JsonConvert.DeserializeObject<List<CheckLogicCategory>>(jsonStr);
        }

        public static List<CheckLogicCategory> LoadFromFile(string filepath)
        {
            return fromJson(File.ReadAllText(filepath));
        }

    }
}
