using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Todomorrow.Domain.BaseModels;

namespace Todomorrow.Domain.Subcategories
{
    public interface ISubcategoryRepository : IBaseRepository<Subcategory>
    {
        Task<IEnumerable<Subcategory>> GetAllByCategoryId(Guid categoryId);
    }
}
