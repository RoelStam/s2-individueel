using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Interfaces;
using DataLibrary.DTOs;

namespace StocksBusinessLayer.Models
{
    public class Transaction
    {
        public int ID { get; }
        public int AccountID { get; set; }
        public int OrderID { get; set; }
        public DateTime DateTransacted { get; set; }

        public Transaction(DTOTransaction dTOTransaction)
        {
            this.ID = dTOTransaction.ID;
            this.AccountID = dTOTransaction.AccountID;
            this.OrderID = dTOTransaction.OrderID;
            this.DateTransacted = dTOTransaction.DateTransacted;
        }

        public Transaction() { }

        public void AddTransaction(ITransaction iTransaction)
        {
            DTOTransaction dTOTransaction = new DTOTransaction
            {
                ID = ID,
                AccountID = AccountID,
                OrderID = OrderID,
                DateTransacted = DateTransacted
            };

            iTransaction.AddTransaction(dTOTransaction);
        }
    }
}
