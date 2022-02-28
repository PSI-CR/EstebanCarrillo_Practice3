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
    class ImageAnalyzerTest
    {
        [Test]
        public void InterpretImageTest()
        {
            ImageAnalyzer imageReader = new ImageAnalyzer();

            Exception ex = Assert.Throws<ArgumentNullException>(() => imageReader.InterpretImage(null));
            Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'The image path cannot be null')"));
        }
        [Test]
        public void InterpretImagePathTest()
        {
            ImageAnalyzer imageReader = new ImageAnalyzer();
            Exception ex = Assert.Throws<ArgumentException>(() => imageReader.InterpretImage("TestImage.jpg"));
            Assert.That(ex.Message, Is.EqualTo("Parameter is not valid."));
        }
    }
}
