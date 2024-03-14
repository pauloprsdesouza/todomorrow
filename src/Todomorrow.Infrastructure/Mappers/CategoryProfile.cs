using AutoMapper;
using Todomorrow.Contracts.Categories;
using Todomorrow.Domain.Categories;

namespace Todomorrow.Infrastructure.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
        }
    }
}
