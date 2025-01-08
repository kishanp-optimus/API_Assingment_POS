using MediatR;
using POS.Application.Features.OrderFeature.Command;
using POS.Application.Interface;
using POS.Application.Mapping;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.OrderFeature.Handler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepo;
        public CreateOrderHandler(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var OrderDTO = request.OrderDTO;
            var order = OrderProfile.InitialiseMapper().Map<Order>(OrderDTO);
            return _orderRepo.Create(order);
            throw new NotImplementedException();
        }
    }
}
