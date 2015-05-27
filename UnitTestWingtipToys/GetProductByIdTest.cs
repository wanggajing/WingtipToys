using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WingtipToys;
using WingtipToys.Models;

namespace UnitTestWingtipToys
{
    [TestClass]
    public class GetProductByIdTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProductDetail productDetail = new ProductDetail();
            Product expected = new Product
            {
                ProductID = 1,
                ProductName = "Convertible Car",
                Description = "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." + "Power it up and let it go!",
                ImagePath = "carconvert.png",
                UnitPrice = 22.50,
                CategoryID = 1
            };
            Product actual = productDetail.GetProduct(1) as Product;
            Assert.AreEqual(expected, actual);
        }
    }
}
