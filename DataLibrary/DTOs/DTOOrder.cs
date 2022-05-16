using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DTOs
{
    public class DTOOrder
    {
        public int ID { get; set; }
        public int StockID { get; set; }
        public int AccountID { get; set; }
        public int Shares { get; set; }
        public double Limit { get; set; }
        public string Type { get; set; }
        public double TotalPrice { get; set; }
        public bool Completed { get; set; }

        public DTOOrder(int ID, int StockID, int AccountID, int Shares, double Limit, string Type, double TotalPrice, bool Completed)
        {
            this.ID = ID;
            this.StockID = StockID;
            this.AccountID = AccountID;
            this.Shares = Shares;
            this.Limit = Limit;
            this.Type = Type;
            this.TotalPrice = TotalPrice;
            this.Completed = Completed;
        }

        public DTOOrder(int StockID, int AccountID, int Shares, double Limit, string Type, double TotalPrice, bool Completed)
        {
            this.StockID = StockID;
            this.AccountID = AccountID;
            this.Shares = Shares;
            this.Limit = Limit;
            this.Type = Type;
            this.TotalPrice = TotalPrice;
            this.Completed = Completed;
        }

        public DTOOrder() { }
    }
}
