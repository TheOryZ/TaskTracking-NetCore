using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.DTO.DTOs.WorkDtos
{
    public class WorkUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UrgencyId { get; set; }
    }
}
