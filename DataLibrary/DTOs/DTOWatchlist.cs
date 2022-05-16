using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DTOs
{
    public class DTOWatchlist
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int StockID { get; set; }

        public DTOWatchlist(int ID, int AccountID, int StockID)
        {
            this.ID = ID;
            this.AccountID = StockID;
            this.StockID = StockID;
        }

        public DTOWatchlist(int AccountID, int StockID)
        {
            this.AccountID = AccountID;
            this.StockID = StockID;
        }

        public DTOWatchlist() { }
    }
}
