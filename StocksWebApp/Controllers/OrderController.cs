using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksWebApp.ViewModels;
using StocksWebApp.Converters;
using DataLibrary.DALs;
using StocksBusinessLayer.Models;
using StocksBusinessLayer.Containers;
using StocksWebApp.ClassHelp;

namespace StocksWebApp.Controllers
{
    public class OrderController : Controller
    {
        public static readonly string ConnString = "Server=home.wietze.xyz;Database=RoelStam;User Id=RoelStam;Password=Test3211!";
        //public static readonly string ConnString = @"Server=localhost\SQLEXPRESS;Database=Admin;Trusted_Connection=True;";
        private readonly OrderConverter orderConverter = new OrderConverter();
        private readonly StockConverter stockConverter = new StockConverter();
        private readonly IndexConverter indexConverter = new IndexConverter();
        private readonly OrderContainer orderContainer = new OrderContainer(new DALOrder(ConnString));
        private readonly StockContainer stockContainer = new StockContainer(new DALStock(ConnString));
        private readonly IndexContainer indexContainer = new IndexContainer(new DALIndex(ConnString));
        OrderClassHelp orderClassHelp = new OrderClassHelp(new DALHolding(ConnString),
                                                           new DALAccount(ConnString),
                                                           new DALWallet(ConnString));

        public IActionResult Index()
        {
            try
            {
                var model = new OrderIndexViewModel
                {

                    OrderViewModels = orderConverter.Convert(orderContainer.GetAllOrdersByAccountID(3))
                };
                foreach (var order in model.OrderViewModels)
                {
                    order.StockName = stockContainer.GetStockByID(order.StockID).Name;
                    order.IndexSymbol = indexContainer.GetIndexByID(stockContainer.GetStockByID(order.StockID).IndexID).Symbol;
                }
                return View(model);
            }
            catch(Exception error)
            {
                return RedirectToAction("Error", "Error", new { error = error.Message });
            }
        }

        public IActionResult Detail(int id)
        {
            try
            {
                OrderViewModel order = orderConverter.Convert(orderContainer.GetOrderByID(id));
                var model = new OrderDetailViewModel
                {
                    orderViewModel = order
                };
                model.stockViewModel = stockConverter.Convert(stockContainer.GetStockByID(order.StockID));
                model.indexViewModel = indexConverter.Convert(indexContainer.GetIndexByID(model.stockViewModel.IndexID));
                return View(model);
            }
            catch (Exception error)
            {
                return RedirectToAction("Error", "Error", new { error = error.Message });
            }
        }

        [HttpGet]
        public IActionResult PlaceOrder(int stockID)
        {
            var model = new OrderAddViewModel();
            var modelStock = stockConverter.Convert(stockContainer.GetStockByID(stockID));
            var modelIndex = indexConverter.Convert(indexContainer.GetIndexByID(modelStock.IndexID));
            model.StockID = stockID;
            model.StockChange = modelStock.Change;
            model.StockPrice = modelStock.Price;
            model.StockSymbol = modelStock.Symbol;
            model.StockName = modelStock.Name;
            model.IndexName = modelIndex.Name;
            model.IndexSymbol = modelIndex.Symbol;
            model.AccountID = 3;
            return View(model);
        }

        [HttpPost]
        public IActionResult PlaceOrder(OrderAddViewModel model, int StockID)
        {
            try
            {
                var order = new Order();
                order.StockID = model.StockID;
                order.AccountID = 3;
                order.Shares = model.Shares;
                order.Limit = model.Limit;
                order.Type = model.Type;
                order.TotalPrice = model.Shares * model.Limit;
                var order1 = new Order
                {
                    Type = order.Type,
                    StockID = order.StockID,
                    AccountID = order.AccountID,
                    Limit = order.Limit,
                    TotalPrice = order.TotalPrice
                };
                if (orderClassHelp.CheckOrder(order1))
                {
                    order.AddOrder(new DALOrder(ConnString));
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("PlaceOrder", new { StockID = StockID });
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("Error", "Error", new { error = error.Message });
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = orderConverter.Convert(orderContainer.GetOrderByID(id));
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(OrderViewModel model, int id)
        {
            try
            {
                var order = orderContainer.GetOrderByID(id);
                order.StockID = orderConverter.Convert(orderContainer.GetOrderByID(id)).StockID;
                order.AccountID = 3;
                order.Shares = model.Shares;
                order.Limit = model.Limit;
                order.TotalPrice = order.Shares * order.Limit;
                if (orderClassHelp.CheckOrder(order))
                {
                    order.UpdateOrder(new DALOrder(ConnString));
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Update", new { id = id });
                }
            }
            catch (Exception error)
            {
                return RedirectToAction("Error", "Error", new { error = error.Message });
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = orderConverter.Convert(orderContainer.GetOrderByID(id));
            model.StockName = stockConverter.Convert(stockContainer.GetStockByID(model.StockID)).Name;
            model.IndexSymbol = indexConverter.Convert(indexContainer.GetIndexByID(stockConverter.Convert(stockContainer.GetStockByID(model.StockID)).IndexID)).Symbol;
            return View(model);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            try
            {
                orderContainer.DeleteOrder(id);
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                return RedirectToAction("Error", "Error", new { error = error.Message });
            }
        }
    }
}
