using Json.Net;
using System;
using System.IO;

namespace MajoraAutoItemTracker.Model.Logic
{
    public class Logic
    {
        public String Id { get; set; }
        public String[] RequiredItems { get; set; }
        public String[] ConditionalItems { get; set; }
        public String TimeNeeded { get; set; }
        public String TimeAvailable { get; set; }
        public String TimeSetup { get; set; }
        public bool IsTrick { get; set; }
        public String TrickTooltip { get; set; }
        public String TrickCategory { get; set; }
    }

    public class LogicHeader
    {
        public int Version { get; set; }
        public Logic[] Logic { get; set; }
    }

    public class LogicMethod
    {

        public static LogicHeader DeserializeHeader(String filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            return JsonNet.Deserialize<LogicHeader>(jsonFile);
        }

        public static Logic DeserializeMethod(String filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            return JsonNet.Deserialize<Logic>(jsonFile);
        }       
    }
}
