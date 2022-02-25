using RestAPI_Test.Models;

namespace RestAPI_Test.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
    }
}
