using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using System.Data.SqlClient;

namespace DataLibrary.DALs
{
    public class DALStock : IStock, IStockContainer
    {
        private string ConnString { get; }
        public DALStock(string ConnString)
        {
            this.ConnString = ConnString;
        }

        public List<DTOStock> GetAllStocks()
        {
            List<DTOStock> Stocks = new List<DTOStock>();
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                "Select * from Stocks Order by Name",
                connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Stocks.Add(new DTOStock(Convert.ToInt32(reader["ID"].ToString()),
                                                    Convert.ToInt32(reader["IndexID"].ToString()), 
                                                    reader["Name"].ToString(), 
                                                    reader["Symbol"].ToString(), 
                                                    Convert.ToDouble(reader["Price"].ToString()), 
                                                    Convert.ToDouble(reader["Change"].ToString())
                                                    ));
                        }
                    }
                }
            }
            return Stocks;
        }

        public DTOStock GetStockByID(int ID)
        {
            DTOStock stock = new DTOStock();
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "Select * from Stocks where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", ID);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        stock = new DTOStock(Convert.ToInt32(reader["ID"].ToString()), 
                                             Convert.ToInt32(reader["IndexID"].ToString()), 
                                             reader["Name"].ToString(), 
                                             reader["Symbol"].ToString(), 
                                             Convert.ToDouble(reader["Price"].ToString()), 
                                             Convert.ToDouble(reader["Change"].ToString())
                                             );
                    }
                }
            }
            return stock;
        }

        public void AddStock(DTOStock dTOStock)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "insert into Stocks (IndexID, Name, Symbol, Price, Change) values(@IndexID, @Name, @Symbol, @Price, @Change)",
                connection);
                command.Parameters.AddWithValue("@IndexID", dTOStock.IndexID);
                command.Parameters.AddWithValue("@Name", dTOStock.Name);
                command.Parameters.AddWithValue("@Symbol", dTOStock.Symbol);
                command.Parameters.AddWithValue("@Price", dTOStock.Price);
                command.Parameters.AddWithValue("@Change", dTOStock.Change);
                command.ExecuteScalar();
            }
        }

        public void DeleteStock(int ID)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "delete from Stocks where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteScalar();
            }
        }

        public void UpdateStock(DTOStock dTOStock)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "Update Stocks set IndexID=@IndexID, Name=@Name, Symbol=@Symbol, Price=@Price, Change=@Change where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", dTOStock.ID);
                command.Parameters.AddWithValue("@IndexID", dTOStock.IndexID);
                command.Parameters.AddWithValue("@Name", dTOStock.Name);
                command.Parameters.AddWithValue("@Symbol", dTOStock.Symbol);
                command.Parameters.AddWithValue("@Price", dTOStock.Price);
                command.Parameters.AddWithValue("@Change", dTOStock.Change);
                command.ExecuteScalar();
            }
        }

        public List<DTOStock> SearchStocks(int filter, string searchterm)
        {
            List<DTOStock> Stocks = new List<DTOStock>();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                string query = "Select * from Stocks as S, [dbo].[Index] as I where I.ID = S.IndexID";

                if(filter != 0)
                {
                    query += " and I.ID=@Filter";
                }
                if(searchterm != null)
                {
                    query += " and S.Name like @SearchTerm";
                }
                /*
                else if(filter != null && searchterm != null)
                {
                    query += " and I.Name=@Filter and S.Name like @SearchTerm";
                }*/

                query += " order by S.Name";

                using (SqlCommand command = new SqlCommand(
                query,
                connection))
                {
                    if(filter != 0)
                    {
                        command.Parameters.AddWithValue("@Filter", filter);
                    }
                    if(searchterm != null)
                    {
                        command.Parameters.AddWithValue("@SearchTerm", '%' + searchterm + '%');
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Stocks.Add(new DTOStock(Convert.ToInt32(reader["ID"].ToString()),
                                                    Convert.ToInt32(reader["IndexID"].ToString()),
                                                    reader["Name"].ToString(),
                                                    reader["Symbol"].ToString(),
                                                    Convert.ToDouble(reader["Price"].ToString()),
                                                    Convert.ToDouble(reader["Change"].ToString())
                                                    ));
                        }
                    }
                }
            }
            return Stocks;
        }
    }
}
