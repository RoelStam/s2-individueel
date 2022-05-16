using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IHolding
    {
        void AddHolding(DTOHolding dTOHolding);
        void UpdateHolding(DTOHolding dTOHolding);
    }
}
