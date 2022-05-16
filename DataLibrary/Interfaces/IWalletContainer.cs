using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IWalletContainer
    {
        DTOWallet GetWalletByID(int ID);
    }
}
