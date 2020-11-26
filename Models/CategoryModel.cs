using System;
using System.ComponentModel.DataAnnotations;
using todo.Shared.Base.Models;

namespace todo.Models
{
    public class CategoryModel : ModelBase
    {
        [Required]
        public string Name { get; set; }

        public CategoryModel()
        {
            CreatedAt = DateTime.Now;
        }

        public CategoryModel(int id, string name)
        {
            this.id = id;
            Name = name;
        }
    }
}