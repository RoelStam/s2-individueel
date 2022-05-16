using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.ViewModels
{
    public class StockViewModel
    {
        public int ID { get; set; }
        public int IndexID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public string IndexSymbol { get; set; }
    }
}
