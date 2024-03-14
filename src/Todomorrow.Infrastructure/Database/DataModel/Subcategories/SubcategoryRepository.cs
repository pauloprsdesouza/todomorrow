using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todomorrow.Domain.Subcategories;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.Subcategories
{
    public class SubcategoryRepository : BaseRepository<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Subcategory>> GetAllByCategoryId(Guid categoryId)
        {
            return await _database.Where(x => x.CategoryId == categoryId).ToListAsync();
        }
    }
}
