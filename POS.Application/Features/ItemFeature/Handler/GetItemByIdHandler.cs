using MediatR;
using POS.Application.Features.ItemFeature.Query;
using POS.Application.Interface;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.ItemFeature.Handler
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, Item>
    {
        private readonly IItemsRepository _itemRepo;
        public GetItemByIdHandler(IItemsRepository itemRepo) {
            _itemRepo = itemRepo;
        }
        public Task<Item> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var id = request.id;
            var res = _itemRepo.GetById(id);
            return res;
            throw new NotImplementedException();
        }
    }
}
