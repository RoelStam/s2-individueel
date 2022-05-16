using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Interfaces;
using DataLibrary.DTOs;

namespace StocksConsoleApp.Models
{
    public class Stock
    {
        public int ID { get; set; }
        public int IndexID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }

        IStock iStock;

        public Stock(DTOStock dTOStock)
        {
            this.ID = dTOStock.ID;
            this.IndexID = dTOStock.IndexID;
            this.Name = dTOStock.Name;
            this.Symbol = dTOStock.Symbol;
            this.Price = dTOStock.Price;
            this.Change = dTOStock.Change;
        }

        public Stock() { }

        public Stock(IStock iStock)
        {
            this.iStock = iStock;
        }

        public void UpdateStock()
        {
            DTOStock dTOStock = new DTOStock
            {
                ID = ID,
                IndexID = IndexID,
                Name = Name,
                Symbol = Symbol,
                Price = Price,
                Change = Change
            };

            iStock.UpdateStock(dTOStock);
        }

        public void AddStock()
        {
            DTOStock dTOStock = new DTOStock
            {
                IndexID = IndexID,
                Name = Name,
                Symbol = Symbol,
                Price = Price,
                Change = Change
            };

            iStock.AddStock(dTOStock);
        }
    }
}
