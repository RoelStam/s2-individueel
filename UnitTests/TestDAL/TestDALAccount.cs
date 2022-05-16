using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace UnitTests.TestDAL
{
    public class TestDALAccount : IAccount, IAccountContainer
    {
        List<DTOAccount> Accounts = new List<DTOAccount>
        {
            new DTOAccount(1, "Account1", "Account1", "Account1", 1),
            new DTOAccount(2, "Account2", "Account2", "Account2", 2),
            new DTOAccount(3, "Account3", "Account3", "Account3", 3),
            new DTOAccount(4, "Account4", "Account4", "Account4", 4),
            new DTOAccount(10, "Test", "Test", "Test", 10),
            new DTOAccount(11, "Test", "Test", "Test", 11)
        };

        public List<DTOAccount> GetAllAccounts()
        {
            return Accounts;
        }

        public DTOAccount GetAccountById(int ID)
        {
            DTOAccount account = new DTOAccount();
            foreach(var Account in Accounts)
            {
                if(Account.ID == ID)
                {
                    account = Account;
                }
            }
            return account;
        }

        public void AddAccount(DTOAccount dTOAccount)
        {
            Accounts.Add(dTOAccount);
        }

        public void DeleteAccount(int ID)
        {
            foreach(var account in Accounts)
            {
                if(account.ID == ID)
                {
                    Accounts.RemoveAt(Accounts.IndexOf(account));
                    return;
                }
            }
        }

        public void UpdateAccount(DTOAccount dTOAccount)
        {
            foreach(var account in Accounts)
            {
                if(account.ID == dTOAccount.ID)
                {
                    account.Username = dTOAccount.Username;
                    account.EmailAddress = dTOAccount.EmailAddress;
                    account.Password = dTOAccount.Password;
                    account.WalletID = dTOAccount.WalletID;
                }
            }
        }
    }
}
