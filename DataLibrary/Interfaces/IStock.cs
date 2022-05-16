using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IStock
    {
        public void UpdateStock(DTOStock dTOStock);
        public void AddStock(DTOStock dTOStock);
    }
}
