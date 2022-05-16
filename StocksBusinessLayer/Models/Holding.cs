using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Interfaces;
using DataLibrary.DTOs;

namespace StocksBusinessLayer.Models
{
    public class Holding
    {
        public int ID { get; }
        public int StockID { get; set; }
        public int AccountID { get; set; }
        public int TotalShares { get; set; }
        public double TotalWorth { get; set; }
        public double AvaragePrice { get; set; }


        public Holding(DTOHolding dTOHolding)
        {
            this.ID = dTOHolding.ID;
            this.StockID = dTOHolding.StockID;
            this.AccountID = dTOHolding.AccountID;
            this.TotalShares = dTOHolding.TotalShares;
            this.TotalWorth = dTOHolding.TotalWorth;
            this.AvaragePrice = dTOHolding.AvaragePrice;
        }

        public Holding() { }

        public void AddHolding(IHolding iHolding)
        {
            DTOHolding dTOHolding = new DTOHolding
            {
                ID = ID,
                StockID = StockID,
                AccountID = AccountID,
                TotalShares = TotalShares,
                TotalWorth = TotalWorth,
                AvaragePrice = AvaragePrice
            };

            iHolding.AddHolding(dTOHolding);
        }

        public void UpdateHolding(IHolding iHolding)
        {
            DTOHolding dTOHolding = new DTOHolding
            {
                ID = ID,
                StockID = StockID,
                AccountID = AccountID,
                TotalShares = TotalShares,
                TotalWorth = TotalWorth,
                AvaragePrice = AvaragePrice
            };

            iHolding.UpdateHolding(dTOHolding);
        }
    }
}
