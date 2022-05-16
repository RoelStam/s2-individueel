using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary.DALs;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using StocksConsoleApp.Converters;
using StocksConsoleApp.Models;

namespace StocksConsoleApp.Containers
{
    public class IndexContainer
    {
        //IndexConverter indexConverter = new IndexConverter();
        IIndexContainer iIndexContainer;

        public IndexContainer(IIndexContainer iIndexContainer)
        {
            this.iIndexContainer = iIndexContainer;
        }

        public List<Models.Index> GetallIndices()
        {
            return iIndexContainer.GetAllIndices().Select(x => new Models.Index(x)).ToList();
        }

        public Models.Index GetIndexByID(int ID)
        {
            return new Models.Index(iIndexContainer.GetIndexByID(ID));
        }

        public void DeleteIndex(int ID)
        {
            iIndexContainer.DeleteIndex(ID);
        }
    }
}
