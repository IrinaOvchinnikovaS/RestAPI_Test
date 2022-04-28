
using RestAPI_Test.Models;
using RestAPI_Test.Repositories.Interfaces;

namespace RestAPI_Test.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        public async Task<List<User>> GetAllAsync()
        {
            var stringJson = await GetAllFromSourceAsync("https://jsonplaceholder.typicode.com/users");
            List<User> users = User.FromJson(stringJson);
            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            List<User> users = await GetAllAsync();
            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }
    }
}
