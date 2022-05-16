using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLibrary.DTOs;
using UnitTests.TestDAL;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using StocksBusinessLayer.Containers;
using StocksBusinessLayer.Models;

namespace UnitTests
{
    [TestClass]
    public class TestWallet
    {
        public void AssertHelp(List<Wallet> expected, List<Wallet> actual)
        {
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, actual[i].ID);
                Assert.AreEqual(expected[i].Balance, actual[i].Balance);
            }
        }

        [TestMethod]
        public void TestGetWalletByID()
        {
            WalletContainer Container = new WalletContainer(new TestDALWallet());

            Wallet wallet = new Wallet(new DTOWallet
            {
                ID = 1, 
                Balance = 1.11,
            });

            var wallet1 = Container.GetWalletByID(1);

            Assert.IsNotNull(wallet1);

            AssertHelp(new List<Wallet>() { wallet }, new List<Wallet>() { wallet1 });
        }

        [TestMethod]
        public void TestAddWallet()
        {
            TestDALWallet DAL = new TestDALWallet();
            WalletContainer Container = new WalletContainer(DAL);

            Wallet wallet = new Wallet(new DTOWallet
            {
                ID = 5,
                Balance = 5.55,
            });

            wallet.AddWallet(DAL);

            AssertHelp(new List<Wallet>() { wallet }, new List<Wallet>() { Container.GetWalletByID(5) });
        }

        [TestMethod]
        public void TestUpdateWallet()
        {
            TestDALWallet DAL = new TestDALWallet();
            WalletContainer Containet = new WalletContainer(DAL);

            Wallet wallet = new Wallet(new DTOWallet
            {
                ID = 4,
                Balance = 5.55,
            });

            Assert.AreNotEqual(wallet.Balance, Containet.GetWalletByID(4).Balance);
            wallet.UpdateWallet(DAL);
            AssertHelp(new List<Wallet>() { wallet }, new List<Wallet>() { Containet.GetWalletByID(4) });
        }
    }
}
