using System;
using System.ComponentModel.DataAnnotations;

namespace Todomorrow.Contracts.Subcategories
{
    public class UpdateSubcategoryRequest
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
