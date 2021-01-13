using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Concrete;

namespace ToDoList.Business.Interfaces
{
    public interface IReportService : IGenericService<Report>
    {
        Report GetReportWithWorkById(int id);
        int GetReportCount(int id);
        int GetAllReportCount();
    }
}
