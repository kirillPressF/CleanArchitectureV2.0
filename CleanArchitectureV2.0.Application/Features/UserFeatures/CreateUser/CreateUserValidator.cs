﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitectureV2._0.Application.Features.UseFeatures.CreateUser
{
    public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x=>x.Email)
                .NotEmpty()
                .MaximumLength(50)
                .EmailAddress();
            
            RuleFor(x=>x.Name)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(3);
        }
    }
}
