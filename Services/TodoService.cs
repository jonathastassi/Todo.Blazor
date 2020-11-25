using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using todo.Models;

namespace todo.Services
{
    public class TodoService : ITodoService
    {
        private readonly IWebApi webApi;
        private readonly IAuthenticationService authenticationService;

        private readonly int userId;

        public TodoService(IWebApi webApi, IAuthenticationService authenticationService)
        {
            this.webApi = webApi;
            this.authenticationService = authenticationService;
            this.userId = int.Parse(this.authenticationService.AuthInfo.sub);
        }

        public async Task<List<Todo>> Get()
        {
            var response = await this.webApi.GetTodos(this.userId);
            return response;
        }

        public async Task Delete(int todoId)
        {
            await this.webApi.DeleteTodo(todoId);
        }

        public async Task Post(Todo todo)
        {
            todo.UserId = this.userId;
            await this.webApi.PostTodo(todo);
        }

        public async Task Put(int todoId, Todo todo)
        {
            todo.UserId = this.userId;
            await this.webApi.PutTodo(todoId, todo);
        }
    }
}