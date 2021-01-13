using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.DTO.DTOs.AppUserDtos
{
    public class AppUserSignUpDto
    {
        //[Required(ErrorMessage = "Username cannot be blank")]
        //[Display(Name = "User Name :")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Password cannot be blank")]
        //[Display(Name = "Password :")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        //[Compare("Password", ErrorMessage = "Entered passwords do not match")]
        //[Display(Name = "Confirm Password :")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        //[Required(ErrorMessage = "Email cannot be blank")]
        //[EmailAddress(ErrorMessage = "Invalid format")]
        //[Display(Name = "Email :")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Name cannot be blank")]
        //[Display(Name = "Name :")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Surname cannot be blank")]
        //[Display(Name = "Surname :")]
        public string Surname { get; set; }
    }
}
