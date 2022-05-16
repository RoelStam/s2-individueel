using System;
using System.Collections.Generic;
using StocksConsoleApp.Models;
using StocksConsoleApp.Containers;
using DataLibrary.DTOs;
using DataLibrary.DALs;

namespace StocksConsoleApp
{
    class Program
    {
        public static string connString = "Server=192.168.15.51;Database=dbi466937_stocks;User Id=dbi466937_stocks;Password=RoelStam;";
        public static AccountContainer accountContainer { get; } = new AccountContainer(new DALAccount(connString));
        public static Account account { get; } = new Account(new DALAccount(connString));
        public static IndexContainer indexContainer { get; } = new IndexContainer(new DALIndex(connString));
        public static Models.Index index { get; } = new Models.Index(new DALIndex(connString));
        public static StockContainer stockContainer { get; } = new StockContainer(new DALStock(connString));
        public static Stock stock { get; } = new Stock(new DALStock(connString));
        public static OrderContainer orderContainer { get; } = new OrderContainer(new DALOrder(connString));
        public static Order order { get; } = new Order(new DALOrder(connString));

        static void Main(string[] args)
        {
            Accounts();
            Console.WriteLine();
            Indices();
            Console.WriteLine();
            Stocks();
            Console.WriteLine();
            Orders();
            Console.ReadLine();
        }

        public static void Orders()
        {
            Console.WriteLine("Get all orders: ");
            foreach(var item in orderContainer.GetAllOrders())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}", item.ID, item.StockID, item.AccountID, item.Shares, item.Limit);
            }
            Console.WriteLine();

            Console.WriteLine("Add order: ");
            Console.WriteLine("Fill in stock ID:");
            order.StockID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill in Account ID:");
            order.AccountID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill in shares:");
            order.Shares = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill in limit:");
            order.Limit = Convert.ToDouble(Console.ReadLine());
            order.AddOrder();
            Console.WriteLine();

            Console.WriteLine("Get last order: ");
            Order LastOrder = orderContainer.GetOrderByID(orderContainer.GetAllOrders()[orderContainer.GetAllOrders().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", LastOrder.ID, LastOrder.StockID, LastOrder.AccountID, LastOrder.Shares, LastOrder.Limit);
            Console.WriteLine();

            Console.WriteLine("Update last order: ");
            order.ID = orderContainer.GetAllOrders()[orderContainer.GetAllOrders().Count - 1].ID;
            Console.WriteLine("Fill in stock ID: ");
            order.StockID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill in Account ID:");
            order.AccountID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill in shares:");
            order.Shares = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill in limit:");
            order.Limit = Convert.ToDouble(Console.ReadLine());
            order.UpdateOrder();
            LastOrder = orderContainer.GetOrderByID(orderContainer.GetAllOrders()[orderContainer.GetAllOrders().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", LastOrder.ID, LastOrder.StockID, LastOrder.AccountID, LastOrder.Shares, LastOrder.Limit);
            Console.WriteLine();
            
            Console.WriteLine("Delete last order: ");
            LastOrder = orderContainer.GetOrderByID(orderContainer.GetAllOrders()[orderContainer.GetAllOrders().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", LastOrder.ID, LastOrder.StockID, LastOrder.AccountID, LastOrder.Shares, LastOrder.Limit);
            orderContainer.DeleteOrder(orderContainer.GetAllOrders()[orderContainer.GetAllOrders().Count - 1].ID);
        }

        public static void Stocks()
        {
            Console.WriteLine("Get all stocks: ");
            foreach (var item in stockContainer.GetAllStocks())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", item.ID, item.IndexID, item.Name, item.Symbol, item.Price, item.Change);
            }
            Console.WriteLine();

            Console.WriteLine("Add stock:");
            Console.WriteLine("Fill in the index ID: ");
            stock.IndexID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill in the name: ");
            stock.Name = Console.ReadLine();
            Console.WriteLine("Fill in the symbol: ");
            stock.Symbol = Console.ReadLine();
            Console.WriteLine("Fill in the price");
            stock.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Fill in the change");
            stock.Change = Convert.ToDouble(Console.ReadLine());
            stock.AddStock();

            Console.WriteLine("Get last stock: ");
            Stock lastStock = stockContainer.GetStockByID(stockContainer.GetAllStocks()[stockContainer.GetAllStocks().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", lastStock.ID, lastStock.IndexID, lastStock.Name, lastStock.Symbol, lastStock.Price, lastStock.Change);
            Console.WriteLine();

            Console.WriteLine("Update last stock: ");
            stock.ID = stockContainer.GetAllStocks()[stockContainer.GetAllStocks().Count - 1].ID;
            Console.WriteLine("Fill in the index ID: ");
            stock.IndexID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Fill in the name: ");
            stock.Name = Console.ReadLine();
            Console.WriteLine("Fill in the symbol: ");
            stock.Symbol = Console.ReadLine();
            Console.WriteLine("Fill in the price");
            stock.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Fill in the change");
            stock.Change = Convert.ToDouble(Console.ReadLine());
            stock.UpdateStock();
            lastStock = stockContainer.GetStockByID(stockContainer.GetAllStocks()[stockContainer.GetAllStocks().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", lastStock.ID, lastStock.IndexID, lastStock.Name, lastStock.Symbol, lastStock.Price, lastStock.Change);
            Console.WriteLine();

            Console.ReadLine();

            Console.WriteLine("Delete last stock: ");
            lastStock = stockContainer.GetStockByID(stockContainer.GetAllStocks()[stockContainer.GetAllStocks().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", lastStock.ID, lastStock.IndexID, lastStock.Name, lastStock.Symbol, lastStock.Price, lastStock.Change);
            stockContainer.DeleteStock(stockContainer.GetAllStocks()[stockContainer.GetAllStocks().Count - 1].ID);
        }

        public static void Indices()
        {
            Console.WriteLine("Get all indices");
            foreach(var item in indexContainer.GetallIndices())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}",item.ID, item.Name, item.Symbol, item.Price, item.Change);
            }
            Console.WriteLine();

            Console.WriteLine("Add index: ");
            Console.WriteLine("Fill in the name: ");
            index.Name = Console.ReadLine();
            Console.WriteLine("Fill in the symbol: ");
            index.Symbol = Console.ReadLine();
            Console.WriteLine("Fill in the price: ");
            index.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Fill in the change: ");
            index.Change = Convert.ToDouble(Console.ReadLine());
            index.AddIndex();

            Console.WriteLine("Get last index: ");
            Models.Index lastIndex = indexContainer.GetIndexByID(indexContainer.GetallIndices()[indexContainer.GetallIndices().Count -1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", lastIndex.ID, lastIndex.Name, lastIndex.Symbol, lastIndex.Price, lastIndex.Change);
            Console.WriteLine();

            Console.WriteLine("Update last index:");
            index.ID = indexContainer.GetallIndices()[indexContainer.GetallIndices().Count - 1].ID;
            Console.WriteLine("Fill in the name: ");
            index.Name = Console.ReadLine();
            Console.WriteLine("Fill in the symbol: ");
            index.Symbol = Console.ReadLine();
            Console.WriteLine("Fill in the price: ");
            index.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Fill in the change: ");
            index.Change = Convert.ToDouble(Console.ReadLine());
            index.UpdateIndex();
            lastIndex = indexContainer.GetIndexByID(indexContainer.GetallIndices()[indexContainer.GetallIndices().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", lastIndex.ID, lastIndex.Name, lastIndex.Symbol, lastIndex.Price, lastIndex.Change);
            Console.WriteLine();

            Console.WriteLine("Delete last index:");
            lastIndex = indexContainer.GetIndexByID(indexContainer.GetallIndices()[indexContainer.GetallIndices().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", lastIndex.ID, lastIndex.Name, lastIndex.Symbol, lastIndex.Price, lastIndex.Change);
            indexContainer.DeleteIndex(indexContainer.GetallIndices()[indexContainer.GetallIndices().Count - 1].ID);
        }

        public static void Accounts()
        {
            Console.WriteLine("Get all accounts: ");

            foreach(var item in accountContainer.GetAllAccounts())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", item.ID, item.Username, item.EmailAddress, item.Password);
            }
            Console.WriteLine();

            Console.WriteLine("Add account: ");
            Console.WriteLine("Fill in your username:");
            account.Username = Console.ReadLine();
            Console.WriteLine("Fill in your emailAddress:");
            account.EmailAddress = Console.ReadLine();
            Console.WriteLine("Fill in your password:");
            account.Password = Console.ReadLine();
            account.AddAccount();

            Console.WriteLine("Get last account: ");
            Account lastAccount = accountContainer.GetAccountByID(accountContainer.GetAllAccounts()[accountContainer.GetAllAccounts().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}", lastAccount.ID, lastAccount.Username, lastAccount.EmailAddress, lastAccount.Password);
            Console.WriteLine();

            Console.WriteLine("Update last account: ");
            account.ID = accountContainer.GetAllAccounts()[accountContainer.GetAllAccounts().Count - 1].ID;
            Console.WriteLine("Fill in your username:");
            account.Username = Console.ReadLine();
            Console.WriteLine("Fill in your emailAddress:");
            account.EmailAddress = Console.ReadLine();
            Console.WriteLine("Fill in your password:");
            account.Password = Console.ReadLine();
            account.UpdateAccount();
            lastAccount = accountContainer.GetAccountByID(accountContainer.GetAllAccounts()[accountContainer.GetAllAccounts().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}", lastAccount.ID, lastAccount.Username, lastAccount.EmailAddress, lastAccount.Password);
            Console.WriteLine();

            Console.WriteLine("Delete last account: ");
            lastAccount = accountContainer.GetAccountByID(accountContainer.GetAllAccounts()[accountContainer.GetAllAccounts().Count - 1].ID);
            Console.WriteLine("{0}, {1}, {2}, {3}", lastAccount.ID, lastAccount.Username, lastAccount.EmailAddress, lastAccount.Password);
            accountContainer.DeleteAccount(accountContainer.GetAllAccounts()[accountContainer.GetAllAccounts().Count - 1].ID);
        }
    }
}
