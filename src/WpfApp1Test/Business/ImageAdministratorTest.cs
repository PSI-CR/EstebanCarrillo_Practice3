using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace WpfApp1Test.Business
{
    [TestFixture]
    class ImageAdministratorTest
    {
        [Test]
        public void ObtainOriginalImageTest()
        {
            ImageAnalyzer imageReader = new ImageAnalyzer();
            WpfApp1.ImageView image = new WpfApp1.ImageView();
            ImageAdministrator imageManager = new ImageAdministrator(image, imageReader);
        }
        [Test]
        public void ReadImageTest()
        {
            ImageAnalyzer imageReader = new ImageAnalyzer();
            WpfApp1.ImageView image = new WpfApp1.ImageView();
            ImageAdministrator imageManager = new ImageAdministrator(image, imageReader);
            Exception ex = Assert.Throws<ArgumentNullException>(() => imageManager.ReadImage(null));
            Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'The image path cannot be null')"));
        }
        [Test]
        public void SaveOriginalImageTest()
        {
            ImageAnalyzer imageReader = new ImageAnalyzer();
            WpfApp1.ImageView image = new WpfApp1.ImageView();
            ImageAdministrator imageManager = new ImageAdministrator(image, imageReader);
        }
        [Test]
        public void ImageRouteTest()
        {
            var Test = File.Exists(@"..//TestImage.jpg");
        }
    }
}
