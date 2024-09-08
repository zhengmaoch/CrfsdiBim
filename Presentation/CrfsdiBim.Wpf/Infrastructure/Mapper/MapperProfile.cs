using AutoMapper;
using CrfsdiBim.Core.Domain;
using CrfsdiBim.Core.Domain.Projects;

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