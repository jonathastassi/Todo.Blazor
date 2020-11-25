using System.ComponentModel.DataAnnotations;
using todo.Base;

namespace todo.Models
{
    public class CategoryModel : ModelBase
    {
        [Required]
        public string Name { get; set; }
    }
}