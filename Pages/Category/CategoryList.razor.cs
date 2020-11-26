using Microsoft.AspNetCore.Components;
using todo.Shared.Base.Interfaces;

namespace todo.Pages.Category
{
    public partial class CategoryList : ComponentBase, IListBase<CategoryForm>
    {
        public CategoryForm formRef { get; set; }
        public CategoryList listRef { get; set; }

    }
}