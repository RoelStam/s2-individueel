using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using System.Data.SqlClient;

namespace DataLibrary.DALs
{
    public class DALIndex : IIndex, IIndexContainer
    {
        private string ConnString { get; }
        public DALIndex(string ConnString)
        {
            this.ConnString = ConnString;
        }

        public List<DTOIndex> GetAllIndices()
        {
            List<DTOIndex> Indices = new List<DTOIndex>();
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                "Select * from [dbo].[Index]",
                connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Indices.Add(new DTOIndex(Convert.ToInt32(reader["ID"].ToString()), 
                                                     reader["Name"].ToString(), 
                                                     reader["Symbol"].ToString(), 
                                                     Convert.ToDouble(reader["Price"].ToString()), 
                                                     Convert.ToDouble(reader["Change"].ToString())
                                                     ));
                        }
                    }
                }
            }
            return Indices;
        }

        public DTOIndex GetIndexByID(int ID)
        {
            DTOIndex dTOIndex = new DTOIndex();
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "Select * from [dbo].[Index] where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", ID);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        dTOIndex = new DTOIndex(Convert.ToInt32(reader["ID"].ToString()), 
                                                reader["Name"].ToString(), reader["Symbol"].ToString(), 
                                                Convert.ToDouble(reader["Price"].ToString()), 
                                                Convert.ToDouble(reader["Change"].ToString())
                                                );
                    }
                }
            }
            return dTOIndex;
        }

        public void AddIndex(DTOIndex dTOIndex)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "Insert into [dbo].[Index](Name, Symbol, Price, Change) values(@Name, @Symbol, @Price, @Change)",
                connection);
                command.Parameters.AddWithValue("@Name", dTOIndex.Name);
                command.Parameters.AddWithValue("@Symbol", dTOIndex.Symbol);
                command.Parameters.AddWithValue("@Price", dTOIndex.Price);
                command.Parameters.AddWithValue("@Change", dTOIndex.Change);
                command.ExecuteScalar();
            }
        }

        public void DeleteIndex(int ID)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "delete from [dbo].[Index] where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteScalar();
            }
        }

        public void UpdateIndex(DTOIndex dTOIndex)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "update [dbo].[Index] set Name=@Name, Symbol=@Symbol, Price=@Price, Change=@Change where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", dTOIndex.ID);
                command.Parameters.AddWithValue("@Name", dTOIndex.Name);
                command.Parameters.AddWithValue("@Symbol", dTOIndex.Symbol);
                command.Parameters.AddWithValue("@Price", dTOIndex.Price);
                command.Parameters.AddWithValue("@Change", dTOIndex.Change);
                command.ExecuteScalar();
            }
        }
    }
}
