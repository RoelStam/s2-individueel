using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace UnitTests.TestDAL
{
    public class TestDALOrderClassHelp
    {
        DTOOrder Order = new DTOOrder
        {
            ID = 1,
            StockID = 1,
            AccountID = 1,
            Shares = 1,
            Limit = 1.11,
            Type = "Order1",
            TotalPrice = 1.11,
            Completed = true
        };
    }
}
