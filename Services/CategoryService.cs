using System.Collections.Generic;
using System.Threading.Tasks;
using todo.Models;

namespace todo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IWebApi webApi;
        private readonly IAuthenticationService authenticationService;

        private readonly int userId;

        public CategoryService(IWebApi webApi, IAuthenticationService authenticationService)
        {
            this.webApi = webApi;
            this.authenticationService = authenticationService;
            this.userId = int.Parse(this.authenticationService.AuthInfo.sub);
        }

        public async Task<List<CategoryModel>> Get()
        {
            var response = await this.webApi.GetCategories(this.userId);
            return response;
        }

        public async Task Delete(int categoryId)
        {
            await this.webApi.DeleteCategory(categoryId);
        }

        public async Task Post(CategoryModel category)
        {
            category.UserId = this.userId;
            await this.webApi.PostCategory(category);
        }

        public async Task Put(int categoryId, CategoryModel category)
        {
            category.UserId = this.userId;
            await this.webApi.PutCategory(categoryId, category);
        }
    }
}