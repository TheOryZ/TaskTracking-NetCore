using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Interfaces;

namespace ToDoList.Entities.Concrete
{
    public class Urgency : ITable
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Work> Works { get; set; }
    }
}
