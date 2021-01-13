using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DTO.DTOs.UrgencyDtos;

namespace ToDoList.Business.ValidationRules.FluentValidation
{
    public class UrgencyUpdateValidator : AbstractValidator<UrgencyUpdateDto>
    {
        public UrgencyUpdateValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Description field cannot be empty");
        }
    }
}
