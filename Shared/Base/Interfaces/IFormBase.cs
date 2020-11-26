using todo.Shared.Base.Models;

namespace todo.Shared.Base.Interfaces
{
    public interface IFormBase<TModel> where TModel : ModelBase
    {
        void Open(string title, TModel model);
    }
}