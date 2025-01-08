using MediatR;
using POS.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.ItemFeature.Command
{
    public class CreateItemCommand : IRequest<Guid>
    {
        public ItemDTO ItemDTO { get; set; }
        public CreateItemCommand(ItemDTO itemDTO) {
            this.ItemDTO = itemDTO;
        }
    }
}
