using RestAPI_Test.Models;

namespace RestAPI_Test.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllAsync();
    }
}
