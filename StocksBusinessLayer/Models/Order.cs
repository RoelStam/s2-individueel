using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using StocksBusinessLayer.Converters;

namespace StocksBusinessLayer.Models
{
    public class Order
    {
        public int ID { get; }
        public int StockID { get; set; }
        public int AccountID { get; set; }
        public int Shares { get; set; }
        public double Limit { get; set; }
        public string Type { get; set; }
        public double TotalPrice { get; set; }
        public bool Completed { get; set; }

        public Order(DTOOrder dTOOrder)
        {
            this.ID = dTOOrder.ID;
            this.StockID = dTOOrder.StockID;
            this.AccountID = dTOOrder.AccountID;
            this.Shares = dTOOrder.Shares;
            this.Limit = dTOOrder.Limit;
            this.Type = dTOOrder.Type;
            this.TotalPrice = dTOOrder.TotalPrice;
            this.Completed = dTOOrder.Completed;
        }

        public Order() { }

        public void UpdateOrder(IOrder iOrder)
        {
            DTOOrder dTOOrder = new DTOOrder
            {
                ID = ID,
                StockID = StockID,
                AccountID = AccountID,
                Shares = Shares,
                Limit = Limit,
                Type = Type,
                TotalPrice = TotalPrice,
                Completed = Completed
            };
            iOrder.UpdateOrder(dTOOrder);
        }

        public void AddOrder(IOrder iOrder)
        {
            DTOOrder dTOOrder = new DTOOrder
            {
                ID = ID,
                StockID = StockID,
                AccountID = AccountID,
                Shares = Shares,
                Limit = Limit,
                Type = Type,
                TotalPrice = TotalPrice,
                Completed = Completed
            };
            iOrder.AddOrder(dTOOrder);
        }
    }
}
