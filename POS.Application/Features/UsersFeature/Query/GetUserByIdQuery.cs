using MediatR;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.UsersFeature.Query
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid id { get; set; }
        public GetUserByIdQuery(Guid id) {
            this.id = id;
        }
    }
}
