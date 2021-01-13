using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DTO.DTOs.AppUserDtos;

namespace ToDoList.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Username cannot be blank");
            RuleFor(I => I.Password).NotNull().WithMessage("Password cannot be blank");   
        }
    }
}