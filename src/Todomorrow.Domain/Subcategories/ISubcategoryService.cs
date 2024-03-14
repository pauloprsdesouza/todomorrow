using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todomorrow.Domain.Subcategories
{
    public interface ISubcategoryService
    {
        Task<Subcategory> Create(Subcategory subcategory);
        Task<Subcategory> Update(Subcategory subcategory);
        Task<IEnumerable<Subcategory>> GetAllByCategoryId(Guid categoryId);
    }
}
