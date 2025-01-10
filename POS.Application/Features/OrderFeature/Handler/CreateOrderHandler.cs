using MediatR;
using POS.Application.Features.OrderFeature.Command;
using POS.Application.Interface;
using POS.Application.Mapping;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.OrderFeature.Handler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IItemsOrderedRepository _itemOrderedRepo;
        private readonly IItemsRepository _itemRepo;
        public CreateOrderHandler(IOrderRepository orderRepo, IItemsOrderedRepository itemOrderedRepo, IItemsRepository itemRepo)
        {
            _orderRepo = orderRepo;
            _itemOrderedRepo = itemOrderedRepo;
            _itemRepo = itemRepo;
        }
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var OrderDTO = request.OrderDTO;
            var order = OrderProfile.InitialiseMapper().Map<Order>(OrderDTO);
            order.Id = Guid.NewGuid();
            var items = OrderDTO.ItemOrdered;
            var Items = new List<ItemsOrdered>();
            string status = "Confirmed";
            foreach (var item in items)
            {
                var Item = ItmesOrderedProfile.InitialiseMapper().Map<ItemsOrdered>(item);
                Item.OrderID = order.Id;
                var ItemId = Item.ItemID;
                var item1 = await _itemRepo.GetById(ItemId);
                Item.Price = item1.Price;
                Items.Add(Item);
                
                if (item1.Stock < Item.Quantity)
                {
                    status = "Pending";
                }
                else
                {
                    item1.Stock -= Item.Quantity;
                    await _itemRepo.Update(item1);
                }
                Item.Order = order;
                await _itemOrderedRepo.Create(Item);
            }
            order.Stage = status;
            order.ItemsOrdered = Items;
            return await _orderRepo.Create(order);
        }
    }
}
