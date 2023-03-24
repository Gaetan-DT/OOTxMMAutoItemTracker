using Json.Net;
using System;
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
        private const string CST_DEFAULT_FILE_PATH = "check_logic.json";

        public static CheckLogic[] LoadDefault()
        {
            return Deserialize(CST_DEFAULT_FILE_PATH);
        }

        public static CheckLogic[] Deserialize(String filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            return JsonNet.Deserialize<CheckLogic[]>(jsonFile);
        }
    }
}
