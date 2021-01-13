using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DTO.DTOs.ReportDtos;

namespace ToDoList.Business.ValidationRules.FluentValidation
{
    public class ReportAddValidator : AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(I => I.Subject).NotNull().WithMessage("Subject field cannot be blank");
            RuleFor(I => I.Description).NotNull().WithMessage("Description field cannot be blank");
        }
    }
}
