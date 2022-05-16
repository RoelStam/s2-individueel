using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Interfaces;
using StocksBusinessLayer.Models;
using System.Linq;

namespace StocksBusinessLayer.Containers
{
    public class HoldingContainer
    {
        IHoldingContainer iHoldingContainer;

        public HoldingContainer(IHoldingContainer iHoldingContainer)
        {
            this.iHoldingContainer = iHoldingContainer;
        }

        public List<Holding> GetAllHoldings()
        {
            return iHoldingContainer.GetAllHoldings().Select(x => new Holding(x)).ToList();
        }

        public List<Holding> GetAllHoldingsByAccountID(int AccountID)
        {
            return iHoldingContainer.GetAllHoldingsByAccountID(AccountID).Select(x => new Holding(x)).ToList();
        }

        public Holding GetHolding(int ID)
        {
            return new Holding(iHoldingContainer.GetHolding(ID));
        }

        public void DeleteHolding(int ID)
        {
            iHoldingContainer.DeleteHolding(ID);
        }
    }
}
