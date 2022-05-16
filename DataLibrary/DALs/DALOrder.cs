using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using System.Data.SqlClient;

namespace DataLibrary.DALs
{
    public class DALOrder : IOrder, IOrderContainer
    {
        private string ConnString { get; }
        public DALOrder(string ConnString)
        {
            this.ConnString = ConnString;
        }

        public List<DTOOrder> GetAllOrders()
        {
            List<DTOOrder> Orders = new List<DTOOrder>();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                "Select * from Orders order by ID",
                connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Orders.Add(new DTOOrder(Convert.ToInt32(reader["ID"].ToString()), 
                                                    Convert.ToInt32(reader["StockID"].ToString()), 
                                                    Convert.ToInt32(reader["AccountID"].ToString()),
                                                    Convert.ToInt32(reader["Shares"].ToString()), 
                                                    Convert.ToDouble(reader["Limit"].ToString()),
                                                    reader["Type"].ToString(),
                                                    Convert.ToDouble(reader["TotalPrice"].ToString()),
                                                    Convert.ToBoolean(reader["Completed"].ToString())
                                                    ));
                        }
                    }
                }
            }
            return Orders;
        }

        public List<DTOOrder> GetAllOrdersByAccountID(int AccountID)
        {
            try
            {
                List<DTOOrder> Orders = new List<DTOOrder>();
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE AccountID=@AccountID", connection);
                    command.Parameters.AddWithValue("@AccountID", AccountID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Orders.Add(new DTOOrder(Convert.ToInt32(reader["ID"].ToString()),
                                                    Convert.ToInt32(reader["StockID"].ToString()),
                                                    Convert.ToInt32(reader["AccountID"].ToString()),
                                                    Convert.ToInt32(reader["Shares"].ToString()),
                                                    Convert.ToDouble(reader["Limit"].ToString()),
                                                    reader["Type"].ToString(),
                                                    Convert.ToDouble(reader["TotalPrice"].ToString()),
                                                    Convert.ToBoolean(reader["Completed"].ToString())
                                                    ));
                        }
                    }
                }
                return Orders;
            }
            catch(SqlException sqlerror)
            {
                throw sqlerror;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public DTOOrder GetOrderByID(int ID)
        {
            try
            {
                DTOOrder dTOOrder = new DTOOrder();
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE ID=@ID", connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dTOOrder = new DTOOrder(Convert.ToInt32(reader["ID"].ToString()),
                                                    Convert.ToInt32(reader["StockID"].ToString()),
                                                    Convert.ToInt32(reader["AccountID"].ToString()),
                                                    Convert.ToInt32(reader["Shares"].ToString()),
                                                    Convert.ToDouble(reader["Limit"].ToString()),
                                                    reader["Type"].ToString(),
                                                    Convert.ToDouble(reader["TotalPrice"].ToString()),
                                                    Convert.ToBoolean(reader["Completed"].ToString())
                                                    );
                        }
                    }
                }
                return dTOOrder;
            }
            catch (SqlException sqlerror)
            {
                throw sqlerror;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void DeleteOrder(int ID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("delete from Orders where ID=@ID", connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    command.ExecuteScalar();
                }
            }
            catch (SqlException sqlerror)
            {
                throw sqlerror;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void UpdateOrder(DTOOrder dTOOrder)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE Orders SET StockID=@StockID, AccountID=@AccountID, Shares=@Shares, Limit=@Limit, Type=@Type, TotalPrice=@TotalPrice, Completed=@Completed WHERE ID=@ID", connection);
                    command.Parameters.AddWithValue("@ID", dTOOrder.ID);
                    command.Parameters.AddWithValue("@StockID", dTOOrder.StockID);
                    command.Parameters.AddWithValue("@AccountID", dTOOrder.AccountID);
                    command.Parameters.AddWithValue("@Shares", dTOOrder.Shares);
                    command.Parameters.AddWithValue("@Limit", dTOOrder.Limit);
                    command.Parameters.AddWithValue("@Type", dTOOrder.Type);
                    command.Parameters.AddWithValue("@TotalPrice", dTOOrder.TotalPrice);
                    command.Parameters.AddWithValue("@Completed", dTOOrder.Completed);
                    command.ExecuteScalar();
                }
            }
            catch (SqlException sqlerror)
            {
                throw sqlerror;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void AddOrder(DTOOrder dTOOrder)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                    "insert into Orders (StockID, AccountID, Shares, Limit, Type, TotalPrice, Completed) values(@StockID, @AccountID, @Shares, @Limit, @Type, @TotalPrice, @Completed)",
                    connection);
                    command.Parameters.AddWithValue("@StockID", dTOOrder.StockID);
                    command.Parameters.AddWithValue("@AccountID", dTOOrder.AccountID);
                    command.Parameters.AddWithValue("@Shares", dTOOrder.Shares);
                    command.Parameters.AddWithValue("@Limit", dTOOrder.Limit);
                    command.Parameters.AddWithValue("@Type", dTOOrder.Type);
                    command.Parameters.AddWithValue("@TotalPrice", dTOOrder.TotalPrice);
                    command.Parameters.AddWithValue("@Completed", dTOOrder.Completed);
                    command.ExecuteScalar();
                }
            }
            catch (SqlException sqlerror)
            {
                throw sqlerror;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
