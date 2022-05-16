using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Interfaces;
using StocksBusinessLayer.Models;

namespace StocksBusinessLayer.Containers
{
    public class WalletContainer
    {
        IWalletContainer iwalletContainer;

        public WalletContainer(IWalletContainer iwalletContainer)
        {
            this.iwalletContainer = iwalletContainer;
        }

        public Wallet GetWalletByID(int ID)
        {
            return new Wallet(iwalletContainer.GetWalletByID(ID));
        }
    }
}
