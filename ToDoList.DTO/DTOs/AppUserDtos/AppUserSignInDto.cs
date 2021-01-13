using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.DTO.DTOs.AppUserDtos
{
    public class AppUserSignInDto
    {
        //[Required(ErrorMessage = "Username cannot be blank")]
        //[Display(Name = "User Name :")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Password cannot be blank")]
        //[Display(Name = "Password :")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        //[Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
