using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using StocksConsoleApp.Models;

namespace StocksConsoleApp.Converters
{
    public class OrderConverter
    {
        public DTOOrder Convert(Order order)
        {
            return new DTOOrder
            {
                ID = order.ID,
                StockID = order.StockID,
                AccountID = order.AccountID,
                Shares = order.Shares,
                Limit = order.Limit
            };
        }

        public Order Convert(DTOOrder dTOOrder)
        {
            return new Order
            {
                ID = dTOOrder.ID,
                StockID = dTOOrder.StockID,
                AccountID = dTOOrder.AccountID,
                Shares = dTOOrder.Shares,
                Limit = dTOOrder.Limit,
            };
        }
    }
}
