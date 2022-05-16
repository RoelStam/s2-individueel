using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Models;
using StocksWebApp.ViewModels;

namespace StocksWebApp.Converters
{
    public class WatchlistConverter
    {
        public List<WatchlistViewModel> Convert(List<Watchlist> watchlist)
        {
            return watchlist.Select(x => Convert(x)).ToList();
        }

        public WatchlistViewModel Convert(Watchlist watchlist)
        {
            return new WatchlistViewModel
            {
                ID = watchlist.ID,
                AccountID = watchlist.AccountID,
                StockID = watchlist.StockID
            };
        }

        /*
        public Watchlist Convert(WatchlistViewModel watchlistViewModel)
        {
            return new Watchlist
            {
                ID = watchlistViewModel.ID,
                AccountID = watchlistViewModel.AccountID,
                StockID= watchlistViewModel.StockID
            };
        }*/
    }
}
