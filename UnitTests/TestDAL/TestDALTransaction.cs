using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace UnitTests.TestDAL
{
    public class TestDALTransaction : ITransaction, ITransactionContainer
    {
        List<DTOTransaction> Transactions = new List<DTOTransaction>
        {
            new DTOTransaction(1, 1, 1, new DateTime(1, 1, 1)),
            new DTOTransaction(2, 2, 2, new DateTime(2, 2, 2)),
            new DTOTransaction(3, 3, 3, new DateTime(3, 3, 3)),
            new DTOTransaction(4, 4, 4, new DateTime(4, 4, 4))
        };

        public List<DTOTransaction> GetAllTransactions()
        {
            return Transactions;
        }

        public List<DTOTransaction> GetAllTransactionsByAccountID(int AccountID)
        {
            List<DTOTransaction> transactions = new List<DTOTransaction>();
            foreach(var transaction in Transactions)
            {
                if (transaction.AccountID == AccountID)
                {
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }

        public DTOTransaction GetTransaction(int ID)
        {
            DTOTransaction transaction = new DTOTransaction();
            foreach (var transaction1 in Transactions)
            {
                if (transaction1.ID == ID)
                {
                    transaction = transaction1;
                }
            }
            return transaction;
        }

        public void AddTransaction(DTOTransaction dTOTransaction)
        {
            Transactions.Add(dTOTransaction);
        }
    }
}
