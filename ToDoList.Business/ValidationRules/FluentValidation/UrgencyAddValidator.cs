using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DTO.DTOs.UrgencyDtos;

namespace ToDoList.Business.ValidationRules.FluentValidation
{
    public class UrgencyAddValidator : AbstractValidator<UrgencyAddDto>
    {
        public UrgencyAddValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Description field cannot be empty");
        }
    }
}
