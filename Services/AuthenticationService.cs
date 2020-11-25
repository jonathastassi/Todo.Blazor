using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using todo.Models;
using todo.ViewModels;

namespace todo.Services
{
    public interface IAuthenticationService
    {
        AuthInfo AuthInfo { get; set; }
        Task Initialize();
        void SetEmail(string email);

        Task<AuthInfo> Login(LoginForm login);
        Task<AuthInfo> Register(User login);

        Task Logout();
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IWebApi webApi;
        private readonly ILocalStorageService localStorageService;
        private readonly NavigationManager navigationManager;

        public AuthInfo AuthInfo { get; set; }

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

            var jwt = response.accessToken;

            string[] jwtEncodedSegments = jwt.Split('.');
            var payloadSegment = jwtEncodedSegments[1];

            var decodePayload = System.Convert.FromBase64String(payloadSegment);
            var decodedUtf8Payload = Encoding.UTF8.GetString(decodePayload);

            var authInfo = JsonSerializer.Deserialize<AuthInfo>(decodedUtf8Payload.ToString());
            authInfo.accessToken = jwt;

            await this.localStorageService.SetItem("todo:auth", authInfo);
            return response;
        }

        public async Task Logout()
        {
            AuthInfo = null;
            await this.localStorageService.RemoveItem("todo:auth");
            this.navigationManager.NavigateTo("login");
        }

        public async Task<AuthInfo> Register(User user)
        {
            AuthInfo response = await this.webApi.Register(user);

            var jwt = response.accessToken;

            string[] jwtEncodedSegments = jwt.Split('.');
            var payloadSegment = jwtEncodedSegments[1];

            var decodePayload = System.Convert.FromBase64String(payloadSegment);
            var decodedUtf8Payload = Encoding.UTF8.GetString(decodePayload);

            var authInfo = JsonSerializer.Deserialize<AuthInfo>(decodedUtf8Payload.ToString());
            authInfo.accessToken = jwt;

            await this.localStorageService.SetItem("todo:auth", authInfo);
            return response;
        }

        public void SetEmail(string email)
        {
            this.AuthInfo.email = email;
        }
    }
}