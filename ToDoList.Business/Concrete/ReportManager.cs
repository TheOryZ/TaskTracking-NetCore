using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Business.Interfaces;
using ToDoList.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Concrete;

namespace ToDoList.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDAL _reportDAL;
        public ReportManager(IReportDAL reportDAL)
        {
            _reportDAL = reportDAL;
        }

        public void Delete(Report table)
        {
            _reportDAL.Delete(table);
        }

        public Report Get(int Id)
        {
            return _reportDAL.Get(Id);
        }

        public List<Report> GetAll()
        {
            return _reportDAL.GetAll();
        }

        public int GetAllReportCount()
        {
            return _reportDAL.GetAllReportCount();
        }

        public int GetReportCount(int id)
        {
            return _reportDAL.GetReportCount(id);
        }

        public Report GetReportWithWorkById(int id)
        {
            return _reportDAL.GetReportWithWorkById(id);
        }

        public void Save(Report table)
        {
            _reportDAL.Save(table);
        }

        public void Update(Report table)
        {
            _reportDAL.Update(table);
        }
    }
}
