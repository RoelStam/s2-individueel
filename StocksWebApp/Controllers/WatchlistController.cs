using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksWebApp.ViewModels;
using StocksWebApp.Models;
using StocksWebApp.Converters;
using DataLibrary.DALs;
using StocksBusinessLayer.Models;
using StocksBusinessLayer.Containers;

namespace StocksWebApp.Controllers
{
    public class WatchlistController : Controller
    {
        public static readonly string ConnString = "Server=home.wietze.xyz;Database=RoelStam;User Id=RoelStam;Password=Test3211!";
        //public static readonly string ConnString = @"Server=localhost\SQLEXPRESS;Database=Admin;Trusted_Connection=True;";
        readonly WatchlistConverter watchlistConverter = new WatchlistConverter();
        readonly IndexConverter indexConverter = new IndexConverter();
        readonly StockConverter stockConverter = new StockConverter();
        readonly WatchlistContainer watchlistContainer = new WatchlistContainer(new DALWatchlist(ConnString));
        readonly IndexContainer indexContainer = new IndexContainer(new DALIndex(ConnString));
        readonly StockContainer stockContainer = new StockContainer(new DALStock(ConnString));

        public IActionResult Index()
        {
            var model = new WatchlistIndexViewModel
            {
                Watchlists = watchlistConverter.Convert(watchlistContainer.GetWatchlistsByAccountID(3))
            };
            foreach(var watchlist in model.Watchlists)
            {
                StockViewModel stock = stockConverter.Convert(stockContainer.GetStockByID(watchlist.StockID));
                stock.IndexSymbol = indexContainer.GetIndexByID(stock.IndexID).Symbol;
                model.Stocks.Add(stock);
            }

            return View(model);
        }

        public IActionResult AddRemoveWatchlist(int StockID)
        {
            if(IsInWatchlist(StockID))
            {
                var watchlist = watchlistContainer.GetWatchlist(3, StockID);

                watchlistContainer.DeleteWatchlist(watchlist.ID);
            }
            else
            {
                var watchlist = new Watchlist();

                watchlist.AccountID = 3;
                watchlist.StockID = StockID;
                watchlist.AddWatchlist(new DALWatchlist(ConnString)); ;
            }
            
            return RedirectToAction("Index");
        }

        public bool IsInWatchlist(int StockID)
        {
            var WVW = watchlistConverter.Convert(watchlistContainer.GetWatchlistsByAccountID(3));
            foreach(var watchlist in WVW)
            {
                if(watchlist.StockID == StockID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
