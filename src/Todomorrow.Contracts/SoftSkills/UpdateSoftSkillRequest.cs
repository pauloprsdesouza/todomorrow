using System;
using System.ComponentModel.DataAnnotations;

namespace Todomorrow.Contracts.SoftSkills
{
    public class UpdateSoftSkillRequest
    {
        [Required]
        public Guid SubcategoryId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
