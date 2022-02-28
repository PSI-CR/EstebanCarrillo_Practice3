using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;


namespace WpfApp1Test.Business
{
    [TestFixture]
    public class FiltersSobelTest
    {
        [Test]
        public void AdvancedFiltersTest()
        {
            IFilter FiltersSobel = new FiltersSobel();
            Exception ex = Assert.Throws<ArgumentNullException>(() => FiltersSobel.AdvancedFilters(null));
            Assert.That(ex.Message, Is.EqualTo("original is null. (Parameter 'original')"));
        }
        [Test]
        public void FiltersSobelValuesTest()
        {
            IFilter filtersSobel = new FiltersSobel();
            Exception ex = Assert.Throws<ArgumentNullException>(() => filtersSobel.AdvancedFilters(null));
        }
    }
}
