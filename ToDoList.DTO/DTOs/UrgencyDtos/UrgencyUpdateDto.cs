using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.DTO.DTOs.UrgencyDtos
{
    public class UrgencyUpdateDto
    {
        public int Id { get; set; }
        //[Display(Name = "Description")]
        //[Required(ErrorMessage = "Description field cannot be empty")]
        public string Description { get; set; }
    }
}
