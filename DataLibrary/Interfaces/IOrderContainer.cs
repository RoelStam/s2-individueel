using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DTOs;

namespace DataLibrary.Interfaces
{
    public interface IOrderContainer
    {
        List<DTOOrder> GetAllOrders();
        List<DTOOrder> GetAllOrdersByAccountID(int AccountID);
        DTOOrder GetOrderByID(int ID);
        void DeleteOrder(int ID);
    }
}
