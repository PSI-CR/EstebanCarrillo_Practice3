using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ImageController
    {
        private List<string> _images;
        private int _actualImage;
        public void SaveDirectory(List<string> images)
        {
            if (images == null)
            {
                throw new ArgumentNullException("The list of images cannot be null");
            }
            this._images = images;
        }
        public List<string> GetImages()
        {
            return _images;
        }
        public void SetImage(int actualImage)
        {
            if ((actualImage < 0) || (actualImage > (_images.Count - 1)))
            {
                throw new ArgumentOutOfRangeException(nameof(ImageController), $"{nameof(ImageController)} must be less than or equal to 0 ");
            }
            this._actualImage = actualImage;
        }
        public int GetImage()
        {
            return _actualImage;
        }
        public string GetActualPath()
        {
            return _images.ElementAt(_actualImage);
        }
    }
}
