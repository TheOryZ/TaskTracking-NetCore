using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.Entities.Interfaces;

namespace ToDoList.Entities.Concrete
{
    public class Work : ITable
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
        public List<Report> Reports { get; set; }

    }
}
