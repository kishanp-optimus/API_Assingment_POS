using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.OrderFeature.Command
{
    public class UpdateOrderStageCommand : IRequest<Guid>
    {
        public Guid id { get; set; }
        public string Stage { get; set; }
        public UpdateOrderStageCommand(Guid id, string stage)
        {
            this.id = id;
            Stage = stage;
        }
    }
}
