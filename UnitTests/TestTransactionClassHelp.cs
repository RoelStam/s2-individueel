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
    public class TestTransactionClassHelp
    {
        [TestMethod]
        public void TestNewPrices()
        {
            TransactionClassHelp classHelp = new TransactionClassHelp(new TestDALStock(), new TestDALTransaction(), new TestDALStock(), new TestDALOrder());

            List<Stock> stocks = new List<Stock>
            {
                new Stock(new DTOStock(1, 1, "Test1", "Test1", 1.11, 1.11)),
                new Stock(new DTOStock(2, 2, "Test2", "Test2", 2.22, 2.22))
            };

            List<Stock> stocks1 = new List<Stock>
            {
                new Stock(new DTOStock(1, 1, "Test1", "Test1", 1.11, 1.11)),
                new Stock(new DTOStock(2, 2, "Test2", "Test2", 2.22, 2.22))
            };

            Assert.AreEqual(stocks[0].Price, stocks1[0].Price);
            Assert.AreEqual(stocks[1].Price, stocks1[1].Price);

            classHelp.NewPrices(stocks);

            Assert.AreNotEqual(stocks[0].Price, stocks1[0].Price);
            Assert.AreNotEqual(stocks[1].Price, stocks1[1].Price);
        }
    }
}
