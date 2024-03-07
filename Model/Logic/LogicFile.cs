using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

#nullable enable

namespace MajoraAutoItemTracker.Model.Logic
{
    class LogicFile<JsonFormatLogicItem>
    {
        public const string CST_REQ_CASUAL_PATH = @"Resource\Logics\";
        public const string CST_OOT_REQ_FILE_NAME = "OOT_CUSTOM_REQ_CASUAL_1.json";
        public const string CST_MM_REQ_FILE_NAME = "REQ_CASUAL_12.json";

        public int Version { get; set; }
        public List<JsonFormatLogicItem> Logic { get; set; } = new List<JsonFormatLogicItem>();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static LogicFile<JsonFormatLogicItem>? FromFile(string filePath)
        {
            return FromJson(File.ReadAllText(filePath));
        }

        public static LogicFile<JsonFormatLogicItem>? FromJson(string json)
        {
            // MajoraMaskJsonFormatLogicItem
            // OcarinaOfTimeJsonFormatLogicItem
            return JsonConvert.DeserializeObject<LogicFile<JsonFormatLogicItem>>(json);
        }

        public static void Save(string filePath, LogicFile<JsonFormatLogicItem> logicFile)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(logicFile));
        }
    }
}
