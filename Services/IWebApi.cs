using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using todo.Models;

namespace todo.Services
{
    public interface IWebApi
    {
        [Get("/todos?UserId={userId}&_sort=Done,CreatedAt&_order=desc,asc")]
        Task<List<Todo>> GetTodos(int userId);

        [Delete("/todos/{todoId}")]
        Task DeleteTodo(int todoId);

        [Post("/todos")]
        Task PostTodo(Todo todo);

        [Put("/todos/{todoId}")]
        Task PutTodo(int todoId, Todo todo);
    }
}