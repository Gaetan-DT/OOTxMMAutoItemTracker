using MajoraAutoItemTracker.Model.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public class MajoraMaskCheckLogic : AbstractCheckLogic<MajoraMaskCheckLogicZone>
    {
        public const string CST_DEFAULT_FILE_NAME = "check_logic.json";

        public override String Id { get; set; }        
        public override MajoraMaskCheckLogicZone Zone { get; set; }
        public int SquarePositionX { get; set; }
        public int SquarePositionY { get; set; }
        public override bool IsClaim { get; set; }
        public override bool IsAvailable { get; set; }

        public static List<MajoraMaskCheckLogic> LoadDefault()
        {
            return Deserialize(CST_DEFAULT_FILE_NAME);
        }

        public static List<MajoraMaskCheckLogic> Deserialize(String filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<MajoraMaskCheckLogic>>(jsonFile);
        }

        public static string ToJson(List<MajoraMaskCheckLogic> checkLogics)
        {
            return JsonConvert.SerializeObject(checkLogics);
        }

        public static List<MajoraMaskCheckLogic> FromHeader(List<MajoraMaskCheckLogicCategory> checkLogicHeaders)
        {
            List<MajoraMaskCheckLogic> result = new List<MajoraMaskCheckLogic>();
            foreach (var checkLogicHeader in checkLogicHeaders)
            {
                foreach (var logicId in checkLogicHeader.CheckLogicId)
                {
                    result.Add(new MajoraMaskCheckLogic()
                    {
                        Id = logicId,
                        IsAvailable = false,
                        IsClaim = false,
                        SquarePositionX = checkLogicHeader.SquarePositionX,
                        SquarePositionY = checkLogicHeader.SquarePositionY,
                        Zone = MajoraMaskCheckLogicZoneMethod.FromString(checkLogicHeader.Name)
                    });
                }
            }
            return result;
        }
    }
}
