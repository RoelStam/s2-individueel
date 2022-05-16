using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Models;
using StocksWebApp.ViewModels;

namespace StocksWebApp.Converters
{
    public class OrderConverter
    {
        public List<OrderViewModel> Convert(List<Order> orders)
        {
            return orders.Select(x => Convert(x)).ToList();
        }

        public OrderViewModel Convert(Order order)
        {
            return new OrderViewModel
            {
                ID = order.ID,
                StockID = order.StockID,
                AccountID = order.AccountID,
                Shares = order.Shares,
                Limit = order.Limit,
                Type = order.Type,
                TotalPrice = order.TotalPrice,
                Completed = order.Completed
            };
        }

        /*
        public Order Convert(OrderViewModel orderViewModel)
        {
            return new Order
            {
                ID = orderViewModel.ID,
                StockID = orderViewModel.StockID,
                AccountID = orderViewModel.AccountID,
                Shares = orderViewModel.Shares,
                Limit = orderViewModel.Limit,
                Type = orderViewModel.Type,
                TotalPrice = orderViewModel.TotalPrice,
                Completed = orderViewModel.Completed
            };
        }*/
    }
}
