using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Models;
using StocksWebApp.ViewModels;

namespace StocksWebApp.Converters
{
    public class AccountConverter
    {
        //unused for now
        public List<AccountViewModel> Convert(List<Account> accounts)
        {
            return accounts.Select(x => Convert(x)).ToList();
        }

        public AccountViewModel Convert(Account account)
        {
            return new AccountViewModel
            {
                ID = account.ID,
                Username = account.Username,
                EmailAddress = account.EmailAddress,
                Password = account.Password,
                WalletID = account.WalletID
            };
        }

        /*
        public Account Convert(AccountViewModel accountViewModel)
        {
            return new Account
            {
                ID = accountViewModel.ID,
                Username = accountViewModel.Username,
                EmailAddress = accountViewModel.EmailAddress,
                Password = accountViewModel.Password,
                WalletID = accountViewModel.WalletID
            };
        }*/
    }
}
