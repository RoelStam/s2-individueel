using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using System.Data.SqlClient;

namespace DataLibrary.DALs
{
    public class DALAccount : IAccount, IAccountContainer
    {
        private string ConnString { get; }
        public DALAccount(string ConnString)
        {
            this.ConnString = ConnString;
        }

        public List<DTOAccount> GetAllAccounts()
        {
            List<DTOAccount> Accounts = new List<DTOAccount>();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                "Select * from Accounts order by ID",
                connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Accounts.Add(new DTOAccount(Convert.ToInt32(reader["ID"].ToString()), 
                                                        reader["Username"].ToString(), 
                                                        reader["EmailAddress"].ToString(), 
                                                        reader["Password"].ToString(), 
                                                        Convert.ToInt32(reader["WalletID"].ToString())
                                                        ));
                        }
                    }
                }
            }
            return Accounts;
        }

        public DTOAccount GetAccountById(int ID)
        {
            DTOAccount dTOAccount = new DTOAccount();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Accounts WHERE ID=@ID", connection);
                command.Parameters.AddWithValue("@ID", ID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dTOAccount = new DTOAccount(Convert.ToInt32(reader["ID"].ToString()), 
                                                    reader["Username"].ToString(), 
                                                    reader["EmailAddress"].ToString(), 
                                                    reader["Password"].ToString(), 
                                                    Convert.ToInt32(reader["WalletID"].ToString())
                                                    );
                    }
                }
            }
            return dTOAccount;
        }

        public void DeleteAccount(int ID)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete from Accounts where ID=@ID", connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.ExecuteScalar();
            }
        }

        public void UpdateAccount(DTOAccount dTOAccount)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Accounts SET Username=@Username, EmailAddress=@EmailAddress, Password=@Password, WalletID=@WalletID WHERE ID=@ID", connection);
                command.Parameters.AddWithValue("@ID", dTOAccount.ID);
                command.Parameters.AddWithValue("@Username", dTOAccount.Username);
                command.Parameters.AddWithValue("@EmailAddress", dTOAccount.EmailAddress);
                command.Parameters.AddWithValue("@Password", dTOAccount.Password);
                command.Parameters.AddWithValue("@WalletID", dTOAccount.WalletID);
                command.ExecuteScalar();
            }
        }

        public void AddAccount(DTOAccount dTOAccount)
        {
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into Accounts (Username, EmailAddress, Password) values(@Username, @EmailAddress, @Password, @WalletID)", connection);
                command.Parameters.AddWithValue("@Username", dTOAccount.Username);
                command.Parameters.AddWithValue("@EmailAddress", dTOAccount.EmailAddress);
                command.Parameters.AddWithValue("@Password", dTOAccount.Password);
                command.Parameters.AddWithValue("@WalletID", dTOAccount.WalletID);
                command.ExecuteScalar();
            }
        }
    }
}
