using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.UsersFeature.Command
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid id { get; set; }
        public DeleteUserCommand(Guid id)
        {
            this.id = id;
        }
    }
}
