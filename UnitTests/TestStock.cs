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
    public class TestStock
    {
        public void AssertHelp(List<Stock> expected, List<Stock> actual)
        {
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, actual[i].ID);
                Assert.AreEqual(expected[i].IndexID, actual[i].IndexID);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Symbol, actual[i].Symbol);
                Assert.AreEqual(expected[i].Price, actual[i].Price);
                Assert.AreEqual(expected[i].Change, actual[i].Change);
            }
        }

        [TestMethod]
        public void TestGetAllStocks()
        {
            StockContainer Container = new StockContainer(new TestDALStock());

            List<Stock> Stocks = new List<Stock>
            {
                new Stock(new DTOStock(1, 1, "Stock1", "Stock1", 1.11, 1.11)),
                new Stock(new DTOStock(2, 2, "Stock2", "Stock2", 2.22, 2.22)),
                new Stock(new DTOStock(3, 3, "Stock3", "Stock3", 3.33, 3.33)),
                new Stock(new DTOStock(4, 4, "Stock4", "Stock4", 4.44, 4.44))
            };

            Assert.IsNotNull(Container.GetAllStocks());
            Assert.AreEqual(6, Container.GetAllStocks().Count);

            var stocks = Container.GetAllStocks();

            AssertHelp(Stocks, stocks);
        }

        [TestMethod]
        public void TestGetStock()
        {
            StockContainer Container = new StockContainer(new TestDALStock());

            Stock stock = new Stock(new DTOStock
            {
                ID = 1,
                IndexID = 1,
                Name = "Stock1",
                Symbol = "Stock1",
                Price = 1.11,
                Change = 1.11
            });

            Stock stock1 = Container.GetStockByID(1);

            Assert.IsNotNull(stock1);

            AssertHelp(new List<Stock>() { stock }, new List<Stock>() { stock1 });
        }

        [TestMethod]
        public void TestAddStock()
        {
            TestDALStock testDAL = new TestDALStock();
            StockContainer Container = new StockContainer(testDAL);

            Stock stock = new Stock(new DTOStock
            {
                ID = 5,
                IndexID = 5,
                Name = "Stock5",
                Symbol = "Stock5",
                Price = 5.55,
                Change = 5.55
            });

            stock.AddStock(testDAL);
            Assert.AreEqual(7, Container.GetAllStocks().Count);
            AssertHelp(new List<Stock>() { stock }, new List<Stock>() { Container.GetStockByID(5) });
        }

        [TestMethod]
        public void TestDeleteStock()
        {
            StockContainer Container = new StockContainer(new TestDALStock());

            List<Stock> Stocks = new List<Stock>
            {
                new Stock(new DTOStock(2, 2, "Stock2", "Stock2", 2.22, 2.22)),
                new Stock(new DTOStock(3, 3, "Stock3", "Stock3", 3.33, 3.33)),
                new Stock(new DTOStock(4, 4, "Stock4", "Stock4", 4.44, 4.44))
            };

            Assert.AreEqual(6, Container.GetAllStocks().Count);
            Container.DeleteStock(1);
            Assert.AreEqual(5, Container.GetAllStocks().Count);
            var stocks = Container.GetAllStocks();

            AssertHelp(Stocks, stocks);
        }

        [TestMethod]
        public void TestUpdateStock()
        {
            TestDALStock testDAL = new TestDALStock();
            StockContainer Container = new StockContainer(testDAL);

            Stock stock = new Stock(new DTOStock
            {
                ID = 4,
                IndexID = 5,
                Name = "Stock",
                Symbol = "Stock5",
                Price = 5.55,
                Change = 5.55
            });

            Assert.AreNotEqual(stock.Name, Container.GetStockByID(4).Name);
            stock.UpdateStock(testDAL);

            AssertHelp(new List<Stock>() { stock }, new List<Stock>() { Container.GetStockByID(4) });
        }

        [TestMethod]
        public void TestConstructor()
        {
            DTOStock dTOStock = new DTOStock
            {
                ID = 4,
                IndexID = 5,
                Name = "Stock",
                Symbol = "Stock5",
                Price = 5.55,
                Change = 5.55
            };

            Stock stock = new Stock(dTOStock);

            Assert.AreEqual(stock.Name, dTOStock.Name);
        }

        //omzetten van order in transaction testen
        // zelf order, stock en wallet maken, testen of de order ook daadwerkelijk wordt verwerkt in het systeem
    }
}
