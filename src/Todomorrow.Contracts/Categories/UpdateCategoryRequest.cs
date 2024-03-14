using System.ComponentModel.DataAnnotations;

namespace Todomorrow.Contracts.Categories
{
    public class UpdateCategoryRequest
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
