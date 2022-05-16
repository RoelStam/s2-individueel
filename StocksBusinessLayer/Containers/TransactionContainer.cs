using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Interfaces;
using StocksBusinessLayer.Models;
using System.Linq;

namespace StocksBusinessLayer.Containers
{
    public class TransactionContainer
    {
        ITransactionContainer iTransactionContainer;

        public TransactionContainer(ITransactionContainer iTransactionContainer)
        {
            this.iTransactionContainer = iTransactionContainer;
        }

        public List<Transaction> GetAllTransactions()
        {
            return iTransactionContainer.GetAllTransactions().Select(x => new Transaction(x)).ToList();
        }

        public List<Transaction> GetAllTransActionsByAccountID(int AccountID)
        {
            return iTransactionContainer.GetAllTransactionsByAccountID(AccountID).Select(x => new Transaction(x)).ToList();
        }

        public Transaction GetTransaction(int ID)
        {
            return new Transaction(iTransactionContainer.GetTransaction(ID));
        }
    }
}
