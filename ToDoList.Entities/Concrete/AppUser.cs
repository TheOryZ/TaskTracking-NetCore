using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Interfaces;

namespace ToDoList.Entities.Concrete
{
    public class AppUser :IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Picture { get; set; } = "default.png";
        public List<Work> Works { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
