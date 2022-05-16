using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DTOs
{
    public class DTOIndex
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }

        public DTOIndex(int ID, string Name, string Symbol, double Price, double Change)
        {
            this.ID = ID;
            this.Name = Name;
            this.Symbol = Symbol;
            this.Price = Price;
            this.Change = Change;
        }

        public DTOIndex(string Name, string Symbol, double Price, double Change)
        {
            this.Name = Name;
            this.Symbol = Symbol;
            this.Price = Price;
            this.Change = Change;
        }

        public DTOIndex() { }
    }
}
