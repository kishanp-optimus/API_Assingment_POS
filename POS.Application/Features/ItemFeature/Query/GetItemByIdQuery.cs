using MediatR;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.ItemFeature.Query
{
    public class GetItemByIdQuery : IRequest<Item>
    {
        public Guid id { get; set; }
        public GetItemByIdQuery(Guid id) {
            this.id = id;
        }
    }
}
