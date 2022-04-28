using RestAPI_Test.Models;
using RestAPI_Test.Repositories.Interfaces;
using RestAPI_Test.Services.Interfaces;

namespace RestAPI_Test.Services
{
    public class ReportService : IReportService
    {
        private IPostRepository postRepository;
        private ITodoRepository todoRepository;
        private IUserRepository userRepository;

        public ReportService(IPostRepository postRepository,
            ITodoRepository todoRepository,
            IUserRepository userRepository)
        {
            this.postRepository = postRepository;
            this.todoRepository = todoRepository;
            this.userRepository = userRepository;
        }
        public async void GetReportByUserIdAsync(int id)
        {
            User user = await userRepository.GetByIdAsync(id);
            
            List<Todo> todosUser = await todoRepository.GetByUserIdAsync(id);

            List<Post> postsUser = await postRepository.GetLastByUserId(id);


        }
    }
}
