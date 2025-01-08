using MediatR;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.OrderFeature.Query
{
    public class GenerateReportQuery : IRequest<ICollection<Order>>
    {
        public Guid id;
        public GenerateReportQuery(Guid id)
        {
            this.id = id;
        }
    }
}
