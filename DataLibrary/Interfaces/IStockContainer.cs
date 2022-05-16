using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IStockContainer
    {
        List<DTOStock> GetAllStocks();
        List<DTOStock> SearchStocks(int filter, string searchterm);
        DTOStock GetStockByID(int ID);
        void DeleteStock(int ID);
    }
}
