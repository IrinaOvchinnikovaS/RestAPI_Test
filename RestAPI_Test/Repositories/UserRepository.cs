
using RestAPI_Test.Models;
using RestAPI_Test.Repositories.Interfaces;

namespace RestAPI_Test.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        private IConfiguration config;

        public UserRepository(HttpClient _httpClient, IConfiguration _config) : base (_httpClient)
        {
            config = _config;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var stringJson = await GetAllFromSourceAsync(config.GetValue<string>("UserUrl"));
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
