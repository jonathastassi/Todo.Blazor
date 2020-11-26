using System.ComponentModel.DataAnnotations;
using todo.Shared.Base.Models;

namespace todo.Models
{
    public class CategoryModel : ModelBase
    {
        [Required]
        public string Name { get; set; }
    }
}