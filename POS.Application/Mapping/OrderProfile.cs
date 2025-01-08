using AutoMapper;
using POS.Application.DTO;
using POS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Mapping
{
    public class OrderProfile
    {
        public static Mapper InitialiseMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>().ForMember(dest => dest.Id, opt => opt.Ignore()));
            return new Mapper(config);
        }
    }
}
