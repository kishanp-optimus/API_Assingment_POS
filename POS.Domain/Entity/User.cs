using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
