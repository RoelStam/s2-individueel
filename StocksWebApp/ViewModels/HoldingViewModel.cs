using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.ViewModels
{
    public class HoldingViewModel
    {
        public int ID { get; set; }
        public int StockID { get; set; }
        public int AccountID { get; set; }
        public int TotalShares { get; set; }
        public double TotalWorth { get; set; }
        public double AvaragePrice { get; set; }
        public double CurrentPrice { get; set; }
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
        public string IndexSymbol { get; set; }
        public double Gain { get; set; }
    }
}
