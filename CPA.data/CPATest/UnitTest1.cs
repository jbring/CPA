using System;
using CPA.App;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CPATest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int priceClass = CollectPriceClass(500, 1000, 800);

            Assert.AreEqual(6, priceClass);
        }
    }
}
