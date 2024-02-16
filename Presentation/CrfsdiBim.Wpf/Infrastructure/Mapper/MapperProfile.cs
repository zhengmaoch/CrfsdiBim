using AutoMapper;
using CrfsdiBim.Core.Domain;
using CrfsdiBim.Core.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Wpf.Infrastructure.Mapper
{
    public class MapperProfile : Profile, IMapperProfile
    {

        public MapperProfile() 
        {
            CreateMap<Route, RouteModel>();
            CreateMap<RouteModel, Route>();

            CreateMap<Tunnel, TunnelModel>();
            CreateMap<TunnelModel, Tunnel>();
        }
        public int Order => 0;
    }
}
