using System;

namespace Todomorrow.Contracts.SoftSkills
{
    public class SoftSkillResponse
    {
        public Guid Id { get; set; }
        public Guid SubcategoryId { get; set; }
        public string Name { get; set; }
    }
}
