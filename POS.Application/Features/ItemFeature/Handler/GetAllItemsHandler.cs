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
    public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, ICollection<Item>>
    {
        private readonly IItemsRepository _itemRepo;
        public GetAllItemsHandler(IItemsRepository itemRepo) {
            _itemRepo = itemRepo;
        }
        public Task<ICollection<Item>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return _itemRepo.GetAll();
            throw new NotImplementedException();
        }
    }
}
