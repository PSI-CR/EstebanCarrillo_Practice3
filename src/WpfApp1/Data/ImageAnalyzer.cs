using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Drawing;


namespace WpfApp1
{
    public class ImageAnalyzer
    {
         public Bitmap InterpretImage(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("The image path cannot be null");
            }
            if ((path.Substring(path.Length-4)).CompareTo(".jpg") != 0) {
                throw new ArgumentException("The image must be .jpg");
            }            
            Bitmap image = new Bitmap(path, true);
            return image;
        }
    }
}
