using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IOrder
    {
        void UpdateOrder(DTOOrder dTOOrder);
        void AddOrder(DTOOrder dTOOrder);
    }
}
