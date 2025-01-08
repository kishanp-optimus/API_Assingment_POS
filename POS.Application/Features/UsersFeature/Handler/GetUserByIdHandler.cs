using MediatR;
using POS.Application.Features.UsersFeature.Query;
using POS.Application.Interface;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.UsersFeature.Handler
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _userRepo;
        public GetUserByIdHandler(IUserRepository userRepo) {
            _userRepo = userRepo;
        }
        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var id = request.id;
            return _userRepo.GetUserById(id);
            throw new NotImplementedException();
        }
    }
}
