using MediatR;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Features.UsersFeature.Query
{
    public class GetAllUsersQuery : IRequest<ICollection<User>>
    {
    }
}
