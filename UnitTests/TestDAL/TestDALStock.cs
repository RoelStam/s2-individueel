using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace UnitTests.TestDAL
{
    public class TestDALStock : IStock, IStockContainer
    {
        List<DTOStock> Stocks = new List<DTOStock>
        {
            new DTOStock(1, 1, "Stock1", "Stock1", 1.11, 1.11),
            new DTOStock(2, 2, "Stock2", "Stock2", 2.22, 2.22),
            new DTOStock(3, 3, "Stock3", "Stock3", 3.33, 3.33),
            new DTOStock(4, 4, "Stock4", "Stock4", 4.44, 4.44),
            new DTOStock(10, 10, "Test", "Test", 5.00, 0.50),
            new DTOStock(11, 11, "Test", "Test", 1, 1)
        };

        public List<DTOStock> GetAllStocks()
        {
            return Stocks;
        }

        public DTOStock GetStockByID(int ID)
        {
            DTOStock Stock = new DTOStock();
            foreach(var stock in Stocks)
            {
                if(stock.ID == ID)
                {
                    Stock = stock;
                }
            }
            return Stock;
        }

        public void AddStock(DTOStock dTOStock)
        {
            Stocks.Add(dTOStock);
        }

        public void DeleteStock(int ID)
        {
            foreach (var stock in Stocks)
            {
                if (stock.ID == ID)
                {
                    Stocks.RemoveAt(Stocks.IndexOf(stock));
                    return;
                }
            }
        }

        public void UpdateStock(DTOStock dTOStock)
        {
            foreach (var stock in Stocks)
            {
                if (stock.ID == dTOStock.ID)
                {
                    stock.IndexID = dTOStock.IndexID;
                    stock.Name = dTOStock.Name;
                    stock.Symbol = dTOStock.Symbol;
                    stock.Price = dTOStock.Price;
                    stock.Change = dTOStock.Change;
                }
            }
        }

        //2 lists nodig om te testen, ook een index list
        public List<DTOStock> SearchStocks(string filter, string searchterm)
        {
            throw new NotImplementedException();
        }
    }
}
