using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;
using System.Data.SqlClient;

namespace DataLibrary.DALs
{
    public class DALWallet : IWallet, IWalletContainer
    {
        private string ConnString { get; }
        public DALWallet(string ConnString)
        {
            this.ConnString = ConnString;
        }

        public void UpdateWallet(DTOWallet dTOWallet)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "Update Wallet set Balance=@Balance where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", dTOWallet.ID);
                command.Parameters.AddWithValue("@Balance", dTOWallet.Balance);
                command.ExecuteScalar();
            }
        }

        public void AddWallet(DTOWallet dTOWallet)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "insert into Wallet (Balance) values(@Balance)",
                connection);
                command.Parameters.AddWithValue("@Balance", dTOWallet.Balance);
                command.ExecuteScalar();
            }
        }

        public DTOWallet GetWalletByID(int ID)
        {
            DTOWallet wallet = new DTOWallet();
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "select * from Wallet where ID=@ID",
                connection);
                command.Parameters.AddWithValue("@ID", ID);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        wallet.ID = Convert.ToInt32(reader["ID"]);
                        wallet.Balance = Convert.ToDouble(reader["Balance"]);
                    }
                }
            }
            return wallet;
        }
    }
}
