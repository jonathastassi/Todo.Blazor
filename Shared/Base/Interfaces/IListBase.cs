using todo.Models;

namespace todo.Shared.Base.Interfaces
{
    public interface IListBase<TForm>
    {
        TForm formRef { get; set; }
    }
}