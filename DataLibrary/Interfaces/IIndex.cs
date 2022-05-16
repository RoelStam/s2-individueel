using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IIndex
    {
        void UpdateIndex(DTOIndex dTOIndex);
        void AddIndex(DTOIndex dTOIndex);
    }
}
