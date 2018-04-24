using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPA.App;

namespace CPAtest3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void CollectPriceClassTest()
        {
            decimal priceClass = App.CollectPriceClass(500, 1000, 840);

            Assert.AreEqual(7, priceClass);
        }

        [TestMethod]
        public void TestMethod1()
        {
            decimal priceClass = App.CollectPriceClass(500, 1000, 800);

            Assert.AreEqual(6, priceClass);
        }

    }

}
