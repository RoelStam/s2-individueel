using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLibrary.DTOs;
using UnitTests.TestDAL;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using StocksBusinessLayer.Containers;
using StocksBusinessLayer.Models;

namespace UnitTests
{
    [TestClass]
    public class TestWatchlist
    {
        [TestMethod]
        public void TestGetWatchlistByAccountID()
        {
            WatchlistContainer Container = new WatchlistContainer(new TestDALWatchlist());

            Watchlist watchlist = new Watchlist(new DTOWatchlist
            {
                ID = 1,
                StockID = 1,
                AccountID = 1
            });

            Assert.IsNotNull(Container.GetWatchlistsByAccountID(1));

            List<Watchlist> watchlists = Container.GetWatchlistsByAccountID(1);

            Assert.AreEqual(watchlist.ID, watchlists[0].ID);
            Assert.AreEqual(watchlist.AccountID, watchlists[0].AccountID);
            Assert.AreEqual(watchlist.StockID, watchlists[0].StockID);
        }

        [TestMethod]
        public void TestGetWatchlist()
        {
            WatchlistContainer Container = new WatchlistContainer(new TestDALWatchlist());

            Watchlist watchlist = new Watchlist(new DTOWatchlist
            {
                ID = 1,
                StockID = 1,
                AccountID = 1
            });

            Watchlist watchlist1 = Container.GetWatchlist(1, 1);

            Assert.IsNotNull(watchlist1);

            Assert.AreEqual(watchlist1.ID, watchlist.ID);
            Assert.AreEqual(watchlist1.AccountID, watchlist.AccountID);
            Assert.AreEqual(watchlist1.StockID, watchlist.StockID);
        }

        [TestMethod]
        public void TestAddWatchlist()
        {
            TestDALWatchlist DAL = new TestDALWatchlist();
            WatchlistContainer Container = new WatchlistContainer(DAL);

            Watchlist watchlist = new Watchlist(new DTOWatchlist
            {
                ID = 5,
                StockID = 5,
                AccountID = 5
            });

            watchlist.AddWatchlist(DAL);

            Assert.AreEqual(watchlist.ID, Container.GetWatchlist(5, 5).ID);
        }

        [TestMethod]
        public void TestDeleteWatchlist()
        {
            WatchlistContainer Container = new WatchlistContainer(new TestDALWatchlist());

            Container.DeleteWatchlist(1);

            Assert.IsNull(Container.GetWatchlist(1, 1));
        }
    }
}
