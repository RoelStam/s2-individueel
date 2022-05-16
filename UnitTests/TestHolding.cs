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
    public class TestHolding
    {
        public void AssertHelp(List<Holding> expected, List<Holding> actual)
        {
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, actual[i].ID);
                Assert.AreEqual(expected[i].StockID, actual[i].StockID);
                Assert.AreEqual(expected[i].AccountID, actual[i].AccountID);
                Assert.AreEqual(expected[i].TotalShares, actual[i].TotalShares);
                Assert.AreEqual(expected[i].TotalWorth, actual[i].TotalWorth);
                Assert.AreEqual(expected[i].AvaragePrice, actual[i].AvaragePrice);
            }
        }

        [TestMethod]
        public void TestGetAllHoldings()
        {
            HoldingContainer Container = new HoldingContainer(new TestDALHolding());

            List<Holding> holdings = new List<Holding>
            {
                new Holding(new DTOHolding(1, 1, 1, 1, 1.11, 1.11)),
                new Holding(new DTOHolding(2, 2, 2, 2, 2.22, 2.22)),
                new Holding(new DTOHolding(3, 3, 3, 3, 3.33, 3.33)),
                new Holding(new DTOHolding(4, 4, 4, 4, 4.44, 4.44))
            };

            Assert.IsNotNull(Container.GetAllHoldings());
            Assert.AreEqual(5, Container.GetAllHoldings().Count);


            AssertHelp(holdings, Container.GetAllHoldings());
        }

        [TestMethod]
        public void TestGetAllHoldingsByAccountID()
        {
            HoldingContainer Container = new HoldingContainer(new TestDALHolding());

            Holding holding = new Holding(new DTOHolding
            {
                ID = 1,
                StockID = 1,
                AccountID = 1,
                TotalShares = 1,
                TotalWorth = 1.11,
                AvaragePrice = 1.11
            });

            List<Holding> holdings = Container.GetAllHoldingsByAccountID(1);

            Assert.IsNotNull(holdings);

            AssertHelp(new List<Holding>(){ holding }, holdings);
        }

        [TestMethod]
        public void TestGetHolding()
        {
            HoldingContainer Container = new HoldingContainer(new TestDALHolding());

            Holding holding = new Holding(new DTOHolding
            {
                ID = 1,
                StockID = 1,
                AccountID = 1,
                TotalShares = 1,
                TotalWorth = 1.11,
                AvaragePrice = 1.11
            });

            Holding holding1 = Container.GetHolding(1);

            Assert.IsNotNull(holding1);

            AssertHelp(new List<Holding>() { holding }, new List<Holding>() { holding1 });
        }

        [TestMethod]
        public void TestAddHolding()
        {
            TestDALHolding DAL = new TestDALHolding();
            HoldingContainer Container = new HoldingContainer(DAL);

            Holding holding = new Holding(new DTOHolding
            {
                ID = 5,
                StockID = 5,
                AccountID = 5,
                TotalShares = 5,
                TotalWorth = 5.55,
                AvaragePrice = 5.55
            });

            Assert.AreEqual(5, Container.GetAllHoldings().Count);
            holding.AddHolding(DAL);
            Assert.AreEqual(6, Container.GetAllHoldings().Count);
            AssertHelp(new List<Holding>() { holding }, new List<Holding>() { Container.GetHolding(5) });
        }

        [TestMethod]
        public void TestDeleteHolding()
        {
            HoldingContainer Container = new HoldingContainer(new TestDALHolding());

            List<Holding> holdings = new List<Holding>
            {
                new Holding(new DTOHolding(2, 2, 2, 2, 2.22, 2.22)),
                new Holding(new DTOHolding(3, 3, 3, 3, 3.33, 3.33)),
                new Holding(new DTOHolding(4, 4, 4, 4, 4.44, 4.44))
            };

            Assert.AreEqual(5, Container.GetAllHoldings().Count);
            Container.DeleteHolding(1);
            Assert.AreEqual(4, Container.GetAllHoldings().Count);

            List<Holding> holdings1 = Container.GetAllHoldings();

            AssertHelp(holdings, holdings1);
        }

        [TestMethod]
        public void TestUpdateHolding()
        {
            TestDALHolding DAL = new TestDALHolding();
            HoldingContainer Container = new HoldingContainer(DAL);

            Holding holding = new Holding(new DTOHolding
            {
                ID = 1,
                StockID = 1,
                AccountID = 1,
                TotalShares = 1,
                TotalWorth = 1.11,
                AvaragePrice = 1.12
            });

            Assert.AreNotEqual(holding.AvaragePrice, Container.GetHolding(1).AvaragePrice);
            holding.UpdateHolding(DAL);
            AssertHelp(new List<Holding>() { holding }, new List<Holding>() { Container.GetHolding(1) });
        }

        [TestMethod]
        public void TestConstructor()
        {
            DTOHolding holding = new DTOHolding
            {
                ID = 1,
                StockID = 1,
                AccountID = 1,
                TotalShares = 1,
                TotalWorth = 1.11,
                AvaragePrice = 1.12
            };

            Holding holding1 = new Holding(holding);

            Assert.AreEqual(holding1.AvaragePrice, holding.AvaragePrice);
        }
    }
}
