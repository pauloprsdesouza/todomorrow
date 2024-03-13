using System;
using System.ComponentModel.DataAnnotations;

namespace Todomorrow.Contracts.WorkItems
{
    public class CreateWorkItemRequest
    {
        [Required]
        public Guid EpicId { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MinLength(200), MaxLength(500)]
        public string Description { get; set; }
    }
}
