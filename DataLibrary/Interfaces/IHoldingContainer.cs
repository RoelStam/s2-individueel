using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IHoldingContainer
    {
        List<DTOHolding> GetAllHoldings();
        List<DTOHolding> GetAllHoldingsByAccountID(int AccountID);
        DTOHolding GetHolding(int ID);
        void DeleteHolding(int ID);
    }
}
