using MediatR;
using POS.Application.Features.UsersFeature.Command;
using POS.Application.Interface;
using POS.Application.Mapping;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.UsersFeature.Handler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var UserDTO = request.user;
            var mapper = UserProfile.InitialiseMapper();
            var user = mapper.Map<User>(UserDTO);
            user.Id = Guid.NewGuid();
            return _userRepository.CreateUser(user);
        }
    }
}
