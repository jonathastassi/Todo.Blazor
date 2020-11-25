using todo.Models;

namespace todo.Base
{
    public interface IListBase<TForm>
    {
        TForm formRef { get; set; }
    }
}