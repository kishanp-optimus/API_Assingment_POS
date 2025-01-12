using MediatR;
using POS.Application.Features.ItemFeature.Command;
using POS.Application.Interface;
using POS.Application.Mapping;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.ItemFeature.Handler
{
    public class CreateItemHandler : IRequestHandler<CreateItemCommand, Guid>
    {
        public IItemsRepository _itemsRepository;
        public CreateItemHandler(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }
        public Task<Guid> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var ItemDTO = request.ItemDTO;
            var item = ItemProfile.InitialiseMapper().Map<Item>(ItemDTO);
            return _itemsRepository.Create(item);
        }
    }
}
