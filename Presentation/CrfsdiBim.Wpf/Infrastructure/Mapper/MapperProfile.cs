using AutoMapper;
using CrfsdiBim.Core.Domain;

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