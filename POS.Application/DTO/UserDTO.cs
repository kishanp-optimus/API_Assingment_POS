using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public ICollection<Guid>? OrderId{ get; set; }
    }
}
