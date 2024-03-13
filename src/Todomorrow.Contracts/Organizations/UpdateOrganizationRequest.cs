using System.ComponentModel.DataAnnotations;

namespace Todomorrow.Contracts.Organizations
{
    public class UpdateOrganizationRequest
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }
    }
}
