using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace UnitTests.TestDAL
{
    public class TestDALHolding : IHolding, IHoldingContainer
    {
        List<DTOHolding> Holdings = new List<DTOHolding>
        {
            new DTOHolding(1, 1, 1, 1, 1.11, 1.11),
            new DTOHolding(2, 2, 2, 2, 2.22, 2.22),
            new DTOHolding(3, 3, 3, 3, 3.33, 3.33),
            new DTOHolding(4, 4, 4, 4, 4.44, 4.44),
            new DTOHolding(10, 10, 10, 10, 10.10, 1.10)
        };

        public List<DTOHolding> GetAllHoldings()
        {
            return Holdings;
        }

        public List<DTOHolding> GetAllHoldingsByAccountID(int AccountID)
        {
            List<DTOHolding> holdings = new List<DTOHolding>();
            foreach(var holding in Holdings)
            {
                if(holding.AccountID == AccountID)
                {
                    holdings.Add(holding);
                }
            }
            return holdings;
        }

        public DTOHolding GetHolding(int ID)
        {
            DTOHolding holding = new DTOHolding();
            foreach(var holding1 in Holdings)
            {
                if(holding1.ID == ID)
                {
                    holding = holding1;
                }
            }
            return holding;
        }

        public void AddHolding(DTOHolding dTOHolding)
        {
            Holdings.Add(dTOHolding);
        }

        public void DeleteHolding(int ID)
        {
            foreach( var holding in Holdings)
            {
                if(holding.ID == ID)
                {
                    Holdings.RemoveAt(Holdings.IndexOf(holding));
                    return;
                }
            }
        }

        public void UpdateHolding(DTOHolding dTOHolding)
        {
            foreach(var holding in Holdings)
            {
                if(holding.ID == dTOHolding.ID)
                {
                    holding.StockID = dTOHolding.StockID;
                    holding.AccountID = dTOHolding.AccountID;
                    holding.TotalShares = dTOHolding.TotalShares;
                    holding.TotalWorth = dTOHolding.TotalWorth;
                    holding.AvaragePrice = dTOHolding.AvaragePrice;
                }
            }
        }
    }
}
