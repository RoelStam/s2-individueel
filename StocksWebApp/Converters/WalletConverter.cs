using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Models;
using StocksWebApp.ViewModels;

namespace StocksWebApp.Converters
{
    public class WalletConverter
    {
        public WalletViewModel Convert(Wallet wallet)
        {
            return new WalletViewModel
            {
                ID = wallet.ID,
                Balance = wallet.Balance
            };
        }
    }
}
