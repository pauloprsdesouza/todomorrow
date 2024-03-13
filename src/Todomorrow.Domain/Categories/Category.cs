using System.Collections.Generic;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Subcategories;

namespace Todomorrow.Domain.Categories
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public List<Subcategory> Subcategories { get; set; } = new();
    }
}
