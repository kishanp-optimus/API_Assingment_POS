using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.OrderFeature.Command
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public Guid id { get; set; }
        public DeleteOrderCommand(Guid id) {
            this.id = id;
        }
    }
}
