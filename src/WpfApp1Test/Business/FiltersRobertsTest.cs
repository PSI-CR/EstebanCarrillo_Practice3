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
    class FiltersRobertsTest
    {
        [Test]
        public void AdvancedFiltersTest()
        {
            IFilter FiltersRoberts = new FiltersRoberts();
            Exception ex = Assert.Throws<ArgumentNullException>(() => FiltersRoberts.AdvancedFilters(null));
            Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'The path cannot be null')"));
        }
    }
}
