using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Models;

namespace StocksWebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public AccountViewModel Account { get; set; }
        public Wallet Wallet { get; set; }
        public List<StockViewModel> Stocks { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
