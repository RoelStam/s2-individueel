using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IIndexContainer
    {
        List<DTOIndex> GetAllIndices();
        void DeleteIndex(int ID);
        DTOIndex GetIndexByID(int ID);
    }
}
