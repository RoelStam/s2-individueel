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
    public class TestAccount
    {
        public void AssertHelp(List<Account> expected, List<Account> actual)
        {
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, actual[i].ID);
                Assert.AreEqual(expected[i].Username, actual[i].Username);
                Assert.AreEqual(expected[i].EmailAddress, actual[i].EmailAddress);
                Assert.AreEqual(expected[i].Password, actual[i].Password);
                Assert.AreEqual(expected[i].WalletID, actual[i].WalletID);
            }
        }

        [TestMethod]
        public void TestGetAllAccounts()
        {
            AccountContainer Container = new AccountContainer(new TestDALAccount());

            List<Account> accounts = new List<Account>
            {
                new Account(new DTOAccount(1, "Account1", "Account1", "Account1", 1)),
                new Account(new DTOAccount(2, "Account2", "Account2", "Account2", 2)),
                new Account(new DTOAccount(3, "Account3", "Account3", "Account3", 3)),
                new Account(new DTOAccount(4, "Account4", "Account4", "Account4", 4))
            };

            Assert.IsNotNull(Container.GetAllAccounts());
            Assert.AreEqual(6, Container.GetAllAccounts().Count);

            List<Account> accounts1 = Container.GetAllAccounts();

            AssertHelp(accounts, accounts1);
        }

        [TestMethod]
        public void TestGetAccountByID()
        {
            AccountContainer Container = new AccountContainer(new TestDALAccount());

            Account account = new Account(new DTOAccount
            {
                ID = 1,
                Username = "Account1",
                EmailAddress = "Account1",
                Password = "Account1",
                WalletID = 1
            });

            Account account1 = Container.GetAccountByID(1);

            Assert.IsNotNull(account1);

            AssertHelp(new List<Account>() { account }, new List<Account>() { account1 });
        }

        [TestMethod]
        public void TestAddAccount()
        {
            TestDALAccount DAL = new TestDALAccount();
            AccountContainer Container = new AccountContainer(DAL);

            Account account = new Account(new DTOAccount
            {
                ID = 5,
                Username = "Account5",
                EmailAddress = "Account5",
                Password = "Account5",
                WalletID = 5
            });

            Assert.AreEqual(6, Container.GetAllAccounts().Count);
            account.AddAccount(DAL);
            Assert.AreEqual(7, Container.GetAllAccounts().Count);
            AssertHelp(new List<Account>() { account }, new List<Account>() { Container.GetAccountByID(5) });
        }

        [TestMethod]
        public void TestDeleteAccount()
        {
            AccountContainer Container = new AccountContainer(new TestDALAccount());

            List<Account> accounts = new List<Account>
            {
                new Account(new DTOAccount(2, "Account2", "Account2", "Account2", 2)),
                new Account(new DTOAccount(3, "Account3", "Account3", "Account3", 3)),
                new Account(new DTOAccount(4, "Account4", "Account4", "Account4", 4))
            };

            Assert.AreEqual(6, Container.GetAllAccounts().Count);
            Container.DeleteAccount(1);
            Assert.AreEqual(5, Container.GetAllAccounts().Count);

            List<Account> accounts1 = Container.GetAllAccounts();

            AssertHelp(accounts, accounts1);
        }

        [TestMethod]
        public void TestUpdateAccount()
        {
            TestDALAccount DAL = new TestDALAccount();
            AccountContainer Container = new AccountContainer(DAL);

            Account account = new Account(new DTOAccount
            {
                ID = 4,
                Username = "Account",
                EmailAddress = "Account5",
                Password = "Account5",
                WalletID = 5
            });

            Assert.AreNotEqual(account.Username, Container.GetAccountByID(4).Username);
            account.UpdateAccount(DAL);
            AssertHelp(new List<Account>() { account }, new List<Account>() { Container.GetAccountByID(4) });
        }

        [TestMethod]
        public void TestConstructor()
        {
            DTOAccount account = new DTOAccount
            {
                ID = 1,
                Username = "Account1",
                EmailAddress = "Account1",
                Password = "Account1",
                WalletID = 1
            };

            Account account1 = new Account(account);

            Assert.AreEqual(account1.ID, account.ID);
        }
    }
}
