using MajoraAutoItemTracker.Model.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public class CheckLogic
    {
        public const string CST_DEFAULT_FILE_NAME = "check_logic.json";

        public String Id { get; set; }        
        public CheckLogicZone Zone { get; set; }
        public int SquarePositionX { get; set; }
        public int SquarePositionY { get; set; }
        public bool IsClaim { get; set; }
        public bool IsAvailable { get; set; }

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

        public static List<CheckLogic> FromHeader(List<CheckLogicCategory> checkLogicHeaders)
        {
            List<CheckLogic> result = new List<CheckLogic>();
            foreach (var checkLogicHeader in checkLogicHeaders)
            {
                foreach (var logicId in checkLogicHeader.CheckLogicId)
                {
                    result.Add(new CheckLogic()
                    {
                        Id = logicId,
                        IsAvailable = false,
                        IsClaim = false,
                        SquarePositionX = checkLogicHeader.SquarePositionX,
                        SquarePositionY = checkLogicHeader.SquarePositionY,
                        Zone = CheckLogicZoneMethod.FromString(checkLogicHeader.Name)
                    });
                }
            }
            return result;
        }
    }
}
