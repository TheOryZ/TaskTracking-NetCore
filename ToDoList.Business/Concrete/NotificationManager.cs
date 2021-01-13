using System.Collections.Generic;
using ToDoList.Business.Interfaces;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Concrete;

namespace ToDoList.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDAL _notificationDAL;
        public NotificationManager(INotificationDAL notificationDAL)
        {
            _notificationDAL = notificationDAL;
        }
        public void Delete(Notification table)
        {
            _notificationDAL.Delete(table);
        }

        public Notification Get(int Id)
        {
            return _notificationDAL.Get(Id);
        }

        public List<Notification> GetAll()
        {
            return _notificationDAL.GetAll();
        }

        public List<Notification> GetUnReadNotifications(int appUserId)
        {
            return _notificationDAL.GetUnReadNotifications(appUserId);
        }

        public int GetUnReadNotificationsCount(int id)
        {
            return _notificationDAL.GetUnReadNotificationsCount(id);
        }

        public void Save(Notification table)
        {
            _notificationDAL.Save(table);
        }

        public void Update(Notification table)
        {
            _notificationDAL.Update(table);
        }
    }
}
