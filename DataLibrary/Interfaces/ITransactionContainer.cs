using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface ITransactionContainer
    {
        List<DTOTransaction> GetAllTransactions();
        List<DTOTransaction> GetAllTransactionsByAccountID(int AccountID);
        DTOTransaction GetTransaction(int ID);
    }
}
