using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary.DALs;
using DataLibrary.Interfaces;
using StocksBusinessLayer.Models;
using DataLibrary.DTOs;

namespace StocksBusinessLayer.Containers
{
    public class StockContainer
    {
        IStockContainer iStockContainer;

        public StockContainer(IStockContainer iStockContainer)
        {
            this.iStockContainer = iStockContainer;
        }

        public List<Stock> GetAllStocks()
        {
            return iStockContainer.GetAllStocks().Select(x => new Stock(x)).ToList();
        }

        public List<Stock> SearchStocks(int filter, string searchterm)
        {
            return iStockContainer.SearchStocks(filter, searchterm).Select(x => new Stock(x)).ToList();
        }

        public Stock GetStockByID(int ID)
        {
            return new Stock(iStockContainer.GetStockByID(ID));
        }

        public void DeleteStock(int ID)
        {
            iStockContainer.DeleteStock(ID);
        }
    }
}
