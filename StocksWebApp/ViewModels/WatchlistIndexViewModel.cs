using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksWebApp.ViewModels;

namespace StocksWebApp.ViewModels
{
    public class WatchlistIndexViewModel
    {
        public List<WatchlistViewModel> Watchlists = new List<WatchlistViewModel>();
        public List<StockViewModel> Stocks = new List<StockViewModel>();
    }
}
