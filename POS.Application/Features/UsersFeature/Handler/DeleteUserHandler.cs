using MediatR;
using POS.Application.Features.UsersFeature.Command;
using POS.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.UsersFeature.Handler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepo;
        public DeleteUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationtoken) {
            var id = request.id;
            return _userRepo.DeleteUser(id);
        }
    }
}
