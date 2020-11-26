using Microsoft.AspNetCore.Components;
using todo.Models;
using todo.Shared.Base.BaseList;
using todo.Shared.Base.Interfaces;

namespace todo.Pages.Category
{
    public partial class CategoryList : ComponentBase, IListBase<CategoryForm>
    {
        public CategoryForm formRef { get; set; }
        public BaseList<CategoryModel, CategoryForm, CategoryList> listRef { get; set; }

        public void RefreshData()
        {
            listRef.RefreshData();
        }
    }
}