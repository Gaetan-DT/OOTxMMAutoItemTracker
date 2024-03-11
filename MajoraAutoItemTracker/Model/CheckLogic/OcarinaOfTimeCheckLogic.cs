using MajoraAutoItemTracker.Model.Enum.OOT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

#nullable enable

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public class OcarinaOfTimeCheckLogic : AbstractCheckLogic<OcarinaOfTimeCheckLogicZone>
    {
        public const string CST_DEFAULT_FILE_NAME = "oot_check_logic.json";

        public override string? Id { get; set; }        
        public override OcarinaOfTimeCheckLogicZone Zone { get; set; }
        public int SquarePositionX { get; set; }
        public int SquarePositionY { get; set; }
        public override bool IsClaim { get; set; }
        public override bool IsAvailable { get; set; }

        public static List<OcarinaOfTimeCheckLogic>? LoadDefault()
        {
            return Deserialize(CST_DEFAULT_FILE_NAME);
        }

        public static List<OcarinaOfTimeCheckLogic>? Deserialize(String filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<OcarinaOfTimeCheckLogic>>(jsonFile);
        }

        public static string ToJson(List<OcarinaOfTimeCheckLogic> checkLogics)
        {
            return JsonConvert.SerializeObject(checkLogics);
        }

        public static List<OcarinaOfTimeCheckLogic> FromHeader(List<OcarinaOfTimeCheckLogicCategory> checkLogicHeaders)
        {
            List<OcarinaOfTimeCheckLogic> result = new List<OcarinaOfTimeCheckLogic>();
            foreach (var checkLogicHeader in checkLogicHeaders)
                foreach (var logicId in checkLogicHeader.CheckLogicId)
                {
                    if (checkLogicHeader.Name == null)
                        throw new Exception("ERROR: checkLogicHeader.Name is null");
                    result.Add(new OcarinaOfTimeCheckLogic()
                    {
                        Id = logicId,
                        IsAvailable = false,
                        IsClaim = false,
                        SquarePositionX = checkLogicHeader.SquarePositionX,
                        SquarePositionY = checkLogicHeader.SquarePositionY,
                        Zone = OcarinaOfTimeCheckLogicZoneMethod.FromString(checkLogicHeader.Name)
                    });
                }
            return result;
        }
    }
}
