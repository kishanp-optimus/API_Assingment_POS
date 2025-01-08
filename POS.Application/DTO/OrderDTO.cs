using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.DTO
{
    public class OrderDTO
    {
        public string Stage { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Guid>? ItemsOrderedId { get; set; }
    }
}
