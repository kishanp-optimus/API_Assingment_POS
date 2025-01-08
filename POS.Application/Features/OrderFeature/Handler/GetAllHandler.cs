using MediatR;
using POS.Application.Features.OrderFeature.Query;
using POS.Application.Interface;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.OrderFeature.Handler
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, ICollection<Order>>
    {
        private readonly IOrderRepository _orderRepo;
        public GetAllHandler(IOrderRepository orderRepo) {
            _orderRepo = orderRepo;
        }
        public Task<ICollection<Order>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return _orderRepo.GetAll();
            throw new NotImplementedException();
        }
    }
}
