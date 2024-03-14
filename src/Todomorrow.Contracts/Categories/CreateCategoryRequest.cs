using System.ComponentModel.DataAnnotations;

namespace Todomorrow.Contracts.Categories
{
    public class CreateCategoryRequest
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
