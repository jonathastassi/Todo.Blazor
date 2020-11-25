using System.Collections.Generic;
using Microsoft.JSInterop;
using todo.Services;
using todo.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using todo.Base;

namespace todo.Pages.Category
{
    public partial class CategoryList : ComponentBase, IListBase<CategoryForm>
    {
        public CategoryForm formRef { get; set; }
    }
}