using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace StocksConsoleApp.Models
{
    public class Index
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }

        IIndex iIndex;

        public Index(DTOIndex dTOIndex)
        {
            this.ID = dTOIndex.ID;
            this.Name = dTOIndex.Name;
            this.Symbol = dTOIndex.Symbol;
            this.Price = dTOIndex.Price;
            this.Change = dTOIndex.Change;
        }

        public Index() { }

        public Index(IIndex iIndex)
        {
            this.iIndex = iIndex;
        }

        public void UpdateIndex()
        {
            DTOIndex dTOIndex = new DTOIndex
            {
                ID = ID,
                Name = Name,
                Symbol = Symbol,
                Price = Price,
                Change = Change
            };

            iIndex.UpdateIndex(dTOIndex);
        }

        public void AddIndex()
        {
            DTOIndex dTOIndex = new DTOIndex
            {
                Name = Name,
                Symbol = Symbol,
                Price = Price,
                Change = Change
            };

            iIndex.AddIndex(dTOIndex);
        }
    }
}
