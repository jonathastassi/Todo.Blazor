using System;
using System.ComponentModel.DataAnnotations;
using todo.Base;

namespace todo.Models
{
    public class TodoModel : ModelBase
    {
        [Required]
        [StringLength(30, ErrorMessage = "Título muito longo.")]
        public string Title { get; set; }
        public bool Done { get; set; }

        public TodoModel()
        {
            id = 0;
            Title = "";
            Done = false;
            CreatedAt = DateTime.Now;
        }

        public TodoModel(int id, string title, bool done, DateTime createdAt)
        {
            this.id = id;
            Title = title;
            Done = done;
            CreatedAt = createdAt;
        }
    }
}