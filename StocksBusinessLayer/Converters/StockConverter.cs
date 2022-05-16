﻿using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using StocksBusinessLayer.Models;

namespace StocksBusinessLayer.Converters
{
    public class StockConverter
    {
        public DTOStock Convert(Stock stock)
        {
            return new DTOStock
            {
                ID = stock.ID,
                IndexID = stock.IndexID,
                Name = stock.Name,
                Symbol = stock.Symbol,
                Price = stock.Price,
                Change = stock.Change
            };
        }

    }
}
