using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Interfaces;

namespace ToDoList.Entities.Concrete
{
    public class Notification : ITable
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public AppUser AppUser { get; set; }
    }
}
