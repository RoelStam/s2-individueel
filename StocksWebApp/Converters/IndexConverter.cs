using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksWebApp.ViewModels;
using StocksBusinessLayer.Models;

namespace StocksWebApp.Converters
{
    //unused for now
    public class IndexConverter
    {
        public List<IndexViewModel> Convert(List<StocksBusinessLayer.Models.Index> indices)
        {
            return indices.Select(x => Convert(x)).ToList();
        }

        public IndexViewModel Convert(StocksBusinessLayer.Models.Index index)
        {
            return new IndexViewModel
            {
                ID = index.ID,
                Name = index.Name,
                Symbol = index.Symbol,
                Price = index.Price,
                Change = index.Change
            };
        }

        /*
        public StocksBusinessLayer.Models.Index Convert(IndexViewModel indexViewModel)
        {
            return new StocksBusinessLayer.Models.Index
            {
                ID = indexViewModel.ID,
                Name = indexViewModel.Name,
                Symbol = indexViewModel.Symbol,
                Price = indexViewModel.Price,
                Change = indexViewModel.Change
            };
        }*/
    }
}
