using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Containers;
using StocksBusinessLayer.Models;
using DataLibrary.DALs;
using StocksWebApp.ViewModels;
using StocksWebApp.Converters;
using StocksWebApp.ClassHelp;

namespace StocksWebApp.Controllers
{
    public class HoldingController : Controller
    {
        static readonly string ConnString = "Server=home.wietze.xyz;Database=RoelStam;User Id=RoelStam;Password=Test3211!";
        //public static readonly string ConnString = @"Server=localhost\SQLEXPRESS;Database=Admin;Trusted_Connection=True;";
        readonly StockContainer stockContainer = new StockContainer(new DALStock(ConnString));
        readonly OrderContainer orderContainer = new OrderContainer(new DALOrder(ConnString));
        readonly WalletContainer walletContainer = new WalletContainer(new DALWallet(ConnString));
        readonly HoldingContainer holdingContainer = new HoldingContainer(new DALHolding(ConnString));
        readonly TransactionContainer transactionContainer = new TransactionContainer(new DALTransaction(ConnString));
        readonly IndexContainer indexContainer = new IndexContainer(new DALIndex(ConnString));
        readonly TransactionConverter transactionConverter = new TransactionConverter();
        readonly OrderConverter orderConverter = new OrderConverter();
        readonly HoldingConverter holdingConverter = new HoldingConverter();

        public IActionResult Index()
        {
            var model = new HoldingIndexViewModel();
            var holdings = holdingConverter.Convert(holdingContainer.GetAllHoldingsByAccountID(3));
            foreach(var holding in holdings)
            {
                holding.CurrentPrice = stockContainer.GetStockByID(holding.StockID).Price;
                holding.StockName = stockContainer.GetStockByID(holding.StockID).Name;
                holding.StockSymbol = stockContainer.GetStockByID(holding.StockID).Symbol;
                holding.IndexSymbol = indexContainer.GetIndexByID(stockContainer.GetStockByID(holding.StockID).IndexID).Symbol;
                holding.Gain = (holding.CurrentPrice - holding.AvaragePrice) * holding.TotalShares;
                holding.TotalWorth = holding.TotalShares * holding.CurrentPrice;
                holding.Gain = Math.Round(holding.Gain, 2);
            }
            model.Holdings = holdings;
            return View(model);
        }
    }
}
