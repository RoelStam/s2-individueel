using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using System.Data.SqlClient;

namespace DataLibrary.DALs
{
    public class DALHolding : IHolding, IHoldingContainer
    {
        string ConnString { get; set; }
        public DALHolding(string ConnString)
        {
            this.ConnString = ConnString;
        }

        public List<DTOHolding> GetAllHoldings()
        {
            List<DTOHolding> holdings = new List<DTOHolding>();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                "select * from Holdings",
                connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            holdings.Add(new DTOHolding(Convert.ToInt32(reader["ID"].ToString()),
                                                        Convert.ToInt32(reader["StockID"].ToString()),
                                                        Convert.ToInt32(reader["AccountID"].ToString()),
                                                        Convert.ToInt32(reader["TotalShares"].ToString()),
                                                        Convert.ToDouble(reader["TotalWorth"].ToString()),
                                                        Convert.ToDouble(reader["AvaragePrice"].ToString())
                                                        ));
                        }
                    }
                }
            }
            return holdings;
        }

        public List<DTOHolding> GetAllHoldingsByAccountID(int AccountID)
        {
            List<DTOHolding> holdings = new List<DTOHolding>();
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "select * from Holdings where AccountID=@AccountID",
                connection);
                command.Parameters.AddWithValue("@AccountID", AccountID);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        holdings.Add(new DTOHolding(Convert.ToInt32(reader["ID"].ToString()),
                                                    Convert.ToInt32(reader["StockID"].ToString()),
                                                    Convert.ToInt32(reader["AccountID"].ToString()),
                                                    Convert.ToInt32(reader["TotalShares"].ToString()),
                                                    Convert.ToDouble(reader["TotalWorth"].ToString()),
                                                    Convert.ToDouble(reader["AvaragePrice"].ToString())
                                                    ));
                    }
                }
            }
            return holdings;
        }

        public DTOHolding GetHolding(int ID)
        {
            DTOHolding holding = new DTOHolding();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                SqlCommand command = new SqlCommand(
                "select * from Holdings where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        holding = new DTOHolding(Convert.ToInt32(reader["ID"].ToString()),
                                                    Convert.ToInt32(reader["StockID"].ToString()),
                                                    Convert.ToInt32(reader["AccountID"].ToString()),
                                                    Convert.ToInt32(reader["TotalShares"].ToString()),
                                                    Convert.ToDouble(reader["TotalWorth"].ToString()),
                                                    Convert.ToDouble(reader["AvaragePrice"].ToString())
                                                    );
                    }
                }
            }
            return holding;
        }

        public void AddHolding(DTOHolding dTOHolding)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "insert into Holdings(StockID, AccountID, TotalShares, TotalWorth, AvaragePrice) values(@StockID, @AccountID, @TotalShares, @TotalWorth, @AvaragePrice)",
                connection);
                command.Parameters.AddWithValue("@StockID", dTOHolding.StockID);
                command.Parameters.AddWithValue("@AccountID", dTOHolding.AccountID);
                command.Parameters.AddWithValue("@TotalShares", dTOHolding.TotalShares);
                command.Parameters.AddWithValue("@TotalWorth", dTOHolding.TotalWorth);
                command.Parameters.AddWithValue("@AvaragePrice", dTOHolding.AvaragePrice);
                command.ExecuteScalar();
            }
        }

        public void UpdateHolding(DTOHolding dTOHolding)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "update Holdings set StockID=@StockID, AccountID=@AccountID, TotalShares=@TotalShares, TotalWorth=@TotalWorth, AvaragePrice=@AvaragePrice where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", dTOHolding.ID);
                command.Parameters.AddWithValue("@StockID", dTOHolding.StockID);
                command.Parameters.AddWithValue("@AccountID", dTOHolding.AccountID);
                command.Parameters.AddWithValue("@TotalShares", dTOHolding.TotalShares);
                command.Parameters.AddWithValue("@TotalWorth", dTOHolding.TotalWorth);
                command.Parameters.AddWithValue("@AvaragePrice", dTOHolding.AvaragePrice);
                command.ExecuteScalar();
            }
        }

        public void DeleteHolding(int ID)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "delete from Holdings where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteScalar();
            }
        }
    }
}
