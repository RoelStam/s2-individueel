using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DTOs
{
    public class DTOAccount
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int WalletID { get; set; }

        public DTOAccount(int ID, string Username, string EmailAddress, string Password, int WalletID)
        {
            this.ID = ID;
            this.Username = Username;
            this.EmailAddress = EmailAddress;
            this.Password = Password;
            this.WalletID = WalletID;
        }

        public DTOAccount(string Username, string EmailAddress, string Password, int WalletID)
        {
            this.Username = Username;
            this.EmailAddress = EmailAddress;
            this.Password = Password;
            this.WalletID = WalletID;
        }

        public DTOAccount() { }
    }
}
