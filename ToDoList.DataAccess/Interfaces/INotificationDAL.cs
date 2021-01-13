using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Interfaces
{
    public interface INotificationDAL : IGenericDAL<Notification>
    {
        List<Notification> GetUnReadNotifications(int appUserId);
        int GetUnReadNotificationsCount(int id);
    }
}
