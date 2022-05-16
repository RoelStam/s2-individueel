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
    public class TestHoldingClassHelp
    {
        [TestMethod]
        public void TestAddHolding()
        {
            TestDALHolding DALHolding = new TestDALHolding();
            HoldingClassHelp classHelp = new HoldingClassHelp(DALHolding, DALHolding, new TestDALOrder(), new TestDALWallet(), new TestDALWallet(), new TestDALAccount());
            HoldingContainer Container = new HoldingContainer(DALHolding);

            Order order = new Order(new DTOOrder
            {
                ID = 1,
                StockID = 111,
                AccountID = 10,
                Shares = 1,
                Limit = 1.11,
                Type = "Buy",
                TotalPrice = 1.11,
                Completed = true
            });

            Assert.AreEqual(5, Container.GetAllHoldings().Count);
            classHelp.CheckHolding(order, 10);
            Assert.AreEqual(6, Container.GetAllHoldings().Count);
        }

        [TestMethod]
        public void TestUpdateHolding()
        {
            TestDALHolding DALHolding = new TestDALHolding();
            HoldingClassHelp classHelp = new HoldingClassHelp(DALHolding, DALHolding, new TestDALOrder(), new TestDALWallet(), new TestDALWallet(), new TestDALAccount());
            HoldingContainer Container = new HoldingContainer(DALHolding);

            Order order = new Order(new DTOOrder
            {
                ID = 1,
                StockID = 10,
                AccountID = 10,
                Shares = 1,
                Limit = 1.11,
                Type = "Buy",
                TotalPrice = 1.11,
                Completed = true
            });

            Assert.AreEqual(10, Container.GetHolding(10).TotalShares);
            classHelp.CheckHolding(order, 10);
            Assert.AreEqual(11, Container.GetHolding(10).TotalShares);
        }
    }
}
