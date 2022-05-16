using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DTOs
{
    public class DTOTransaction
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int OrderID { get; set; }
        public DateTime DateTransacted { get; set; }

        public DTOTransaction(int ID, int AccountID, int OrderID, DateTime DateTransacted)
        {
            this.ID = ID;
            this.AccountID = AccountID;
            this.OrderID = OrderID;
            this.DateTransacted = DateTransacted;
        }

        public DTOTransaction(int AccountID, int OrderID, DateTime DateTransacted)
        {
            this.AccountID = AccountID;
            this.OrderID = OrderID;
            this.DateTransacted = DateTransacted;
        }

        public DTOTransaction() { }
    }
}
