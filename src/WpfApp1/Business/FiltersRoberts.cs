using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace WpfApp1
{
    public class FiltersRoberts : IFilter
    {

        public Bitmap AdvancedFilters(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new System.ArgumentNullException("The path cannot be null");
            }
            Bitmap bitmapPr = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.Format24bppRgb);
            unsafe
            {
                BitmapData bitmapData = bitmapPr.LockBits(new Rectangle(0, 0, bitmapPr.Width, bitmapPr.Height), ImageLockMode.ReadWrite, bitmapPr.PixelFormat);
                BitmapData bitmapDataOld = bitmap.LockBits(new Rectangle(0, 0, bitmapPr.Width, bitmapPr.Height), ImageLockMode.ReadWrite, bitmapPr.PixelFormat);

                int pixelb = Bitmap.GetPixelFormatSize(bitmapPr.PixelFormat) / 8;
                int heightPixels = bitmapData.Height;
                int widthBytes = bitmapData.Width * pixelb;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;
                byte* PtrFirstPixelOld = (byte*)bitmapDataOld.Scan0;

                Parallel.For(0, heightPixels - 1, y =>
                {
                    byte* actualRange = PtrFirstPixel + (y * bitmapData.Stride);
                    byte* actualRangeOld = PtrFirstPixelOld + (y * bitmapDataOld.Stride);
                    for (int x = 0; x < widthBytes - 1; x = x + pixelb)
                    {
                        var Px = (int)Math.Pow(-actualRangeOld[x] + (actualRangeOld + 3 + bitmapDataOld.Stride)[x], 2);
                        var Py = (int)Math.Pow((actualRangeOld + 3)[x] - (actualRangeOld + bitmapDataOld.Stride)[x], 2);
                        var f = Px + Py;
                        actualRange[x] = actualRange[x + 1] = actualRange[x + 2] = (byte)f;
                    }
                });
                bitmapPr.UnlockBits(bitmapData);
                bitmap.UnlockBits(bitmapDataOld);
                return bitmapPr;
            }
        }
    }
}
