using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDAL
    {
        public object TodoContext { get; private set; }

        public int GetAllReportCount()
        {
            using var context = new ToDoContext();
            return context.Reports.Count();
        }

        public int GetReportCount(int id)
        {
            using var context = new ToDoContext();
            var result = context.Works.Include(I => I.Reports).Where(I => I.AppUserId == id);

            return result.SelectMany(I => I.Reports).Count();
        }

        public Report GetReportWithWorkById(int id)
        {
            using var context = new ToDoContext();
            return context.Reports.Include(I => I.Work).ThenInclude(I=> I.Urgency).Where(I => I.Id == id).FirstOrDefault();
        }
    }
}
