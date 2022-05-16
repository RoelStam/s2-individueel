using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace UnitTests.TestDAL
{
    public class TestDALWallet : IWallet, IWalletContainer
    {
        List<DTOWallet> Wallets = new List<DTOWallet>
        {
            new DTOWallet(1, 1.11),
            new DTOWallet(2, 2.22),
            new DTOWallet(3, 3.33),
            new DTOWallet(4, 4.44),
            new DTOWallet(10, 1010.10),
            new DTOWallet(11, 1.00)
        };

        public DTOWallet GetWalletByID(int ID)
        {
            DTOWallet wallet = new DTOWallet();
            foreach(var wallet1 in Wallets)
            {
                if(wallet1.ID == ID)
                {
                    wallet = wallet1;
                }
            }
            return wallet;
        }

        public void AddWallet(DTOWallet dTOWallet)
        {
            Wallets.Add(dTOWallet);
        }

        public void UpdateWallet(DTOWallet dTOWallet)
        {
            foreach (var wallet in Wallets)
            {
                if (wallet.ID == dTOWallet.ID)
                {
                    wallet.Balance = dTOWallet.Balance;
                }
            }
        }
    }
}
