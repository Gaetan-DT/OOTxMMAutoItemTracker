using MajoraAutoItemTracker.Model.Logic.MM;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MajoraAutoItemTracker.Model.Logic
{
    class LogicFile<JsonFormatLogicItem>
    {
        public int Version { get; set; }
        public List<JsonFormatLogicItem> Logic { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static LogicFile<JsonFormatLogicItem> FromFile(string filePath)
        {
            return FromJson(File.ReadAllText(filePath));
        }

        public static LogicFile<JsonFormatLogicItem> FromJson(string json)
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
