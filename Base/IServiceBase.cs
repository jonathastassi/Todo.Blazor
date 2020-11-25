using System.Collections.Generic;
using System.Threading.Tasks;

namespace todo.Base
{
    public interface IServiceBase<T>
    {
        Task<List<T>> Get();
        Task Delete(int todoId);
        Task Post(T todo);
        Task Put(int todoId, T todo);
    }
}