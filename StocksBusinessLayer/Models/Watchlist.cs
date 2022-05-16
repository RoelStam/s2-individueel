using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Interfaces;
using DataLibrary.DTOs;

namespace StocksBusinessLayer.Models
{
    public class Watchlist
    {
        public int ID { get; }
        public int AccountID { get; set; }
        public int StockID { get; set; }

        public Watchlist(DTOWatchlist dTOWatchlist)
        {
            this.ID = dTOWatchlist.ID;
            this.AccountID = dTOWatchlist.AccountID;
            this.StockID = dTOWatchlist.StockID;
        }

        public Watchlist() { }

        public void AddWatchlist(IWatchlist iWatchlist)
        {
            DTOWatchlist dTOWatchlist = new DTOWatchlist
            {
                ID = this.ID,
                AccountID = this.AccountID,
                StockID = this.StockID,
            };

            iWatchlist.AddWatchList(dTOWatchlist);
        }
    }
}
