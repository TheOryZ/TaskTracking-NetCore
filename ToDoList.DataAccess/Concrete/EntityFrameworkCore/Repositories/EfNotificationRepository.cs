using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDAL
    {
        public List<Notification> GetUnReadNotifications(int appUserId)
        {
            using var context = new ToDoContext();
            return context.Notifications.Where(I => I.AppUserId == appUserId && !I.Status).ToList();
        }

        public int GetUnReadNotificationsCount(int id)
        {
            using var context = new ToDoContext();
            return context.Notifications.Count(I => I.AppUserId == id && !I.Status);
        }
    }
}
