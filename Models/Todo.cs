using System;
using System.ComponentModel.DataAnnotations;

namespace todo.Models
{
    public class Todo
    {
        public int id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Título muito longo.")]
        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        public Todo()
        {
            id = 0;
            Title = "";
            Done = false;
            CreatedAt = DateTime.Now;
        }

        public Todo(int id, string title, bool done, DateTime createdAt)
        {
            this.id = id;
            Title = title;
            Done = done;
            CreatedAt = createdAt;
        }
    }
}