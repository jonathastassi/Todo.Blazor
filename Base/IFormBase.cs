using todo.Models;

namespace todo.Base
{
    public interface IFormBase<TModel> where TModel : ModelBase
    {
        void Open(string title, TModel model);
    }
}