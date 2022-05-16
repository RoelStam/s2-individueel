using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DTOs
{
    public class DTOWallet
    {
        public int ID { get; set; }
        public double Balance { get; set; }

        public DTOWallet(int ID, double Balance)
        {
            this.ID = ID;
            this.Balance = Balance;
        }

        public DTOWallet(double Balance)
        {
            this.Balance = Balance;
        }

        public DTOWallet() { }
    }
}
