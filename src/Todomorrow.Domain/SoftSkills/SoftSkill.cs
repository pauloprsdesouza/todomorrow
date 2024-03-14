using System;
using System.Collections.Generic;
using Todomorrow.Domain.ActionItems;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Subcategories;
using Todomorrow.Domain.UserSkills;

namespace Todomorrow.Domain.SoftSkills
{
    public class SoftSkill : BaseModel
    {
        public Guid SubcategoryId { get; set; }
        public string Name { get; set; }

        public List<UserSkill> UserSkills { get; set; } = new();
        public List<ActionItem> ActionItems { get; set; } = new();
        public Subcategory Subcategory { get; set; }
    }
}
