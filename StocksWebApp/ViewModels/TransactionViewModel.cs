using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.ViewModels
{
    public class TransactionViewModel
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int OrderID { get; set; }
        public DateTime DateTransacted { get; set; }
        public int Shares { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string IndexSymbol { get; set; }
        public double PPS { get; set; }
        public double TotalPrice { get; set; }
    }
}
