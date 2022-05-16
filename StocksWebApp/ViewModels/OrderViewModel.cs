using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.ViewModels
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public int StockID { get; set; }
        public int AccountID { get; set; }
        public int Shares { get; set; }
        public double Limit { get; set; }
        public string Type { get; set; }
        public double TotalPrice { get; set; }
        public bool Completed { get; set; }
        public string StockName { get; set; }
        public string IndexSymbol { get; set; }
    }
}
