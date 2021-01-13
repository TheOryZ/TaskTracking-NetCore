using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Business.Interfaces;
using ToDoList.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Concrete;

namespace ToDoList.Business.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly IUrgencyDAL _urgencyDAL;
        public UrgencyManager(IUrgencyDAL urgencyDAL)
        {
            _urgencyDAL = urgencyDAL;
        }
        public void Delete(Urgency table)
        {
            _urgencyDAL.Delete(table);
        }

        public Urgency Get(int Id)
        {
            return _urgencyDAL.Get(Id);
        }

        public List<Urgency> GetAll()
        {
            return _urgencyDAL.GetAll();
        }

        public void Save(Urgency table)
        {
            _urgencyDAL.Save(table);
        }

        public void Update(Urgency table)
        {
            _urgencyDAL.Update(table);
        }
    }
}
