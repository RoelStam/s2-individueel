using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using System.Data.SqlClient;

namespace DataLibrary.DALs
{
    public class DALTransaction : ITransaction, ITransactionContainer
    {
        string ConnString { get; set; }
        public DALTransaction(string ConnString)
        {
            this.ConnString = ConnString;
        }

        public List<DTOTransaction> GetAllTransactions()
        {
            List<DTOTransaction> transactions = new List<DTOTransaction>();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                "select * from Transactions order by DateTransacted Desc",
                connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            transactions.Add(new DTOTransaction(Convert.ToInt32(reader["ID"].ToString()),
                                                                Convert.ToInt32(reader["OrderID"].ToString()),
                                                                Convert.ToDateTime(reader["DateTransacted"].ToString())
                                                                ));
                        }
                    }
                }
            }
            return transactions;
        }

        public List<DTOTransaction> GetAllTransactionsByAccountID(int AccountID)
        {
            List<DTOTransaction> transactions = new List<DTOTransaction>();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "select * from Transactions where AccountID=@AccountID order by DateTransacted Desc",
                connection);
                command.Parameters.AddWithValue("@AccountID", AccountID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        transactions.Add(new DTOTransaction(Convert.ToInt32(reader["ID"].ToString()),
                                                            Convert.ToInt32(reader["AccountID"].ToString()),
                                                            Convert.ToInt32(reader["OrderID"].ToString()),
                                                            Convert.ToDateTime(reader["DateTransacted"].ToString())
                                                            ));
                    }
                }
            }
            return transactions;
        }

        public DTOTransaction GetTransaction(int ID)
        {
            DTOTransaction transaction = new DTOTransaction();
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "select * from Transactions where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", ID);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transaction.ID = Convert.ToInt32(reader["ID"].ToString());
                        transaction.AccountID = Convert.ToInt32(reader["AccountID"].ToString());
                        transaction.OrderID = Convert.ToInt32(reader["OrderID"].ToString());
                        transaction.DateTransacted = Convert.ToDateTime(reader["DateTransacted"].ToString());
                    }
                }
            }
            return transaction;
        }

        public void AddTransaction(DTOTransaction dTOTransaction)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "insert into Transactions(OrderID, DateTransacted, AccountID) values(@OrderID, @DateTransacted, @AccountID)", 
                connection);
                command.Parameters.AddWithValue("@OrderID", dTOTransaction.OrderID);
                command.Parameters.AddWithValue("@DateTransacted", dTOTransaction.DateTransacted);
                command.Parameters.AddWithValue("@AccountID", dTOTransaction.AccountID);
                command.ExecuteScalar();
            }
        }
    }
}
