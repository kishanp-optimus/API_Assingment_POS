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
    public class GenerateReportHandler : IRequestHandler<GenerateReportQuery, ICollection<Order>>
    {
        private readonly IUserRepository _userRepo;
        public GenerateReportHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public Task<ICollection<Order>> Handle(GenerateReportQuery request, CancellationToken cancellationToken)
        {
            var id = request.id;
            //var res = _userRepo.GenerateReport(id);
            throw new NotImplementedException();
            //return res;
        }
    }
}
