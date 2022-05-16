using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.ViewModels
{
    public class WatchlistViewModel
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int StockID { get; set; }
    }
}
