using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApp1
{
    public class ControllerManager
    {
        private ImageController _imageController;
        
        public ControllerManager()
        {
            _imageController = new ImageController();
        }
        public void PackDirectory(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("The path cannot be null");
            }
            string[] files = Directory.GetFiles(path);
            List<string> images = new List<string>();
            for (int i = 0; i < files.Length; i++)
            {
                if ((files[i].Substring(files[i].Length - 4)).CompareTo(".jpg") == 0)
                {
                    images.Add(files[i]);
                }
                    
            }
            _imageController.SaveDirectory(images);
        }

        public void SetActualImage(string imagePath)
        {
            if (imagePath == null)
            {
                throw new ArgumentNullException("The image path cannot be null");
            }
            int actualImage = -1;
            int i = 0;
            List<string> images = _imageController.GetImages();
            foreach (string path in images)
            {
                if (imagePath.CompareTo(path) == 0)
                {
                    actualImage = i;
                }
                i++;
            }
            _imageController.SetImage(actualImage);
        }

        public bool direct(int mobilizeImage)
        {
            int actualImage = _imageController.GetImage() + mobilizeImage;
            if (!((actualImage < 0) || (actualImage >= _imageController.GetImages().Count)))
            {
                _imageController.SetImage(actualImage);
               
                return true;
            }
            return false;
        }

        public string GetActualPath()
        {
            return _imageController.GetActualPath();
        }
    }
}
