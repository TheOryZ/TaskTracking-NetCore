using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DTO.DTOs.WorkDtos;

namespace ToDoList.DTO.DTOs.AppUserDtos
{
    public class AssignUserListDto
    {
        public AppUserListDto AppUser { get; set; }
        public WorkListDto Work { get; set; }
    }
}
