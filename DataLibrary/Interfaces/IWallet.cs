using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IWallet
    {
        public void UpdateWallet(DTOWallet dTOWallet);
        public void AddWallet(DTOWallet dTOWallet);
    }
}
