using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace todo.Services
{
    public interface ILocalStorageService
    {
        Task<T> GetItem<T>(string key);
        Task SetItem<T>(string key, T value);
        Task RemoveItem(string key);
    }

    public class LocalStorageService : ILocalStorageService
    {
        private IJSRuntime jsRuntime;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            var json = await this.jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

            if (json == null)
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task RemoveItem(string key)
        {
            await this.jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task SetItem<T>(string key, T value)
        {
            await this.jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }
    }
}