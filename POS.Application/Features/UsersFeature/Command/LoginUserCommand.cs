using MediatR;
using POS.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.UsersFeature.Command
{
    public class LoginUserCommand : IRequest<string>
    {
        public Guid id { get; set; }
        public UserDTO user { get; set; }
        public LoginUserCommand(Guid id,  UserDTO user)
        {
            this.id = id;
            this.user = user;
        }
    }
}
