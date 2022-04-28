using RestAPI_Test.Repositories.Interfaces;
using RestAPI_Test.Models;

namespace RestAPI_Test.Repositories
{
    public class PostRepository : AbstractRepository, IPostRepository
    {
        public async Task<List<Post>> GetAllAsync()
        {
            var stringJson = await GetAllFromSourceAsync("http://jsonplaceholder.typicode.com/posts");
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
