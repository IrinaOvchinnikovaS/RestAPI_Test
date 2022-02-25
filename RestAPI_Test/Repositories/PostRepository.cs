using RestAPI_Test.Repositories.Interfaces;
using RestAPI_Test.Models;

namespace RestAPI_Test.Repositories
{
    public class PostRepository : AbstractRepository, IPostRepository
    {
        public async Task<List<Post>> GetAllAsync()
        {
            var stringJson = await GetAllFromSourceAsync("https://jsonplaceholder.typicode.com/posts");
            List<Post> posts = Post.FromJson(stringJson);
            return posts;
        }
    }
}
