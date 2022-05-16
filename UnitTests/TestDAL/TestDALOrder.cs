using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace UnitTests.TestDAL
{
    public class TestDALOrder : IOrder, IOrderContainer
    {
        List<DTOOrder> Orders = new List<DTOOrder>
        {
            new DTOOrder(1, 1, 1, 1, 1.11, "Order1", 1.11, true),
            new DTOOrder(2, 2, 2, 2, 2.22, "Order2", 2.22, true),
            new DTOOrder(3, 3, 3, 3, 3.33, "Order3", 3.33, true),
            new DTOOrder(4, 4, 4, 4, 4.44, "Order4", 4.44, true)
        };

        public List<DTOOrder> GetAllOrders()
        {
            return Orders;
        }

        public List<DTOOrder> GetAllOrdersByAccountID(int AccountID)
        {
            List<DTOOrder> orders = new List<DTOOrder>();
            foreach(var order in Orders)
            {
                if(order.AccountID == AccountID)
                {
                    orders.Add(order);
                }
            }
            return orders;
        }

        public DTOOrder GetOrderByID(int ID)
        {
            DTOOrder order = new DTOOrder();
            foreach (var order1 in Orders)
            {
                if (order1.ID == ID)
                {
                    order = order1;
                }
            }
            return order;
        }
        
        public void AddOrder(DTOOrder dTOOrder)
        {
            Orders.Add(dTOOrder);
        }

        public void DeleteOrder(int ID)
        {
            foreach (var order in Orders)
            {
                if (order.ID == ID)
                {
                    Orders.RemoveAt(Orders.IndexOf(order));
                    return;
                }
            }
        }

        public void UpdateOrder(DTOOrder dTOOrder)
        {
            foreach (var order in Orders)
            {
                if (order.ID == dTOOrder.ID)
                {
                    order.StockID = dTOOrder.StockID;
                    order.AccountID = dTOOrder.AccountID;
                    order.Shares = dTOOrder.Shares;
                    order.Limit = dTOOrder.Limit;
                    order.Type = dTOOrder.Type;
                    order.TotalPrice = dTOOrder.TotalPrice;
                    order.Completed = dTOOrder.Completed;
                }
            }
        }
    }
}
