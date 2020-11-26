using System;

namespace todo.Shared.Base.Models
{
    public abstract class ModelBase
    {
        public int id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
    }
}