using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Business.Interfaces;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Concrete;

namespace ToDoList.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDAL _userDAL;
        public AppUserManager(IAppUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public List<DualHelper> GetMostFinishedWorksAppUsers()
        {
            return _userDAL.GetMostFinishedWorksAppUsers();
        }

        public List<DualHelper> GetMostHaveWorksAppUsers()
        {
            return _userDAL.GetMostHaveWorksAppUsers();
        }

        public List<AppUser> GetUsersWithoutAdmins()
        {
            return _userDAL.GetUsersWithoutAdmins();
        }

        public List<AppUser> GetUsersWithoutAdmins(out int totalPage, string keyword, int activePage)
        {
            return _userDAL.GetUsersWithoutAdmins(out totalPage, keyword, activePage);
        }
    }
}
