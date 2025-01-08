using MediatR;
using POS.Application.Features.OrderFeature.Command;
using POS.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.OrderFeature.Handler
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepo;
        public DeleteOrderHandler(IOrderRepository orderRepo) {
            _orderRepo = orderRepo;
        }
        public Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var id = request.id;
            var res = _orderRepo.Delete(id);
            return res;
            throw new NotImplementedException();
        }
    }
}
