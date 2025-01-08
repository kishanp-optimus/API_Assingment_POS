using MediatR;
using POS.Application.Features.ItemFeature.Command;
using POS.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.ItemFeature.Handler
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, bool>
    {
        private readonly IItemsRepository _itemRepo;
        public DeleteItemHandler(IItemsRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var id = request.id;
            return _itemRepo.Delete(id);
            throw new NotImplementedException();
        }
    }
}
