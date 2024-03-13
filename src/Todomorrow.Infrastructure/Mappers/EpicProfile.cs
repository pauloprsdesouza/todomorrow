using AutoMapper;
using Todomorrow.Contracts.Epics;
using Todomorrow.Domain.Epics;

namespace Todomorrow.Infrastructure.Mappers
{
    public class EpicProfile : Profile
    {
        public EpicProfile()
        {
            CreateMap<CreateEpicRequest, Epic>();
            CreateMap<Epic, EpicResponse>();
        }
    }
}
