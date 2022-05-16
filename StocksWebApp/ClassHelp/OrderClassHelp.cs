using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Models;
using StocksBusinessLayer.Containers;
using DataLibrary.DALs;
using DataLibrary.Interfaces;

namespace StocksWebApp.ClassHelp
{
    public class OrderClassHelp
    {
        public static readonly string connString = "Server=home.wietze.xyz;Database=RoelStam;User Id=RoelStam;Password=Test3211!";
        HoldingContainer holdingContainer;
        AccountContainer accountContainer;
        WalletContainer walletContainer;

        IHoldingContainer iHoldingContainer;
        IAccountContainer iAccountContainer;
        IWalletContainer iWalletContainer;

        public OrderClassHelp(IHoldingContainer iHoldingContainer, IAccountContainer iAccountContainer, IWalletContainer iWalletContainer)
        {
            this.iHoldingContainer = iHoldingContainer;
            this.iAccountContainer = iAccountContainer;
            this.iWalletContainer = iWalletContainer;
            holdingContainer = new HoldingContainer(this.iHoldingContainer);
            accountContainer = new AccountContainer(this.iAccountContainer);
            walletContainer = new WalletContainer(this.iWalletContainer);

        }

        public bool CheckOrder(Order order)
        {
            bool check = false;
            if (order.Type == "Sell")
            {
                var holdings = holdingContainer.GetAllHoldingsByAccountID(order.AccountID);
                foreach (var holding in holdings)
                {
                    if (holding.AccountID == order.AccountID && holding.StockID == order.StockID)
                    {
                        if (holding.TotalShares < order.Shares)
                        {
                            check = false;
                        }
                        else
                        {
                            check = true;
                        }
                    }
                }
            }
            else
            {
                var account = accountContainer.GetAccountByID(order.AccountID);
                var wallet = walletContainer.GetWalletByID(account.WalletID);
                if (wallet.Balance < order.TotalPrice)
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }
            return check;
        }
    }
}
