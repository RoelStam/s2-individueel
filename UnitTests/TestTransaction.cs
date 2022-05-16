using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLibrary.DTOs;
using UnitTests.TestDAL;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using StocksBusinessLayer.Containers;
using StocksBusinessLayer.Models;
using System;

namespace UnitTests
{
    [TestClass]
    public class TestTransaction
    {
        public void AssertHelp(List<Transaction> expected, List<Transaction> actual)
        {
            for(int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, actual[i].ID);
                Assert.AreEqual(expected[i].OrderID, actual[i].OrderID);
                Assert.AreEqual(expected[i].AccountID, actual[i].AccountID);
                Assert.AreEqual(expected[i].DateTransacted, actual[i].DateTransacted);
            }
        }

        [TestMethod]
        public void TestGetAllTransactions()
        {
            TransactionContainer Container = new TransactionContainer(new TestDALTransaction());

            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction(new DTOTransaction(1, 1, 1, new DateTime(1, 1, 1))),
                new Transaction(new DTOTransaction(2, 2, 2, new DateTime(2, 2, 2))),
                new Transaction(new DTOTransaction(3, 3, 3, new DateTime(3, 3, 3))),
                new Transaction(new DTOTransaction(4, 4, 4, new DateTime(4, 4, 4)))
            };

            Assert.IsNotNull(Container.GetAllTransactions());
            Assert.AreEqual(4, Container.GetAllTransactions().Count);

            var transactions1 = Container.GetAllTransactions();

            AssertHelp(transactions, transactions1);
        }

        [TestMethod]
        public void TestGetAllTransactionsByAccountID()
        {
            TransactionContainer Container = new TransactionContainer(new TestDALTransaction());

            Transaction transaction = new Transaction(new DTOTransaction
            { 
                ID = 1,
                OrderID = 1,
                AccountID = 1,
                DateTransacted = new DateTime(1, 1, 1)
            });

            List<Transaction> transactions = Container.GetAllTransActionsByAccountID(1);

            Assert.IsNotNull(transactions);

            AssertHelp(new List<Transaction>() { transaction }, transactions);
        }

        [TestMethod]
        public void TestGetTransaction()
        {
            TransactionContainer Container = new TransactionContainer(new TestDALTransaction());

            Transaction transaction = new Transaction(new DTOTransaction
            {
                ID = 1,
                OrderID = 1,
                AccountID = 1,
                DateTransacted = new DateTime(1, 1, 1)
            });

            Transaction transaction1 = Container.GetTransaction(1);

            Assert.IsNotNull(transaction1);

            AssertHelp(new List<Transaction>() { transaction }, new List<Transaction>() { transaction1 });
        }

        [TestMethod]
        public void TestAddTransaction()
        {
            TestDALTransaction DAL = new TestDALTransaction();
            TransactionContainer Container = new TransactionContainer(DAL);

            Transaction transaction = new Transaction(new DTOTransaction
            {
                ID = 5,
                OrderID = 5,
                AccountID = 5,
                DateTransacted = new DateTime(5, 5, 5)
            });

            Assert.AreEqual(4, Container.GetAllTransactions().Count);
            transaction.AddTransaction(DAL);
            Assert.AreEqual(5, Container.GetAllTransactions().Count);
            AssertHelp(new List<Transaction>() { transaction }, new List<Transaction>() { Container.GetTransaction(5) });
        }

        [TestMethod]
        public void TestConstructor()
        {
            DTOTransaction transaction = new DTOTransaction
            {
                ID = 1, 
                OrderID = 1, 
                AccountID = 1, 
                DateTransacted = new DateTime(1, 1, 1)
            };

            Transaction transaction1 = new Transaction(transaction);

            Assert.AreEqual(transaction1.ID, transaction.ID);
        }
    }
}
