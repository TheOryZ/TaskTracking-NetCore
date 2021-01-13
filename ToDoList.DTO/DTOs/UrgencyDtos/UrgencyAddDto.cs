using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.DTO.DTOs.UrgencyDtos
{
    public class UrgencyAddDto
    {
        /*
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description field cannot be empty")]
         */
        public string Description { get; set; }
    }
}
