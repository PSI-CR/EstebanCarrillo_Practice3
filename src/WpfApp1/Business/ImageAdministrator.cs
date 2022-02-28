using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WpfApp1
{
    public class ImageAdministrator
    {
        ImageAnalyzer _imageReader;
        ImageView _image;
        public ImageAdministrator(ImageView image, ImageAnalyzer imageReader)
        {
            this._imageReader = imageReader;
            this._image = image;
        }
        public Bitmap ObtainOriginalImage()
        {
            return _image.ObtainOriginalImage();
        }
        public Bitmap ReadImage(string path)
        {
            if(path == null)
            {
                throw new ArgumentNullException("The image path cannot be null");
            }
            return _imageReader.InterpretImage(path);
        }

        public void SaveOriginalImage(Bitmap originalImage)
        {
            if (originalImage == null)
            {
                throw new ArgumentNullException("The image cannot be null");
            }
            _image.SaveOriginalImage(originalImage);
        }
    }
}

