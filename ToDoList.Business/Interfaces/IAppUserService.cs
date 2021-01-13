using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Concrete;

namespace ToDoList.Business.Interfaces
{
    public interface IAppUserService 
    {
        List<AppUser> GetUsersWithoutAdmins();
        List<AppUser> GetUsersWithoutAdmins(out int totalPage, string keyword, int activePage = 1);
        List<DualHelper> GetMostFinishedWorksAppUsers();
        List<DualHelper> GetMostHaveWorksAppUsers();
    }
}
