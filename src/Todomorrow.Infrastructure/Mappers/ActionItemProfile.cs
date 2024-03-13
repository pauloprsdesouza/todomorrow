using AutoMapper;
using Todomorrow.Contracts.ActionItems;
using Todomorrow.Domain.ActionItems;

namespace Todomorrow.Infrastructure.Mappers
{
    public class ActionItemProfile : Profile
    {
        public ActionItemProfile()
        {
            CreateMap<CreateActionItemRequest, ActionItem>();
            CreateMap<ActionItem, ActionItemResponse>();
        }
    }
}
