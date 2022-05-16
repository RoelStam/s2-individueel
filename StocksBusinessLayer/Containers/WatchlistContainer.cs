using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataLibrary.Interfaces;
using StocksBusinessLayer.Models;

namespace StocksBusinessLayer.Containers
{
    public class WatchlistContainer
    {
        IWatchlistContainer iWatchlistContainer;

        public WatchlistContainer(IWatchlistContainer iWatchlistContainer)
        {
            this.iWatchlistContainer = iWatchlistContainer;
        }

        public List<Watchlist> GetWatchlistsByAccountID(int AccountID)
        {
            return iWatchlistContainer.GetWatchlistByAccountID(AccountID).Select(x => new Watchlist(x)).ToList();
        }

        public Watchlist GetWatchlist(int AccountID, int StockID)
        {
            if(iWatchlistContainer.GetWatchlist(AccountID, StockID) == null)
            {
                return null;
            }
            else
            {
                return new Watchlist(iWatchlistContainer.GetWatchlist(AccountID, StockID));
            }
        }

        public void DeleteWatchlist(int ID)
        {
            iWatchlistContainer.DeleteWatchlist(ID);
        }
    }
}
