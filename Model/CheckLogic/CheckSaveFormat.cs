using MajoraAutoItemTracker.Model.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

#nullable enable

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    class CheckSaveFormat
    {
        public string? Id { get; set; }
        public bool IsClaim { get; set; }
    }

    class CheckSaveFormatHeader
    {
        public RomType SaveRomType { get; set; }
        
        public List<CheckSaveFormat> OOTCheckList { get; set; } = new List<CheckSaveFormat>();
        public List<CheckSaveFormat> MMCheckList { get; set; } = new List<CheckSaveFormat>();
    }

    class CheckSaveMethod
    {
        public static CheckSaveFormatHeader? DeserializeFromFile(String filePath)
        {
            return JsonConvert.DeserializeObject<CheckSaveFormatHeader>(File.ReadAllText(filePath));
        }

        public static void SerializeToFile(CheckSaveFormatHeader checkSaveFormat, String filePath)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(checkSaveFormat));
        }
            
    }
}
