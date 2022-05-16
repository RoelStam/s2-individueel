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
    public class TransactionController : Controller
    {
        static readonly string ConnString = "Server=home.wietze.xyz;Database=RoelStam;User Id=RoelStam;Password=Test3211!";
        //public static readonly string ConnString = @"Server=localhost\SQLEXPRESS;Database=Admin;Trusted_Connection=True;";
        readonly StockContainer stockContainer = new StockContainer(new DALStock(ConnString));
        readonly OrderContainer orderContainer = new OrderContainer(new DALOrder(ConnString));
        readonly TransactionContainer transactionContainer = new TransactionContainer(new DALTransaction(ConnString));
        readonly IndexContainer indexContainer = new IndexContainer(new DALIndex(ConnString));
        readonly TransactionConverter transactionConverter = new TransactionConverter();
        readonly OrderConverter orderConverter = new OrderConverter();
        TransactionClassHelp classHelp = new TransactionClassHelp(new DALStock(ConnString), 
                                                                  new DALTransaction(ConnString), 
                                                                  new DALStock(ConnString),
                                                                  new DALOrder(ConnString));
        
        public IActionResult Index()
        {
            var orders = orderConverter.Convert(orderContainer.GetAllOrdersByAccountID(3));
            var model = new TransactionIndexViewModel
            {
                Transactions = transactionConverter.Convert(transactionContainer.GetAllTransActionsByAccountID(3))
            };
            foreach(var transaction in model.Transactions)
            {
                foreach(var order in orders)
                {
                    if(order.ID == transaction.OrderID)
                    {
                        transaction.TotalPrice = order.TotalPrice;
                        transaction.PPS = order.Limit;
                        transaction.Type = order.Type;
                        var stock = stockContainer.GetStockByID(order.StockID);
                        transaction.Name = stock.Name;
                        transaction.Symbol = stock.Symbol;
                        var index = indexContainer.GetIndexByID(stock.IndexID);
                        transaction.IndexSymbol = index.Symbol;
                        transaction.Shares = order.Shares;
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Start()
        {
            List<Stock> Stocks =  stockContainer.GetAllStocks();
            classHelp.NewPrices(Stocks);
            classHelp.CheckForTransactions();
            return RedirectToAction("Index", "Stock");
        }
    }
}
