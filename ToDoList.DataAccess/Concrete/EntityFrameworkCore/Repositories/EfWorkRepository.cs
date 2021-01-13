using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToDoList.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : EfGenericRepository<Work>, IWorkDAL
    {
        public int GetActiveWorkCount(int id)
        {
            using var context = new ToDoContext();
            return context.Works.Count(I => I.AppUserId == id && !I.Status);
        }

        public int GetAllFinishedWorkCount()
        {
            using var context = new ToDoContext();
            return context.Works.Count(I => I.Status);
        }

        public List<Work> GetAllFinishedWorks()
        {
            using var context = new ToDoContext();
            return context.Works.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser).Where(I=> I.Status && I.AppUserId != null).OrderByDescending(I => I.CreatedDate).ToList();
        }

        public List<Work> GetByAppUserId(int appuserId)
        {
            using var context = new ToDoContext();
            return context.Works.Where(I => I.AppUserId == appuserId).ToList();
        }

        public int GetFinishedWorkCount(int id)
        {
            using var context = new ToDoContext();
            return context.Works.Count(I => I.AppUserId == id && I.Status);
        }

        public List<Work> GetUnfinishedWorksWithJoins()
        {
            using var context = new ToDoContext();
            return context.Works.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser).Where(I => !I.Status).OrderByDescending(I => I.CreatedDate).ToList();
        }

        public List<Work> GetUnfinishedWorksWithJoins(Expression<Func<Work, bool>> filter)
        {
            using var context = new ToDoContext();
            return context.Works.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser).Where(filter).OrderByDescending(I => I.CreatedDate).ToList();
        }

        public List<Work> GetUnfinishedWorksWithPaging(out int totalPage, int userId, int activePage = 1)
        {
            using var context = new ToDoContext();
            var returnValue = context.Works.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser).Where(I => I.AppUserId == userId && I.Status)
                .OrderByDescending(I => I.CreatedDate);
            totalPage = (int)Math.Ceiling((double)returnValue.Count() / 3);

            return returnValue.Skip((activePage - 1) * 3).Take(3).ToList();
        }

        public List<Work> GetUnfinishedWorksWithUrgency()
        {
            using var context = new ToDoContext();
            return context.Works.Include(I => I.Urgency).Where(I => !I.Status).OrderByDescending(I => I.CreatedDate).ToList();
        }

        public int GetWaitingTaskCount()
        {
            using var context = new ToDoContext();
            return context.Works.Count(I => I.AppUserId == null && !I.Status);
        }

        public Work GetWithUrgencyId(int id)
        {
            using var context = new ToDoContext();
            return context.Works.Include(I => I.Urgency).FirstOrDefault(I => !I.Status && I.Id == id);
        }

        public Work GetWorkWithReports(int id)
        {
            using var context = new ToDoContext();
            return context.Works.Include(I => I.Reports).Include(I=> I.AppUser).Where(I => I.Id == id).FirstOrDefault();
        }
    }
}
