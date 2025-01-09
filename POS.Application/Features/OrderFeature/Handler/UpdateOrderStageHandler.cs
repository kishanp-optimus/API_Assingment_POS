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
    public class UpdateOrderStageHandler : IRequestHandler<UpdateOrderStageCommand, Guid>
    {
        private readonly IOrderRepository _orderRepo;
        public UpdateOrderStageHandler(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Task<Guid> Handle(UpdateOrderStageCommand request, CancellationToken cancellationToken)
        {
            var stage = request.Stage;
            var id = request.id;
            return _orderRepo.UpdateOrderStage(id, stage);
            throw new NotImplementedException();
        }
    }
}
