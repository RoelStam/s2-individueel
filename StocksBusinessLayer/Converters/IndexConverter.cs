using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using StocksBusinessLayer.Models;

namespace StocksBusinessLayer.Converters
{
    public class IndexConverter
    {
        public DTOIndex Convert(Models.Index index)
        {
            return new DTOIndex()
            {
                ID = index.ID,
                Name = index.Name,
                Symbol = index.Symbol,
                Price = index.Price,
                Change = index.Change,
            };
        }
    }
}
