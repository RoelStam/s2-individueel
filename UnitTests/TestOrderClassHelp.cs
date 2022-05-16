using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLibrary.DTOs;
using UnitTests.TestDAL;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using StocksBusinessLayer.Containers;
using StocksBusinessLayer.Models;
using StocksWebApp.ClassHelp;

namespace UnitTests
{
    [TestClass]
    public class TestOrderClassHelp
    {
        [TestMethod]
        public void TestCheckOrderBuy()
        {
            OrderClassHelp classHelp = new OrderClassHelp(new TestDALHolding(), new TestDALAccount(), new TestDALWallet());
            
            Order Order = new Order(new DTOOrder
            {
                ID = 1,
                StockID = 10,
                AccountID = 10,
                Shares = 1,
                Limit = 1.11,
                Type = "Buy",
                TotalPrice = 50.00,
                Completed = true
            });

            Assert.IsTrue(classHelp.CheckOrder(Order));
        }

        [TestMethod]
        public void TestCheckOrderBuyFail()
        {
            OrderClassHelp classHelp = new OrderClassHelp(new TestDALHolding(), new TestDALAccount(), new TestDALWallet());

            Order Order = new Order(new DTOOrder
            {
                ID = 1,
                StockID = 11,
                AccountID = 11,
                Shares = 1,
                Limit = 1.11,
                Type = "Buy",
                TotalPrice = 1.11,
                Completed = true
            });

            Assert.IsFalse(classHelp.CheckOrder(Order));
        }

        [TestMethod]
        public void TestCheckOrderSell()
        {
            OrderClassHelp classHelp = new OrderClassHelp(new TestDALHolding(), new TestDALAccount(), new TestDALWallet());

            Order Order = new Order(new DTOOrder
            {
                ID = 1,
                StockID = 10,
                AccountID = 10,
                Shares = 1,
                Limit = 1.11,
                Type = "Sell",
                TotalPrice = 1.11,
                Completed = true
            });

            Assert.IsTrue(classHelp.CheckOrder(Order));
        }

        [TestMethod]
        public void TestCheckOrderSellFail()
        {
            OrderClassHelp classHelp = new OrderClassHelp(new TestDALHolding(), new TestDALAccount(), new TestDALWallet());

            Order Order = new Order(new DTOOrder
            {
                ID = 1,
                StockID = 1,
                AccountID = 10,
                Shares = 12,
                Limit = 1.11,
                Type = "Sell",
                TotalPrice = 1.11,
                Completed = true
            });

            Assert.IsFalse(classHelp.CheckOrder(Order));
        }
    }
}
