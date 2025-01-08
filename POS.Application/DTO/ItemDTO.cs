using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.DTO
{
    public class ItemDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public ICollection<Guid>? ItemsOrderedId { get; set; }
    }
}
