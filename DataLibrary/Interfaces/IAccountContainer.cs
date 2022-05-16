using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IAccountContainer
    {
        List<DTOAccount> GetAllAccounts();
        void DeleteAccount(int ID);
        DTOAccount GetAccountById(int ID);
    }
}
