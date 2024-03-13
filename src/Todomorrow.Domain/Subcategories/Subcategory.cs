using System;
using System.Collections.Generic;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Categories;
using Todomorrow.Domain.SoftSkills;

namespace Todomorrow.Domain.Subcategories
{
    public class Subcategory : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
        public List<SoftSkill> SoftSkills { get; set; }

    }
}
