﻿using MajoraAutoItemTracker.Core;
using MajoraAutoItemTracker.Model.Logic.MM;
using MajoraAutoItemTracker.Model.Logic.OOT;
using Newtonsoft.Json;
using System.IO;

#nullable enable

namespace MajoraAutoItemTracker.Model.Logic
{
    public class LogicFileUtils
    {
        public static LogicFile<T>? FromFile<T>(string filePath)
        {
            return FromJson<T>(File.ReadAllText(filePath));
        }

        public static LogicFile<T>? FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<LogicFile<T>>(json);
        }

        public static string ToJsonStr<T>(LogicFile<T> logicFile)
        {
            return JsonConvert.SerializeObject(logicFile);
        }

        public static void Save<T>(string filePath, LogicFile<T> logicFile)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(logicFile));
        }

        public static LogicFile<OcarinaOfTimeJsonFormatLogicItem> LoadOcarinaOfTimeFromRessource()
        {
            var dataStr = Ressources.Properties.Resources.OOT_CUSTOM_REQ_CASUAL_1;
            return JsonConvertUtils.DeserializeObjectFromByteOrThrow<LogicFile<OcarinaOfTimeJsonFormatLogicItem>>(dataStr);
        }

        public static LogicFile<MajoraMaskJsonFormatLogicItem> LoadMajoraMaskFromRessource()
        {
            var dataStr = Ressources.Properties.Resources.MM_CUSTOM_REQ_CASUAL_1;
            return JsonConvertUtils.DeserializeObjectFromByteOrThrow<LogicFile<MajoraMaskJsonFormatLogicItem>>(dataStr);
        }
    }
}
