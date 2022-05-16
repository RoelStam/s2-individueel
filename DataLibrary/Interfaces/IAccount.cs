using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IAccount
    {
        void UpdateAccount(DTOAccount dTOAccount);
        void AddAccount(DTOAccount dTOAccount);
    }
}
