using CleanArchitectureV2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureV2._0.Application.Features.UseFeatures.CreateUser
{
    public static class CreateUserMapper
    {
        public static UserEntity MapToUserEntity(this CreateUserRequest request)
        {
            return new UserEntity
            {
                Email = request.Email,
                Name = request.Name
            };
        }

        public static CreateUserResponse MapToResponse(this UserEntity entity)
        {
            return new CreateUserResponse
            {
                Id = entity.Id,
                Email = entity.Email,
                Name = entity.Name
            };
        }
    }
}
