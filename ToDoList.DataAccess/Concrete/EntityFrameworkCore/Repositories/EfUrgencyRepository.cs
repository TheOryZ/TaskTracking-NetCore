using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUrgencyRepository : EfGenericRepository<Urgency>, IUrgencyDAL
    {
    }
}
