using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace WpfApp1Test.Data
{
    [TestFixture]
    class ImageControllerTest
    {
        [Test]
        public void SaveDirectoryTest()
        {
            ImageController imageController = new ImageController();
            Exception ex = Assert.Throws<ArgumentNullException>(() => imageController.SaveDirectory(null));
        }
        [Test]
        public void SetImageTest()
        {
            ImageController imageController = new ImageController();
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() => imageController.SetImage(-1));
            Assert.That(ex.Message, Is.EqualTo("ImageController must be less than or equal to 0  (Parameter 'ImageController')"));
        }
    }
}
