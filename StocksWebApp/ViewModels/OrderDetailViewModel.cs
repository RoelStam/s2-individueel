using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksWebApp.ViewModels;

namespace StocksWebApp.ViewModels
{
    public class OrderDetailViewModel
    {
        public OrderViewModel orderViewModel { get; set; }
        public StockViewModel stockViewModel { get; set; }
        public IndexViewModel indexViewModel { get; set; }
    }
}
