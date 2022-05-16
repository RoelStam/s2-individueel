using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksWebApp.ViewModels;
using StocksBusinessLayer.Models;

namespace StocksWebApp.Converters
{
    public class HoldingConverter
    {
        public List<HoldingViewModel> Convert(List<Holding> holdings)
        {
            return holdings.Select(x => Convert(x)).ToList();
        }

        public HoldingViewModel Convert(Holding holding)
        {
            return new HoldingViewModel
            {
                ID = holding.ID,
                StockID = holding.StockID,
                AccountID = holding.AccountID,
                TotalShares = holding.TotalShares,
                TotalWorth = holding.TotalWorth,
                AvaragePrice = holding.AvaragePrice
            };
        }
    }
}
