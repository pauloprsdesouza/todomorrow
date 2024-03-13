using AutoMapper;
using Todomorrow.Contracts.WorkItems;
using Todomorrow.Domain.WorkItems;

namespace Todomorrow.Infrastructure.Mappers
{
    public class WorkItemProfile : Profile
    {
        public WorkItemProfile()
        {
            CreateMap<CreateWorkItemRequest, WorkItem>();
            CreateMap<WorkItem, WorkItemResponse>();
        }
    }
}
