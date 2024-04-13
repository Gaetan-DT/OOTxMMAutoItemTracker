using System.Drawing;
using System.IO;

namespace MajoraAutoItemTracker.Core.Extensions
{
    public static class ByteArray
    {
        public static Bitmap ConvertToBitmap(this byte[] input)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(input))
            {
                bmp = new Bitmap(ms);
            }
            return bmp;
        }
    }
}
