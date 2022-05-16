using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace UnitTests.TestDAL
{
    public class TestDALWatchlist : IWatchlist, IWatchlistContainer
    {
        List<DTOWatchlist> Watchlists = new List<DTOWatchlist>
        {
            new DTOWatchlist(1, 1, 1),
            new DTOWatchlist(2, 2, 2),
            new DTOWatchlist(3, 3, 3),
            new DTOWatchlist(4, 4, 4)
        };

        public List<DTOWatchlist> GetWatchlistByAccountID(int AccountID)
        {
            List<DTOWatchlist> watchlists = new List<DTOWatchlist>();
            foreach(var watchlist in Watchlists)
            {
                if(watchlist.AccountID == AccountID)
                {
                    watchlists.Add(watchlist);
                }
            }
            return watchlists;
        }

        public DTOWatchlist GetWatchlist(int accountID, int StockID)
        {
            DTOWatchlist watchlist = null;
            foreach (var watchlist1 in Watchlists)
            {
                if (watchlist1.AccountID == accountID && watchlist1.StockID == StockID)
                {
                    watchlist = watchlist1;
                }
            }
            return watchlist;
        }

        public void AddWatchList(DTOWatchlist dTOWatchlist)
        {
            Watchlists.Add(dTOWatchlist);
        }

        public void DeleteWatchlist(int ID)
        {
            foreach (var watchlist in Watchlists)
            {
                if (watchlist.ID == ID)
                {
                    Watchlists.RemoveAt(Watchlists.IndexOf(watchlist));
                    return;
                }
            }
        }
    }
}
