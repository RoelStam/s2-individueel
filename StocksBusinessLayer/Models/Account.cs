using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace StocksBusinessLayer.Models
{
    public class Account
    {
        public int ID { get; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int WalletID { get; set; }

        public Account(DTOAccount dTOAccount)
        {
            this.ID = dTOAccount.ID;
            this.Username = dTOAccount.Username;
            this.EmailAddress = dTOAccount.EmailAddress;
            this.Password = dTOAccount.Password;
            this.WalletID = dTOAccount.WalletID;
        }

        public Account() { }

        public void UpdateAccount(IAccount iAccount)
        {
            DTOAccount dTOAccount = new DTOAccount
            {
                ID = ID,
                Username = Username,
                EmailAddress = EmailAddress,
                Password = Password,
                WalletID = WalletID
            };
            iAccount.UpdateAccount(dTOAccount);
        }

        public void AddAccount(IAccount iAccount)
        {
            DTOAccount dTOAccount = new DTOAccount
            {
                ID = ID,
                Username = Username,
                EmailAddress = EmailAddress,
                Password = Password,
                WalletID = WalletID
            };
            iAccount.AddAccount(dTOAccount);
        }
    }
}
