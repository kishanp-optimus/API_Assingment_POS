using MediatR;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.UsersFeature.Query
{
    public class GetAllOrdersOfUserQuery : IRequest<ICollection<Order>>
    {
        public Guid id { get; set; }
        public GetAllOrdersOfUserQuery(Guid id) {
            this.id = id;
        }
    }
}
