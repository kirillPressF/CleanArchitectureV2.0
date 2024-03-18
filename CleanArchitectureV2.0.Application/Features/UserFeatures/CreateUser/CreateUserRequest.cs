﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitectureV2._0.Application.Features.UseFeatures.CreateUser
{
    public sealed record CreateUserRequest(
        string Email,
        string Name) : IRequest<CreateUserResponse>;
}
