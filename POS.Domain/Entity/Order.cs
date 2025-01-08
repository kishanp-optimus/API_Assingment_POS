using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entity
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Stage { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<ItemsOrdered> ItemsOrdered { get; set; }
    }
}
