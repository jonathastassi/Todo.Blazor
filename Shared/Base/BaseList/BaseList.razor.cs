using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using todo.Shared.Base.Interfaces;
using todo.Shared.Base.Models;

namespace todo.Shared.Base.BaseList
{
    public partial class BaseList<TModel, TForm, TList> : ComponentBase
        where TModel : ModelBase
        where TForm : IFormBase<TModel>
        where TList : IListBase<TForm>
    {
        [Inject]
        public IJSRuntime JS { get; set; }

        [Parameter]
        public IServiceBase<TModel> Service { get; set; }

        [Parameter]
        public string TitleHeader { get; set; }

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public RenderFragment<TModel> Body { get; set; }

        private List<TModel> registers { get; set; } = new List<TModel>();

        [Parameter]
        public string NameModel { get; set; }


        [Parameter]
        public TList Parent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetData();
        }

        private async Task GetData()
        {
            registers = await Service.Get();
        }

        public void HandleAdd()
        {
            Parent.formRef.Open("Nova " + NameModel, null);
        }


        public async Task DeleteItem(TModel todo)
        {
            var confirm = await this.JS.InvokeAsync<bool>("confirm", "Deseja excluir o registro selecionado?");

            if (confirm)
            {
                await Service.Delete(todo.id);
                await GetData();
                await this.JS.InvokeVoidAsync("alert", "Registro excluído com sucesso!");
            }
        }


        public void EditItem(TModel todo)
        {
            Parent.formRef.Open("Editar " + NameModel, todo);
        }

        public async void RefreshData()
        {
            await GetData();
            StateHasChanged();
        }

    }
}