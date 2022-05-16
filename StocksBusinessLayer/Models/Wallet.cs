using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Interfaces;
using DataLibrary.DTOs;

namespace StocksBusinessLayer.Models
{
    public class Wallet
    {
        public int ID { get; }
        public double Balance { get; set; }
        
        public Wallet(DTOWallet dTOWallet) 
        {
            this.ID = dTOWallet.ID;
            this.Balance = dTOWallet.Balance;
        }

        public Wallet() { }

        public void UpdateWallet(IWallet iWallet)
        {
            DTOWallet dTOWallet = new DTOWallet
            {
                ID = ID,
                Balance = Balance
            };

            iWallet.UpdateWallet(dTOWallet);
        }

        public void AddWallet(IWallet iWallet)
        {
            DTOWallet dTOWallet = new DTOWallet
            {
                ID = ID,
                Balance = Balance
            };

            iWallet.AddWallet(dTOWallet);
        }
    }
}
