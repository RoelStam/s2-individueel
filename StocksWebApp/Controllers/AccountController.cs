using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StocksBusinessLayer.Containers;
using StocksWebApp.Converters;
using DataLibrary.DALs;
using StocksWebApp.ViewModels;

namespace StocksWebApp.Controllers
{
    public class AccountController : Controller
    {

        public static readonly string ConnString = "Server=home.wietze.xyz;Database=RoelStam;User Id=RoelStam;Password=Test3211!";
        //public static readonly string ConnString = @"Server=localhost\SQLEXPRESS;Database=Admin;Trusted_Connection=True;";
        HoldingContainer holdingContainer = new HoldingContainer(new DALHolding(ConnString));
        WalletContainer walletContainer = new WalletContainer(new DALWallet(ConnString));
        AccountContainer accountContainer = new AccountContainer(new DALAccount(ConnString));
        StockContainer stockContainer = new StockContainer(new DALStock(ConnString));
        AccountConverter accountConverter = new AccountConverter();
        HoldingConverter holdingConverter = new HoldingConverter();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            var account = accountConverter.Convert(accountContainer.GetAccountByID(3));
            var wallet = walletContainer.GetWalletByID(account.WalletID);
            var holdings = holdingConverter.Convert(holdingContainer.GetAllHoldingsByAccountID(account.ID));
            var model = new AccountViewModel
            {
                ID = account.ID,
                Username = account.Username,
                EmailAddress = account.EmailAddress,
                Holdings = holdings,
                Available = wallet.Balance
            };
            foreach(var holding in model.Holdings)
            {
                holding.CurrentPrice = stockContainer.GetStockByID(holding.StockID).Price;
                holding.Gain = (holding.CurrentPrice - holding.AvaragePrice) * holding.TotalShares;
                model.InHoldings += holding.TotalWorth;
                model.TotalGain += holding.Gain;
                model.InHoldings = Math.Round(model.InHoldings, 2);
                model.TotalGain = Math.Round(model.TotalGain, 2);
            }
            model.TotalAccount = model.InHoldings + model.Available;

            return View(model);
        }
    }
}
