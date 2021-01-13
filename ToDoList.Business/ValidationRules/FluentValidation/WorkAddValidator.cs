using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DTO.DTOs.WorkDtos;

namespace ToDoList.Business.ValidationRules.FluentValidation
{
    public class WorkAddValidator : AbstractValidator<WorkAddDto>
    {
        public WorkAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Name is required");
            RuleFor(I => I.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Please select an urgency");
        }
    }
}
