using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todomorrow.Domain.Categories
{
    public interface ICategoryService
    {
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> GetById(Guid categoryId);
        Task<IEnumerable<Category>> GetAll();
    }
}
