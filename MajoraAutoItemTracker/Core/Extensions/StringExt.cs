using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Core.Extensions
{
    public static class StringExt
    {
        public static string ReverseString(this string aString)
        {
            char[] charArray = aString.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
