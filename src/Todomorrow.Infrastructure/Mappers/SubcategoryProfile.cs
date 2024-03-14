using AutoMapper;
using Todomorrow.Contracts.Subcategories;
using Todomorrow.Domain.Subcategories;

namespace Todomorrow.Infrastructure.Mappers
{
    public class SubcategoryProfile : Profile
    {
        public SubcategoryProfile()
        {
            CreateMap<Subcategory, SubcategoryResponse>();
            CreateMap<CreateSubcategoryRequest, Subcategory>();
            CreateMap<UpdateSubcategoryRequest, Subcategory>();
        }
    }
}
