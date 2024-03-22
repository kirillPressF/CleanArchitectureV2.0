using CleanArchitectureV2._0.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureV2._0.Application.Features.UserFeatures.GetAllUser
{
    public sealed class GetAllUserHandler : IRequestHandler<GetAllUserRequest, List<GetAllUserResponse>>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IUserRepository _userRepository;

        public GetAllUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<List<GetAllUserResponse>> Handle(GetAllUserRequest request,
            CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll(cancellationToken);
            return users.Select(user=> new GetAllUserResponse
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            }).ToList();
        }
    }
}
