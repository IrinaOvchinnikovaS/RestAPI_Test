using RestAPI_Test.Repositories.Interfaces;
using RestAPI_Test.Models;

namespace RestAPI_Test.Repositories
{
    public class PostRepository : AbstractRepository, IPostRepository
    {
        private IConfiguration config;

        public PostRepository(HttpClient _httpClient, IConfiguration _config) : base(_httpClient)
        {
            config = _config;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            var stringJson = await GetAllFromSourceAsync(config.GetValue<string>("PostUrl"));
            List<Post> posts = Post.FromJson(stringJson);
            return posts;
        }

        public async Task<List<Post>> GetLastByUserId(int id)
        {
            List<Post> posts = await GetAllAsync();
            var postsByUser = posts.Where(x => x.UserId == id).ToList();
            var postsByUserSorted = postsByUser.OrderByDescending(x => x.Id).ToList();
            return postsByUserSorted.Take(5).ToList();
        }
    }
}
