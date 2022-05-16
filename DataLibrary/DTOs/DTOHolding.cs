using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DTOs
{
    public class DTOHolding
    {
        public int ID { get; set; }
        public int StockID { get; set; }
        public int AccountID { get; set; }
        public int TotalShares { get; set; }
        public double TotalWorth { get; set; }
        public double AvaragePrice { get; set; }

        public DTOHolding(int ID, int StockID, int AccountID, int TotalShares, double TotalWorth, double AvaragePrice)
        {
            this.ID = ID;
            this.StockID = StockID;
            this.AccountID = AccountID;
            this.TotalShares = TotalShares;
            this.TotalWorth = TotalWorth;
            this.AvaragePrice = AvaragePrice;
        }

        public DTOHolding(int StockID, int AccountID, int TotalShares, double TotalWorth, double AvaragePrice)
        {
            this.StockID = StockID;
            this.AccountID = AccountID;
            this.TotalShares = TotalShares;
            this.TotalWorth = TotalWorth;
            this.AvaragePrice = AvaragePrice;
        }

        public DTOHolding() { }
    }
}
