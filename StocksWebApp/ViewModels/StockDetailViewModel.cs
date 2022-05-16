using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksWebApp.ViewModels;

namespace StocksWebApp.ViewModels
{
    public class StockDetailViewModel
    {
        public StockViewModel stock { get; set; }
        public IndexViewModel index { get; set; }
        public WatchlistViewModel watchlistViewModel { get; set; }
        public WatchlistIndexViewModel watchlistIndexViewModel { get; set; }
    }
}
