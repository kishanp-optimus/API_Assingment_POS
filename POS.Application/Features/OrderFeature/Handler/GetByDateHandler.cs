using MediatR;
using POS.Application.Features.OrderFeature.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Application.Features.OrderFeature.Query;
using POS.Application.Interface;
using POS.Domain.Entity;

namespace POS.Application.Features.OrderFeature.Handler
{
    public class GetByDateHandler : IRequestHandler<GetByDateQuery, ICollection<Order>>
    {
        private readonly IOrderRepository _orderRepo;
        public GetByDateHandler(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Task<ICollection<Order>> Handle(GetByDateQuery request, CancellationToken cancellationToken)
        {
            var days = request.days;
            return _orderRepo.GetByDate(days);
            throw new NotImplementedException();
        }
    }
}
