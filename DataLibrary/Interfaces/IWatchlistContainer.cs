using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IWatchlistContainer
    {
        List<DTOWatchlist> GetWatchlistByAccountID(int AccountID);
        DTOWatchlist GetWatchlist(int accountID, int StockID);
        void DeleteWatchlist(int ID);
    }
}
