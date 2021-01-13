using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Concrete;

namespace ToDoList.DTO.DTOs.ReportDtos
{
    public class ReportAddDto
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public Work Works { get; set; }
        public int WorkId { get; set; }
    }
}
