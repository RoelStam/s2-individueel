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
    public class StockController : Controller
    {
        public static readonly string ConnString = "Server=home.wietze.xyz;Database=RoelStam;User Id=RoelStam;Password=Test3211!";
        //public static readonly string ConnString = @"Server=localhost\SQLEXPRESS;Database=Admin;Trusted_Connection=True;";
        private readonly IndexConverter indexConverter = new IndexConverter();
        private readonly StockConverter stockConverter = new StockConverter();
        readonly WatchlistConverter watchlistConverter = new WatchlistConverter();
        private readonly StockContainer stockContainer = new StockContainer(new DALStock(ConnString));
        private readonly IndexContainer indexContainer = new IndexContainer(new DALIndex(ConnString));
        readonly WatchlistContainer watchlistContainer = new WatchlistContainer(new DALWatchlist(ConnString));

        public IActionResult Index()
        {
            var model = new StockIndexViewModel
            {
                StockViewModels = stockConverter.Convert(stockContainer.GetAllStocks()),
                Indices = indexConverter.Convert(indexContainer.GetallIndices())
            };
            foreach(var stock in model.StockViewModels)
            {
                stock.IndexSymbol = indexConverter.Convert(indexContainer.GetIndexByID(stock.IndexID)).Symbol;
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Index(StockIndexViewModel SearchModel)
        {
            var model = new StockIndexViewModel
            {
                StockViewModels = stockConverter.Convert(stockContainer.SearchStocks(SearchModel.IndexFilter, SearchModel.SearchTerm)),
                Indices = indexConverter.Convert(indexContainer.GetallIndices())
            };
            foreach (var stock in model.StockViewModels)
            {
                stock.IndexSymbol = indexConverter.Convert(indexContainer.GetIndexByID(stock.IndexID)).Symbol;
            }
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var watchlistIndexViewModel = new WatchlistIndexViewModel
            {
                Watchlists = watchlistConverter.Convert(watchlistContainer.GetWatchlistsByAccountID(3))
            };
            
            StockViewModel stock = stockConverter.Convert(stockContainer.GetStockByID(id));
            var model = new StockDetailViewModel
            {
                stock = stock,
                index = indexConverter.Convert(indexContainer.GetIndexByID(stock.IndexID)),
                watchlistViewModel = watchlistConverter.Convert(watchlistContainer.GetWatchlist(3, stock.ID)),
                watchlistIndexViewModel = watchlistIndexViewModel
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int stockID)
        {
            return View();
        }
    }
}
