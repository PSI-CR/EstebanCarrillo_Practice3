using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1Test.Data
{
    [TestFixture]
    class ImageViewTest
    {
        [Test]
        public void SaveOriginalImage()
        {
            WpfApp1.ImageView image = new WpfApp1.ImageView();
            Exception ex = Assert.Throws<ArgumentNullException>(() => image.SaveOriginalImage(null));
            Assert.That(ex.Message, Is.EqualTo("originalImage is null. (Parameter 'originalImage')"));
        }
        [Test]
        public void ObtainOriginalImageTest()
        {
            WpfApp1.ImageView image = new WpfApp1.ImageView();
            Bitmap bitmap = new Bitmap(1, 1);
            image.SaveOriginalImage(bitmap);
            Assert.IsNotNull(image.ObtainOriginalImage());
        }
    }
}
