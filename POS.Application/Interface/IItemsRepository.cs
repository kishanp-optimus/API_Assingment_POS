using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interface
{
    public interface IItemsRepository
    {
        Task<ICollection<Item>> GetAll();
        Task<Item> GetById(Guid id);
        Task<Guid> Update(Item item);
        Task<Guid> Create(Item item);
        Task<bool> Delete(Guid id);
    }
}
