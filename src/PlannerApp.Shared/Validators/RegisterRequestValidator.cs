using FluentValidation;
using PlannerApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not a invalid");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(25).WithMessage("First name must be less than 25 characters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(25).WithMessage("Last name must be less than 25 characters");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required")
                .MaximumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(p => p.ConfirmPassword)
                .Equal(p => p.Password).WithMessage("Confirm password does not match")
                .NotEmpty().WithMessage("Confirm Password is required");
        }

    }
}
