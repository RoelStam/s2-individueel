using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Containers;
using StocksBusinessLayer.Models;
using DataLibrary.DALs;
using DataLibrary.Interfaces;

namespace StocksWebApp.ClassHelp
{
    public class TransactionClassHelp
    {
        static readonly string ConnString = "Server=home.wietze.xyz;Database=RoelStam;User Id=RoelStam;Password=Test3211!";
        StockContainer stockContainer;
        OrderContainer orderContainer;
        HoldingClassHelp holdingClassHelp = new HoldingClassHelp(new DALHolding(ConnString), 
                                                                 new DALHolding(ConnString), 
                                                                 new DALOrder(ConnString), 
                                                                 new DALWallet(ConnString), 
                                                                 new DALWallet(ConnString), 
                                                                 new DALAccount(ConnString));
        OrderClassHelp orderClassHelp = new OrderClassHelp(new DALHolding(ConnString), 
                                                           new DALAccount(ConnString), 
                                                           new DALWallet(ConnString));
        Random rnd = new Random();

        IStock iStock;
        ITransaction iTransaction;
        IStockContainer iStockContainer;
        IOrderContainer iOrderContainer;

        public TransactionClassHelp(IStock iStock, ITransaction iTransaction, IStockContainer iStockContainer, IOrderContainer iOrderContainer)
        {
            this.iStock = iStock;
            this.iTransaction = iTransaction;
            this.iStockContainer = iStockContainer;
            this.iOrderContainer = iOrderContainer;
            this.stockContainer = new StockContainer(this.iStockContainer);
            this.orderContainer = new OrderContainer(this.iOrderContainer);
        }

        public double Randomnr(int min, int max)
        {
            double random = (double)rnd.Next(min, max) / 100;
            return random;
        }

        public void NewPrices(List<Stock> Stocks)
        {
            foreach (var stock1 in Stocks)
            {
                if (stock1.Price > 1000)
                {
                    stock1.Change = Randomnr(-10000, 10000);
                    stock1.Price += stock1.Change;
                }
                else if (stock1.Price > 100)
                {
                    stock1.Change = Randomnr(-1000, 1000);
                    stock1.Price += stock1.Change;
                }
                else if (stock1.Price > 10)
                {
                    stock1.Change = Randomnr(-100, 100);
                    stock1.Price += stock1.Change;
                }
                else
                {
                    stock1.Change = Randomnr(-10, 10);
                    stock1.Price += stock1.Change;
                }
                stock1.UpdateStock(iStock);
            }
        }

        public void CheckForTransactions()
        {
            List<Order> allOrders = orderContainer.GetAllOrders();
            foreach (var order1 in allOrders)
            {
                if (!order1.Completed)
                {
                    var stock1 = stockContainer.GetStockByID(order1.StockID);
                    if (stock1.Price > order1.Limit - 0.15 && stock1.Price < order1.Limit + 0.15)
                    {
                        if(orderClassHelp.CheckOrder(order1))
                        {
                            var transaction = new Transaction()
                            {
                                AccountID = order1.AccountID,
                                OrderID = order1.ID,
                                DateTransacted = DateTime.Now
                            };
                            order1.Limit = stock1.Price;
                            order1.TotalPrice = order1.Limit * order1.Shares;
                            transaction.AddTransaction(iTransaction);
                            order1.Completed = true;
                            holdingClassHelp.CheckHolding(order1, order1.AccountID);
                        }
                    }
                }
            }
        }
    }
}
