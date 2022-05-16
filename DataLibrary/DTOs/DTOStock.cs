using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DTOs
{
    public class DTOStock
    {
        public int ID { get; set; }
        public int IndexID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }

        public DTOStock(int ID, int IndexID, string Name, string Symbol, double Price, double Change)
        {
            this.ID = ID;
            this.IndexID = IndexID;
            this.Name = Name;
            this.Symbol = Symbol;
            this.Price = Price;
            this.Change = Change;
        }

        public DTOStock(int IndexID, string Name, string Symbol, double Price, double Change)
        {
            this.IndexID = IndexID;
            this.Name = Name;
            this.Symbol = Symbol;
            this.Price = Price;
            this.Change = Change;
        }

        public DTOStock() { }

        public DTOStock(int ID, int IndexID, double Price, double Change)
        {
            this.ID = ID;
            this.IndexID = IndexID;
            this.Price = Price;
            this.Change = Change;
        }

    }
}
