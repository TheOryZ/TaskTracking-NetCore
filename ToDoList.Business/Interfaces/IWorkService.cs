using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ToDoList.Entities.Concrete;

namespace ToDoList.Business.Interfaces
{
    public interface IWorkService : IGenericService<Work>
    {
        List<Work> GetUnfinishedWorksWithUrgency();
        List<Work> GetUnfinishedWorksWithJoins();
        List<Work> GetUnfinishedWorksWithJoins(Expression<Func<Work, bool>> filter);
        List<Work> GetUnfinishedWorksWithPaging(out int totalPage, int userId, int activePage=1);
        Work GetWithUrgencyId(int id);
        List<Work> GetByAppUserId(int appuserId);
        Work GetWorkWithReports(int id);
        int GetFinishedWorkCount(int id);
        int GetActiveWorkCount(int id);
        int GetWaitingTaskCount();
        int GetAllFinishedWorkCount();
        List<Work> GetAllFinishedWorks();
    }
}
