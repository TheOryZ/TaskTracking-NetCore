using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DTO.DTOs.AppUserDtos;

namespace ToDoList.Business.ValidationRules.FluentValidation
{
    public class AppUserSignUpValidator : AbstractValidator<AppUserSignUpDto>
    {
        public AppUserSignUpValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Username cannot be blank");
            RuleFor(I => I.Password).NotNull().WithMessage("Password cannot be blank");
            RuleFor(I => I.ConfirmPassword).NotNull().WithMessage("Password cannot be blank");
            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Entered passwords do not match");
            RuleFor(I => I.Email).NotNull().WithMessage("Email cannot be blank");
            RuleFor(I => I.Email).EmailAddress().WithMessage("Invalid format");
            RuleFor(I => I.Name).NotNull().WithMessage("Name cannot be blank");
            RuleFor(I => I.Surname).NotNull().WithMessage("Surname cannot be blank");
        }
    }
}
