using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using todo.Models;
using todo.ViewModels;

namespace todo.Services
{
    public interface IWebApi
    {
        [Get("/todos?UserId={userId}&_sort=Done,CreatedAt&_order=desc,asc")]
        Task<List<TodoModel>> GetTodos(int userId);

        [Delete("/todos/{todoId}")]
        Task DeleteTodo(int todoId);

        [Post("/todos")]
        Task PostTodo(TodoModel todo);

        [Put("/todos/{todoId}")]
        Task PutTodo(int todoId, TodoModel todo);

        

        [Post("/login")]
        Task<AuthInfo> Login(LoginForm login);

        [Post("/register")]
        Task<AuthInfo> Register(User user);




        [Get("/categories?UserId={userId}")]
        Task<List<CategoryModel>> GetCategories(int userId);

        [Delete("/categories/{categoryId}")]
        Task DeleteCategory(int categoryId);

        [Post("/categories")]
        Task PostCategory(CategoryModel todo);

        [Put("/categories/{categoryId}")]
        Task PutCategory(int categoryId, CategoryModel todo);
    }
}