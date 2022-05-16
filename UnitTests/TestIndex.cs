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
    public class TestIndex
    {
        public void AssertHelp(List<Index> expected, List<Index> actual)
        {
            for(int i = 0; i< expected.Count; i++)
            {
                Assert.AreEqual(expected[i].ID, actual[i].ID);
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Symbol, actual[i].Symbol);
                Assert.AreEqual(expected[i].Price, actual[i].Price);
                Assert.AreEqual(expected[i].Change, actual[i].Change);
            }
        }

        [TestMethod]
        public void TestGetAllIndices()
        {
            IndexContainer Container = new IndexContainer(new TestDALIndex());

            List<Index> indices = new List<Index>
            {
                new Index(new DTOIndex(1, "Index1", "Index1", 1.11, 1.11)),
                new Index(new DTOIndex(2, "Index2", "Index2", 2.22, 2.22)),
                new Index(new DTOIndex(3, "Index3", "Index3", 3.33, 3.33)),
                new Index(new DTOIndex(4, "Index4", "Index4", 4.44, 4.44)),
            };

            Assert.IsNotNull(Container.GetallIndices());
            Assert.AreEqual(4, Container.GetallIndices().Count);

            var indices1 = Container.GetallIndices();

            AssertHelp(indices, indices1);
        }

        [TestMethod]
        public void TestGetIndex()
        {
            IndexContainer Container = new IndexContainer(new TestDALIndex());

            Index index = new Index(new DTOIndex
            {
                ID = 1,
                Name = "Index1",
                Symbol = "Index1",
                Price = 1.11,
                Change = 1.11
            });

            Index index1 = Container.GetIndexByID(1);

            Assert.IsNotNull(index1);

            AssertHelp(new List<Index>() { index }, new List<Index>() { index1 });
        }

        [TestMethod]
        public void TestAddIndex()
        {
            TestDALIndex DAL = new TestDALIndex();
            IndexContainer Container = new IndexContainer(DAL);

            Index index = new Index(new DTOIndex
            {
                ID = 5,
                Name = "Index5",
                Symbol = "Index5",
                Price = 5.55,
                Change = 5.55
            });

            Assert.AreEqual(4, Container.GetallIndices().Count);
            index.AddIndex(DAL);
            Assert.AreEqual(5, Container.GetallIndices().Count);
            AssertHelp(new List<Index>() { index }, new List<Index>() { Container.GetIndexByID(5) });
        }

        [TestMethod]
        public void TestDeleteIndex()
        {
            IndexContainer Container = new IndexContainer(new TestDALIndex());

            List<Index> indices = new List<Index>
            {
                new Index(new DTOIndex(2, "Index2", "Index2", 2.22, 2.22)),
                new Index(new DTOIndex(3, "Index3", "Index3", 3.33, 3.33)),
                new Index(new DTOIndex(4, "Index4", "Index4", 4.44, 4.44)),
            };

            Assert.AreEqual(4, Container.GetallIndices().Count);
            Container.DeleteIndex(1);
            Assert.AreEqual(3, Container.GetallIndices().Count);

            var indices1 = Container.GetallIndices();

            AssertHelp(indices, indices1);
        }

        [TestMethod]
        public void TestUpdateIndex()
        {
            TestDALIndex DAL = new TestDALIndex();
            IndexContainer Container = new IndexContainer(DAL);

            Index index = new Index(new DTOIndex
            {
                ID = 4,
                Name = "Index5",
                Symbol = "Index5",
                Price = 5.55,
                Change = 5.55
            });

            Assert.AreNotEqual(index.Name, Container.GetIndexByID(4).Name);
            index.UpdateIndex(DAL);
            AssertHelp(new List<Index>() { index }, new List<Index>() { Container.GetIndexByID(4) });
        }

        [TestMethod]
        public void TestConstructor()
        {
            DTOIndex index = new DTOIndex
            {
                ID = 5,
                Name = "Index5",
                Symbol = "Index5",
                Price = 5.55,
                Change = 5.55
            };

            Index index1 = new Index(index);

            Assert.AreEqual(index1.ID, index.ID);
        }
    }
}
