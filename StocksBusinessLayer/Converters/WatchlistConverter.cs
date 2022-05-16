using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using StocksBusinessLayer.Models;

namespace StocksBusinessLayer.Converters
{
    public class WatchlistConverter
    {
        public DTOWatchlist Convert(Watchlist watchlist)
        {
            return new DTOWatchlist
            {
                ID = watchlist.ID,
                AccountID = watchlist.AccountID,
                StockID = watchlist.StockID
            };
        }
    }
}
