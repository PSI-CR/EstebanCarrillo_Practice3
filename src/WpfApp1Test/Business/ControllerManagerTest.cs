using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace WpfApp1Test
{
    [TestFixture]
    class ControllerManagerTest
    {
        [Test]
        public void PackDirectoryTest()
        {
            ControllerManager imageManager = new ControllerManager();
            Exception ex = Assert.Throws<ArgumentNullException>(() => imageManager.PackDirectory(null));
            Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'The path cannot be null')"));
        }
    }
}
