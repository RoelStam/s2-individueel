using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Models;
using StocksWebApp.ViewModels;

namespace StocksWebApp.Converters
{
    public class TransactionConverter
    {
        public List<TransactionViewModel> Convert(List<Transaction> transactions)
        {
            return transactions.Select(x => Convert(x)).ToList();
        }

        public TransactionViewModel Convert(Transaction transaction)
        {
            return new TransactionViewModel
            {
                ID = transaction.ID,
                OrderID = transaction.OrderID,
                AccountID = transaction.AccountID,
                DateTransacted = transaction.DateTransacted
            };
        }
    }
}
