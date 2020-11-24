using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using todo.Models;
using todo.ViewModels;

namespace todo.Services
{
    public interface IAuthenticationService
    {
        AuthInfo AuthInfo { get; }
        Task Initialize();
        Task<AuthInfo> Login(LoginForm login);
        Task Logout();
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IWebApi webApi;
        private readonly ILocalStorageService localStorageService;
        private readonly NavigationManager navigationManager;

        public AuthInfo AuthInfo { get; private set; }

        public AuthenticationService(IWebApi webApi, ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            this.webApi = webApi;
            this.localStorageService = localStorageService;
            this.navigationManager = navigationManager;
        }

        public async Task Initialize()
        {
            AuthInfo = await this.localStorageService.GetItem<AuthInfo>("todo:auth");
        }

        public async Task<AuthInfo> Login(LoginForm login)
        {
            AuthInfo response = await this.webApi.Login(login);
            await this.localStorageService.SetItem("todo:auth", response);
            return response;
        }

        public async Task Logout()
        {
            AuthInfo = null;
            await this.localStorageService.RemoveItem("todo:auth");
            this.navigationManager.NavigateTo("login");
        }
    }
}