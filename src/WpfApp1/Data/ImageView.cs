using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WpfApp1
{
    public class ImageView
    {
        private Bitmap _originalImage;
        public void SaveOriginalImage(Bitmap originalImage)
        {
            if (originalImage == null)
            {
                throw new ArgumentNullException("originalImage", "originalImage is null.");
            }
            this._originalImage = originalImage;
        }
        public Bitmap ObtainOriginalImage()
        {
            return _originalImage;
        }

    }
}
