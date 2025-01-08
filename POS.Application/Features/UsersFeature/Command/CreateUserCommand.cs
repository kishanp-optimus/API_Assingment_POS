using MediatR;
using POS.Application.DTO;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.UsersFeature.Command
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public UserDTO user { get; set; }
        public CreateUserCommand(UserDTO user) {
            this.user = user;
        }
    }
}
