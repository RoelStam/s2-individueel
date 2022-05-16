using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace StocksBusinessLayer.Models
{
    public class Index
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }

        public Index(DTOIndex dTOIndex)
        {
            this.ID = dTOIndex.ID;
            this.Name = dTOIndex.Name;
            this.Symbol = dTOIndex.Symbol;
            this.Price = dTOIndex.Price;
            this.Change = dTOIndex.Change;
        }

        public Index() { }
        
        public void UpdateIndex(IIndex iIndex)
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

        public void AddIndex(IIndex iIndex)
        {
            DTOIndex dTOIndex = new DTOIndex
            {
                ID = ID,
                Name = Name,
                Symbol = Symbol,
                Price = Price,
                Change = Change
            };

            iIndex.AddIndex(dTOIndex);
        }
    }
}
