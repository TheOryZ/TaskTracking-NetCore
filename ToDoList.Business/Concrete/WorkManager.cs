using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ToDoList.Business.Interfaces;
using ToDoList.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Concrete;

namespace ToDoList.Business.Concrete
{
    public class WorkManager : IWorkService
    {
        private readonly IWorkDAL _workDAL;

        public WorkManager(IWorkDAL workDAL)
        {
            _workDAL = workDAL;
        }
        public void Delete(Work table)
        {
            _workDAL.Delete(table);
        }

        public Work Get(int Id)
        {
            return _workDAL.Get(Id);
        }

        public int GetActiveWorkCount(int id)
        {
            return _workDAL.GetActiveWorkCount(id);
        }

        public List<Work> GetAll()
        {
            return _workDAL.GetAll();
        }

        public int GetAllFinishedWorkCount()
        {
            return _workDAL.GetAllFinishedWorkCount();
        }

        public List<Work> GetAllFinishedWorks()
        {
            return _workDAL.GetAllFinishedWorks();
        }

        public List<Work> GetByAppUserId(int appuserId)
        {
            return _workDAL.GetByAppUserId(appuserId);
        }

        public int GetFinishedWorkCount(int id)
        {
            return _workDAL.GetFinishedWorkCount(id);
        }

        public List<Work> GetUnfinishedWorksWithJoins()
        {
            return _workDAL.GetUnfinishedWorksWithJoins();
        }

        public List<Work> GetUnfinishedWorksWithJoins(Expression<Func<Work, bool>> filter)
        {
            return _workDAL.GetUnfinishedWorksWithJoins(filter);
        }

        public List<Work> GetUnfinishedWorksWithPaging(out int totalPage, int userId, int activePage)
        {
            return _workDAL.GetUnfinishedWorksWithPaging(out totalPage, userId, activePage);
        }

        public List<Work> GetUnfinishedWorksWithUrgency()
        {
            return _workDAL.GetUnfinishedWorksWithUrgency();
        }

        public int GetWaitingTaskCount()
        {
            return _workDAL.GetWaitingTaskCount();
        }

        public Work GetWithUrgencyId(int id)
        {
            return _workDAL.GetWithUrgencyId(id);
        }

        public Work GetWorkWithReports(int id)
        {
            return _workDAL.GetWorkWithReports(id);
        }

        public void Save(Work table)
        {
            _workDAL.Save(table);
        }

        public void Update(Work table)
        {
            _workDAL.Update(table);
        }
    }
}
