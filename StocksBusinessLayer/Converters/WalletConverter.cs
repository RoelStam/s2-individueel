using System;
using System.Collections.Generic;
using System.Text;
using StocksBusinessLayer.Models;
using DataLibrary.DTOs;

namespace StocksBusinessLayer.Converters
{
    public class WalletConverter
    {
        public DTOWallet Convert(Wallet wallet)
        {
            return new DTOWallet
            {
                ID = wallet.ID,
                Balance = wallet.Balance
            };
        }
    }
}
