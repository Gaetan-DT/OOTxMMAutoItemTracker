using MajoraAutoItemTracker.Model.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public class CheckSaveFormat
    {
        public string? Id { get; set; }
        public bool IsClaim { get; set; }
    }

    public class CheckSaveFormatHeader
    {
        public RomType SaveRomType { get; set; }
        
        public List<CheckSaveFormat> OOTCheckList { get; set; } = new List<CheckSaveFormat>();
        public List<CheckSaveFormat> MMCheckList { get; set; } = new List<CheckSaveFormat>();
    }

    public class CheckSaveMethod
    {

        public static string SerializeOrThrow(CheckSaveFormatHeader checkSaveFormat)
        {
            return JsonConvert.SerializeObject(checkSaveFormat);
        }

        public static CheckSaveFormatHeader? DeserializeFromStringOrThrow(string strJson)
        {
            return JsonConvert.DeserializeObject<CheckSaveFormatHeader>(strJson);
        }

        public static CheckSaveFormatHeader? DeserializeFromPathOrThrow(String filePath)
        {
            return DeserializeFromStringOrThrow(File.ReadAllText(filePath));
        }

        public static void SerializeToFile(CheckSaveFormatHeader checkSaveFormat, String filePath)
        {
            File.WriteAllText(filePath, SerializeOrThrow(checkSaveFormat));
        }
            
    }
}
