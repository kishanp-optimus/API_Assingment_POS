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
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ICollection<User>>
    {
        private readonly IUserRepository _userRepo;
        public GetAllUsersHandler(IUserRepository userRepo) {
            _userRepo = userRepo;
        }
        public Task<ICollection<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return _userRepo.GetAllUsers();
        }
    }
}
