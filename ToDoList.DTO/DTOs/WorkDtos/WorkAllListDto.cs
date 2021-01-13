using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Concrete;

namespace ToDoList.DTO.DTOs.WorkDtos
{
    public class WorkAllListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public Urgency Urgency { get; set; }
        public AppUser AppUser { get; set; }
        public List<Report> Reports { get; set; }
    }
}
