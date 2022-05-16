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
    public class TestOrder
    {
        public void AssertHelp(List<Order> expected, List<Order> actual)
        {
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, actual[i].ID);
                Assert.AreEqual(expected[i].StockID, actual[i].StockID);
                Assert.AreEqual(expected[i].AccountID, actual[i].AccountID);
                Assert.AreEqual(expected[i].Shares, actual[i].Shares);
                Assert.AreEqual(expected[i].Limit, actual[i].Limit);
                Assert.AreEqual(expected[i].Type, actual[i].Type);
                Assert.AreEqual(expected[i].TotalPrice, actual[i].TotalPrice);
                Assert.AreEqual(expected[i].Completed, actual[i].Completed);
            }
        }

        [TestMethod]
        public void TestGetALlOrders()
        {
            OrderContainer Container = new OrderContainer(new TestDALOrder());

            List<Order> orders = new List<Order>
            {
                new Order(new DTOOrder(1, 1, 1, 1, 1.11, "Order1", 1.11, true)),
                new Order(new DTOOrder(2, 2, 2, 2, 2.22, "Order2", 2.22, true)),
                new Order(new DTOOrder(3, 3, 3, 3, 3.33, "Order3", 3.33, true)),
                new Order(new DTOOrder(4, 4, 4, 4, 4.44, "Order4", 4.44, true))
            };

            Assert.IsNotNull(Container.GetAllOrders());
            Assert.AreEqual(4, Container.GetAllOrders().Count);

            var orders1 = Container.GetAllOrders();

            AssertHelp(orders, orders1);
        }

        [TestMethod]
        public void TestGetAllOrdersByAccountID()
        {
            OrderContainer Container = new OrderContainer(new TestDALOrder());

            Order order = new Order(new DTOOrder
            {
                ID = 1,
                StockID = 1,
                AccountID = 1,
                Shares = 1,
                Limit = 1.11,
                Type = "Order1",
                TotalPrice = 1.11,
                Completed = true,
            });

            List<Order> orders = Container.GetAllOrdersByAccountID(1);

            Assert.IsNotNull(order);

            AssertHelp(new List<Order>() { order }, orders);
        }

        [TestMethod]
        public void TestGetOrder()
        {
            OrderContainer Container = new OrderContainer(new TestDALOrder());

            Order order = new Order(new DTOOrder
            {
                ID = 1,
                StockID = 1,
                AccountID = 1,
                Shares = 1,
                Limit = 1.11,
                Type = "Order1",
                TotalPrice = 1.11,
                Completed = true,
            });

            var order1 = Container.GetOrderByID(1);

            Assert.IsNotNull(order1);

            AssertHelp(new List<Order>() { order }, new List<Order>() { order1 });
        }

        [TestMethod]
        public void TestAddOrder()
        {
            TestDALOrder DAL = new TestDALOrder();
            OrderContainer Container = new OrderContainer(DAL);

            Order order = new Order(new DTOOrder
            {
                ID = 5,
                StockID = 5,
                AccountID = 5,
                Shares = 5,
                Limit = 5.55,
                Type = "Order5",
                TotalPrice = 5.55,
                Completed = true,
            });

            Assert.AreEqual(4, Container.GetAllOrders().Count);
            order.AddOrder(DAL);
            Assert.AreEqual(5, Container.GetAllOrders().Count);

            AssertHelp(new List<Order>() { order }, new List<Order>() { Container.GetOrderByID(5) });
        }

        [TestMethod]
        public void TestDeleteOrder()
        {
            OrderContainer Container = new OrderContainer(new TestDALOrder());

            List<Order> orders = new List<Order>
            {
                new Order(new DTOOrder(2, 2, 2, 2, 2.22, "Order2", 2.22, true)),
                new Order(new DTOOrder(3, 3, 3, 3, 3.33, "Order3", 3.33, true)),
                new Order(new DTOOrder(4, 4, 4, 4, 4.44, "Order4", 4.44, true))
            };

            Assert.AreEqual(4, Container.GetAllOrders().Count);
            Container.DeleteOrder(1);
            Assert.AreEqual(3, Container.GetAllOrders().Count);

            var orders1 = Container.GetAllOrders();

            AssertHelp(orders, orders1);
        }

        [TestMethod]
        public void TestUpdateOrder()
        {
            TestDALOrder DAL = new TestDALOrder();
            OrderContainer Container = new OrderContainer(DAL);

            Order order = new Order(new DTOOrder
            {
                ID = 4,
                StockID = 5,
                AccountID = 5,
                Shares = 5,
                Limit = 5.55,
                Type = "Order5",
                TotalPrice = 5.55,
                Completed = true,
            });

            Assert.AreNotEqual(order.Type, Container.GetOrderByID(4).Type);
            order.UpdateOrder(DAL);
            AssertHelp(new List<Order>() { order }, new List<Order>() { Container.GetOrderByID(4) });
        }


        [TestMethod]
        public void TestConstructor()
        {
            DTOOrder order = new DTOOrder
            {
                ID = 5,
                StockID = 5,
                AccountID = 5,
                Shares = 5,
                Limit = 5.55,
                Type = "Order5",
                TotalPrice = 5.55,
                Completed = true,
            };

            Order order1 = new Order(order);
            Assert.AreEqual(order.ID, order1.ID);
        }
    }
}
