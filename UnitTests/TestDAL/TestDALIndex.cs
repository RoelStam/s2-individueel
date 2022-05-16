using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;
using DataLibrary.Interfaces;

namespace UnitTests.TestDAL
{
    public class TestDALIndex : IIndex, IIndexContainer
    {

        List<DTOIndex> Indices = new List<DTOIndex>
        {
            new DTOIndex(1, "Index1", "Index1", 1.11, 1.11),
            new DTOIndex(2, "Index2", "Index2", 2.22, 2.22),
            new DTOIndex(3, "Index3", "Index3", 3.33, 3.33),
            new DTOIndex(4, "Index4", "Index4", 4.44, 4.44)
        };

        public List<DTOIndex> GetAllIndices()
        {
            return Indices;
        }

        public DTOIndex GetIndexByID(int ID)
        {
            DTOIndex index = new DTOIndex();
            foreach(var index1 in Indices)
            {
                if(index1.ID == ID)
                {
                    index = index1;
                }
            }
            return index;
        }

        public void DeleteIndex(int ID)
        {
            foreach (var index in Indices)
            {
                if (index.ID == ID)
                {
                    Indices.RemoveAt(Indices.IndexOf(index));
                    return;
                }
            }
        }

        void IIndex.UpdateIndex(DTOIndex dTOIndex)
        {
            foreach (var index in Indices)
            {
                if (index.ID == dTOIndex.ID)
                {
                    index.Name = dTOIndex.Name;
                    index.Symbol = dTOIndex.Symbol;
                    index.Price = dTOIndex.Price;
                    index.Change = dTOIndex.Change;
                }
            }
        }

        void IIndex.AddIndex(DTOIndex dTOIndex)
        {
            Indices.Add(dTOIndex);
        }
    }
}
