using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.ItemFeature.Command
{
    public class DeleteItemCommand : IRequest<bool>
    {
        public Guid id { get; set; }
        public DeleteItemCommand(Guid id) {
            this.id = id;
        }
    }
}
