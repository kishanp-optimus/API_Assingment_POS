using MediatR;
using POS.Application.Features.OrderFeature.Query;
using POS.Application.Interface;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Implemenation of the get by id;
namespace POS.Application.Features.OrderFeature.Handler
{
    public class GenerateReportHandler : IRequestHandler<GenerateReportQuery, string>
    {
        private readonly IOrderRepository _orderRepo;
        public GenerateReportHandler(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public Task<string> Handle(GenerateReportQuery request, CancellationToken cancellationToken)
        {
            var days = request.days;
            //var res = _userRepo.GenerateReport(id);
            var report = _orderRepo.GenerateSummary(days);
            return report;
            throw new NotImplementedException();
            //return res;
        }
    }
}
