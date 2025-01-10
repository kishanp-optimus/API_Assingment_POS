using MediatR;
using POS.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.OrderFeature.Command
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public OrderDTO OrderDTO { get; set; }
        public Guid id { get; set; }
        public CreateOrderCommand(Guid id, OrderDTO orderDTO) {
            this.OrderDTO = orderDTO;
            this.id = id;
        }
    }
}
