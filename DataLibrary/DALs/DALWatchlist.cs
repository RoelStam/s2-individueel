using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using System.Data.SqlClient;

namespace DataLibrary.DALs
{
    public class DALWatchlist : IWatchlist, IWatchlistContainer
    {
        private string ConnString { get; set; }
        public DALWatchlist(string ConnString)
        {
            this.ConnString = ConnString;
        }

        public List<DTOWatchlist> GetWatchlistByAccountID(int AccountID)
        {
            List<DTOWatchlist> watchlist = new List<DTOWatchlist>();
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "Select * from Watchlist where AccountID=@AccountID",
                connection);
                command.Parameters.AddWithValue("@AccountID", AccountID);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        watchlist.Add(new DTOWatchlist(Convert.ToInt32(reader["ID"].ToString()),
                                                       Convert.ToInt32(reader["AccountID"].ToString()),
                                                       Convert.ToInt32(reader["StockID"].ToString())
                                                       ));
                    }
                }
            }
            return watchlist;
        }

        public DTOWatchlist GetWatchlist(int accountID, int StockID)
        {
            DTOWatchlist watchlist = new DTOWatchlist();
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "select * from Watchlist where AccountID=@AccountID and StockID=@StockID",
                connection);
                command.Parameters.AddWithValue("@AccountID", accountID);
                command.Parameters.AddWithValue("@StockID", StockID);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        watchlist = new DTOWatchlist(Convert.ToInt32(reader["ID"].ToString()),
                                                Convert.ToInt32(reader["AccountID"].ToString()),
                                                Convert.ToInt32(reader["StockID"].ToString())
                                                );
                    }
                }
            }
            return watchlist;
        }

        public void DeleteWatchlist(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "delete from Watchlist where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteScalar();
            }
        }

        public void AddWatchList(DTOWatchlist dTOWatchlist)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "insert into Watchlist (AccountID, StockID) values(@AccountID, @StockID)",
                connection);
                command.Parameters.AddWithValue("@AccountID", dTOWatchlist.AccountID);
                command.Parameters.AddWithValue("@StockID", dTOWatchlist.StockID);
                command.ExecuteScalar();
            }
        }
    }
}
