using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using todo.Models;

namespace todo.Services
{
    public class TodoService : ITodoService
    {
        private readonly IWebApi webApi;

        public TodoService(IWebApi webApi)
        {
            this.webApi = webApi;
        }

        public async Task<List<Todo>> Get()
        {
            int userId = 3;
            var response = await this.webApi.GetTodos(userId);
            return response;
        }

        public async Task Delete(int todoId)
        {
            await this.webApi.DeleteTodo(todoId);
        }

        public async Task Post(Todo todo)
        {
            int userId = 3;

            todo.UserId = userId;
            await this.webApi.PostTodo(todo);
        }

        public async Task Put(int todoId, Todo todo)
        {
            int userId = 3;

            todo.UserId = userId;
            await this.webApi.PutTodo(todoId, todo);
        }
    }
}