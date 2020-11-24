using System.Collections.Generic;
using System.Threading.Tasks;
using todo.Models;

namespace todo.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> Get();
        Task Delete(int todoId);
        Task Post(Todo todo);
        Task Put(int todoId, Todo todo);

    }
}