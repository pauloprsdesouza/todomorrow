using System;
using System.ComponentModel.DataAnnotations;

namespace Todomorrow.Contracts.UserSkills
{
    public class UpdateUserSkillRequest
    {
        [Required]
        public Guid SoftSkillId { get; set; }

        [Required, Range(0.0, 5.0)]
        public int Level { get; set; }
    }
}
