using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Interfaces
{
    public interface IReportDAL : IGenericDAL<Report>
    {
        Report GetReportWithWorkById(int id);
        int GetReportCount(int id);
        int GetAllReportCount();
    }
}
