using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Models;
using StocksWebApp.ViewModels;

namespace StocksWebApp.Converters
{
    public class StockConverter
    {
        public List<StockViewModel> Convert(List<Stock> stocks)
        {
            return stocks.Select(x => Convert(x)).ToList();
        }

        public StockViewModel Convert(Stock stock)
        {
            return new StockViewModel
            {
                ID = stock.ID,
                IndexID = stock.IndexID,
                Name = stock.Name,
                Symbol = stock.Symbol,
                Price = stock.Price,
                Change = stock.Change
            };
        }

        /*
        public Stock Convert(StockViewModel stockViewModel)
        {
            return new Stock
            {
                ID = stockViewModel.ID,
                IndexID = stockViewModel.IndexID,
                Name = stockViewModel.Name,
                Symbol = stockViewModel.Symbol,
                Price = stockViewModel.Price,
                Change = stockViewModel.Change
            };
        }*/
    }
}
