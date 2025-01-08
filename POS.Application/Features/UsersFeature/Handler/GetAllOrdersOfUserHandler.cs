using MediatR;
using POS.Application.Features.UsersFeature.Query;
using POS.Application.Interface;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.UsersFeature.Handler
{
    public class GetAllOrdersOfUserHandler : IRequestHandler<GetAllOrdersOfUserQuery, ICollection<Order>>
    {
        private readonly IUserRepository _userRepo;
        public GetAllOrdersOfUserHandler(IUserRepository userRepo) {
            _userRepo = userRepo;
        }
        public Task<ICollection<Order>> Handle(GetAllOrdersOfUserQuery request, CancellationToken cancellationToken)
        {
            var id = request.id;
            var users = _userRepo.GetAllOrdersOfUser(id);
            return users;
            throw new NotImplementedException();
        }
    }
}
