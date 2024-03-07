using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

#nullable enable

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public class MajoraMaskCheckLogicCategory
    {
        public const string CST_DEFAULT_FILE_NAME = "CheckLogicCategory.json";

        public string? Name { get; set; }
        public int SquarePositionX { get; set; }
        public int SquarePositionY { get; set; }
        public List<string> CheckLogicId { get; set; } = new List<string>();

        public static List<MajoraMaskCheckLogicCategory>? FromJson(string jsonStr)
        {
            return JsonConvert.DeserializeObject<List<MajoraMaskCheckLogicCategory>>(jsonStr);
        }

        public static List<MajoraMaskCheckLogicCategory>? LoadFromFile(string filepath)
        {
            return FromJson(File.ReadAllText(filepath));
        }

    }
}
