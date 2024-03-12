using MajoraAutoItemTracker.Model.Logic.MM;
using MajoraAutoItemTracker.Model.Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace MajoraAutoItemTracker.Core
{
    public static class JsonConvertUtils
    {
        public static T DeserializeObjectFromByteOrThrow<T>(byte[] data)
        {
            var foo = Encoding.UTF8.GetString(data, 0, data.Length);
            var dataStr = Encoding.UTF8.GetString(data);
            return JsonConvert.DeserializeObject<T>(dataStr)
                ?? throw new Exception("Unable to read ressource data");
        }
    }
}
