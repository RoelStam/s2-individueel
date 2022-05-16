using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using StocksConsoleApp.Converters;

namespace StocksConsoleApp.Models
{
    public class Order
    {
        OrderConverter orderConverter = new OrderConverter();

        public int ID { get; set; }
        public int StockID { get; set; }
        public int AccountID { get; set; }
        public int Shares { get; set; }
        public double Limit { get; set; }

        public Order(DTOOrder dTOORder)
        {
            this.ID = dTOORder.ID;
            this.StockID = dTOORder.StockID;
            this.AccountID = dTOORder.AccountID;
            this.Shares = dTOORder.Shares;
            this.Limit = dTOORder.Limit;
        }

        public Order() { }

        public void UpdateOrder()
        {
            DTOOrder dTOOrder = new DTOOrder
            {
                ID = ID,
                StockID = StockID,
                AccountID = AccountID,
                Shares = Shares,
                Limit = Limit
            };
            iOrder.UpdateOrder(dTOOrder);
        }

        public void AddOrder()
        {
            DTOOrder dTOOrder = new DTOOrder
            {
                StockID = StockID,
                AccountID = AccountID,
                Shares = Shares,
                Limit = Limit
            };
            iOrder.AddOrder(dTOOrder);
            //return orderConverter.Convert(dTOOrder);
        }

        IOrder iOrder;

        public Order(IOrder iOrder)
        {
            this.iOrder = iOrder;
        }
    }
}
