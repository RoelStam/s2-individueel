using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary.DALs;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using StocksBusinessLayer.Models;

namespace StocksBusinessLayer.Containers
{
    public class OrderContainer
    {
        public List<Order> GetAllOrders()
        {
            return iOrderContainer.GetAllOrders().Select(x => new Order(x)).ToList();
        }

        public List<Order> GetAllOrdersByAccountID(int AccountID)
        {
            return iOrderContainer.GetAllOrdersByAccountID(AccountID).Select(x => new Order(x)).ToList();
        }

        public Order GetOrderByID(int ID)
        {
            return new Order(iOrderContainer.GetOrderByID(ID));
        }

        public void DeleteOrder(int ID)
        {
            iOrderContainer.DeleteOrder(ID);
        }

        IOrderContainer iOrderContainer;

        public OrderContainer(IOrderContainer iOrderContainer)
        {
            this.iOrderContainer = iOrderContainer;
        }
    }
}
