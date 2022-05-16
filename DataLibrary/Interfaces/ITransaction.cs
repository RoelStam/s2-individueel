using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface ITransaction
    {
        public void AddTransaction(DTOTransaction dTOTransaction);
    }
}
