using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using StocksConsoleApp.Models;

namespace StocksConsoleApp.Converters
{
    public class AccountConverter
    {
        public DTOAccount Convert(Account account)
        {
            return new DTOAccount()
            {
                ID = account.ID,
                Username = account.Username,
                EmailAddress = account.EmailAddress,
                Password = account.Password,
                WalletID = account.WalletID
            };
        }
    }
}
