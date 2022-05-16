using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Containers;
using StocksBusinessLayer.Models;
using DataLibrary.DALs;
using DataLibrary.Interfaces;

namespace StocksWebApp.ClassHelp
{
    public class HoldingClassHelp
    {
        HoldingContainer holdingContainer;
        WalletContainer walletContainer;
        AccountContainer accountContainer;
        
        IHolding iHolding;
        IHoldingContainer iHoldingContainer;
        IOrder iOrder;
        IWallet iWallet;
        IWalletContainer iWalletContainer;
        IAccountContainer iAccountContainer;

        public HoldingClassHelp(IHolding iHolding, IHoldingContainer iHoldingContainer, IOrder iOrder, IWallet iWallet, IWalletContainer iWalletContainer, IAccountContainer iAccountContainer)
        {
            this.iHoldingContainer = iHoldingContainer;
            this.iHolding = iHolding;
            this.iOrder = iOrder;
            this.iWallet = iWallet;
            this.iWalletContainer = iWalletContainer;
            this.iAccountContainer = iAccountContainer;
            holdingContainer = new HoldingContainer(this.iHoldingContainer);
            walletContainer = new WalletContainer(this.iWalletContainer);
            accountContainer = new AccountContainer(this.iAccountContainer);
        }

        public void CheckHolding(Order order, int AccountID)
        {
            bool exists = false;
            List<Holding> holdings = holdingContainer.GetAllHoldingsByAccountID(AccountID);
            int i = 0;
            while (!exists && i < holdings.Count())
            {
                if (holdings[i].StockID == order.StockID)
                {
                    exists = true;
                    UpdateHoldings(holdings[i], order);
                }
                i++;
            }
            if (!exists)
            {
                AddHolding(order);
            }
        }

        public void AddHolding(Order order)
        {
            if (order.Type == "Buy")
            {
                Holding holding = new Holding()
                {
                    StockID = order.StockID,
                    AccountID = order.AccountID,
                    TotalShares = order.Shares,
                    TotalWorth = order.TotalPrice,
                    AvaragePrice = order.Limit
                };
                holding.AddHolding(iHolding);
                order.UpdateOrder(iOrder);
                Wallet wallet = walletContainer.GetWalletByID(accountContainer.GetAccountByID(order.AccountID).WalletID);
                wallet.Balance -= order.TotalPrice;
                wallet.UpdateWallet(iWallet);
            }
        }

        public void UpdateHoldings(Holding holding, Order order)
        {
            if (order.Type == "Buy")
            {
                holding.AvaragePrice = ((holding.TotalWorth / holding.TotalShares) + order.Limit) / 2;
                holding.TotalShares += order.Shares;
                holding.TotalWorth += order.TotalPrice;
                holding.UpdateHolding(iHolding);
                order.UpdateOrder(iOrder);
                Wallet wallet = walletContainer.GetWalletByID(accountContainer.GetAccountByID(order.AccountID).WalletID);
                wallet.Balance -= order.TotalPrice;
                wallet.UpdateWallet(iWallet);
            }
            else
            {
                holding.TotalShares -= order.Shares;
                holding.UpdateHolding(iHolding);
                order.UpdateOrder(iOrder);
                Wallet wallet = walletContainer.GetWalletByID(accountContainer.GetAccountByID(order.AccountID).WalletID);
                wallet.Balance += order.TotalPrice;
                wallet.UpdateWallet(iWallet);
            }
        }
    }
}
