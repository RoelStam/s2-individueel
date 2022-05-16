using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StocksWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using StocksWebApp.ViewModels;
using StocksBusinessLayer.Containers;
using StocksBusinessLayer.Models;
using StocksWebApp.Converters;
using DataLibrary.DALs;

namespace StocksWebApp.Controllers
{
    public class HomeController : Controller
    {
        public static readonly string ConnString = "Server=home.wietze.xyz;Database=RoelStam;User Id=RoelStam;Password=Test3211!";
        //public static readonly string ConnString = @"Server=localhost\SQLEXPRESS;Database=Admin;Trusted_Connection=True;";
        private readonly OrderConverter orderConverter = new OrderConverter();
        private readonly StockConverter stockConverter = new StockConverter();
        private readonly IndexConverter indexConverter = new IndexConverter();
        private readonly AccountConverter accountConverter = new AccountConverter();
        private readonly OrderContainer orderContainer = new OrderContainer(new DALOrder(ConnString));
        private readonly StockContainer stockContainer = new StockContainer(new DALStock(ConnString));
        private readonly IndexContainer indexContainer = new IndexContainer(new DALIndex(ConnString));
        private readonly WalletContainer walletContainer = new WalletContainer(new DALWallet(ConnString));
        private readonly AccountContainer accountContainer = new AccountContainer(new DALAccount(ConnString));

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            var account = accountConverter.Convert(accountContainer.GetAccountByID(3));
            model.Stocks = stockConverter.Convert(stockContainer.GetAllStocks());
            model.Orders = orderConverter.Convert(orderContainer.GetAllOrdersByAccountID(account.ID));
            model.Wallet = walletContainer.GetWalletByID(accountContainer.GetAccountByID(3).WalletID);
            foreach(var order in model.Orders)
            {
                order.StockName = stockContainer.GetStockByID(order.StockID).Name;
                order.IndexSymbol = indexContainer.GetIndexByID(stockContainer.GetStockByID(order.StockID).IndexID).Symbol;
            }
            foreach(var stock in model.Stocks)
            {
                stock.IndexSymbol = indexContainer.GetIndexByID(stock.IndexID).Symbol;
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
