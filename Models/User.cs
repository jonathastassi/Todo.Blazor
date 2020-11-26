using todo.Shared.Base.Models;

namespace todo.Models
{
    public class User : ModelBase
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}