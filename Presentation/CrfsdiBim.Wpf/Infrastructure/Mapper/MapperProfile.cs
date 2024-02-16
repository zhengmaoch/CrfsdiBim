using AutoMapper;
using CrfsdiBim.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Wpf.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {

        public MapperProfile() 
        {
            CreateMap<Route, RouteModel>();
            CreateMap<RouteModel, Route>();

            CreateMap<Tunnel, TunnelModel>();
            CreateMap<TunnelModel, Tunnel>();
        }
    }
}
