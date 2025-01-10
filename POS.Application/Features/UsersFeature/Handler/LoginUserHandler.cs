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
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepo;
        public LoginUserHandler(IUserRepository userRepo) {
            _userRepo = userRepo;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userDTO = request.user;
            var user = UserProfile.InitialiseMapper().Map<User>(userDTO);
            var id = request.id;
            var OgUser = await _userRepo.GetUserById(id);
            if (OgUser.Password == user.Password){
                user.Id = id;
                return await _userRepo.LoginUser(user);
            }
            else
                return "Wrong Password";
            throw new NotImplementedException();
        }
    }
}
