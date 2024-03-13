using System;
using System.ComponentModel.DataAnnotations;

namespace Todomorrow.Contracts.ActionItems
{
    public class CreateActionItemRequest
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MinLength(200), MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset DueDate { get; set; }

        public DateTimeOffset? StartedAt { get; set; }

        public DateTimeOffset? CompletedAt { get; set; }
    }
}
