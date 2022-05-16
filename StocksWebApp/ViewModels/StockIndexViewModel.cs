using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.ViewModels
{
    public class StockIndexViewModel
    {
        public List<StockViewModel> StockViewModels { get; set; }
        public string SearchTerm { get; set; }
        public int IndexFilter { get; set; }
        public List<IndexViewModel> Indices { get; set; }
    }
}
