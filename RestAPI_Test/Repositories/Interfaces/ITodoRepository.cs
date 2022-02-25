using RestAPI_Test.Models;

namespace RestAPI_Test.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
    }
}
