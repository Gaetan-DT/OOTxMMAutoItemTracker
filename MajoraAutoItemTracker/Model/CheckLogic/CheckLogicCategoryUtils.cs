using MajoraAutoItemTracker.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace MajoraAutoItemTracker.Model.CheckLogic
{
    public static class CheckLogicCategoryUtils
    {
        public const string CST_DEFAULT_MM_FILE_NAME = "mm_CheckLogicCategory.json";
        public const string CST_DEFAULT_OOT_FILE_NAME = "oot_CheckLogicCategory.json";

        public static List<MajoraMaskCheckLogicCategory>? FromMajoraMaskJson(string jsonStr)
        {
            return JsonConvert.DeserializeObject<List<MajoraMaskCheckLogicCategory>>(jsonStr);
        }

        public static List<MajoraMaskCheckLogicCategory>? LoadMajoraMaskFromFile(string filepath)
        {
            return FromMajoraMaskJson(File.ReadAllText(filepath));
        }

        public static List<MajoraMaskCheckLogicCategory> LoadMajoraMaskFromRessource()
        {
            var data = Properties.Resources.mm_CheckLogicCategory;
            return JsonConvertUtils.DeserializeObjectFromByteOrThrow<List<MajoraMaskCheckLogicCategory>>(data);
        }

        public static List<OcarinaOfTimeCheckLogicCategory>? FromOcarinaOfTimeJson(string jsonStr)
        {
            return JsonConvert.DeserializeObject<List<OcarinaOfTimeCheckLogicCategory>>(jsonStr);
        }

        public static List<OcarinaOfTimeCheckLogicCategory>? LoadOcarinaOfTimeFromFile(string filepath)
        {
            return FromOcarinaOfTimeJson(File.ReadAllText(filepath));
        }

        public static List<OcarinaOfTimeCheckLogicCategory> LoadOcarinaOfTimeFromRessource()
        {
            var data = Properties.Resources.oot_CheckLogicCategory;
            return JsonConvertUtils.DeserializeObjectFromByteOrThrow<List<OcarinaOfTimeCheckLogicCategory>>(data);
        }
    }
}
