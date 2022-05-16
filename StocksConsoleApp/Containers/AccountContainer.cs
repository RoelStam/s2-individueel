using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary.DALs;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using StocksConsoleApp.Converters;
using StocksConsoleApp.Models;

namespace StocksConsoleApp.Containers
{
    public class AccountContainer 
    {
        //AccountConverter accountConverter = new AccountConverter();

        public List<Account> GetAllAccounts()
        {
            return IAccountContainer.GetAllAccounts().Select(x => new Account(x)).ToList();
        }

        public Account GetAccountByID(int ID)
        {
            return new Account(IAccountContainer.GetAccountById(ID));
        }

        public void DeleteAccount(int ID)
        {
            IAccountContainer.DeleteAccount(ID);
        }

        IAccountContainer IAccountContainer;

        public AccountContainer(IAccountContainer iAccountContainer)
        {
            this.IAccountContainer = iAccountContainer;
        }
    }
}
