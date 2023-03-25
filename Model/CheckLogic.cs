using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MajoraAutoItemTracker.Model.Check
{
    public class CheckLogic
    {
        public String Id { get; set; }
        public bool IsClaim { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class CheckLogicMethod
    {
        public const string CST_DEFAULT_FILE_NAME = "check_logic.json";

        public static List<CheckLogic> LoadDefault()
        {
            return Deserialize(CST_DEFAULT_FILE_NAME);
        }

        public static List<CheckLogic> Deserialize(String filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<CheckLogic>>(jsonFile);
        }

        public static string ToJson(List<CheckLogic> checkLogics)
        {
            return JsonConvert.SerializeObject(checkLogics);
        }
    }
}
