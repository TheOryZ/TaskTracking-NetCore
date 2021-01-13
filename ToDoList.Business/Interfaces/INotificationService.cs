using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Concrete;

namespace ToDoList.Business.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetUnReadNotifications(int appUserId);
        int GetUnReadNotificationsCount(int id);
    }
}
