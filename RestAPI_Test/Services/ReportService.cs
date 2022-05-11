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
        private IConfiguration config;

        private const string textPattern = "Уважаемый {0}, ниже представлен список ваших действий за последнее время. \nВыполнено задач: {1};\nНаписано постов: {2}.";

        public ReportService(IPostRepository postRepository,
            ITodoRepository todoRepository,
            IUserRepository userRepository,
            IConfiguration config)
        {
            this.postRepository = postRepository;
            this.todoRepository = todoRepository;
            this.userRepository = userRepository;
            this.config = config;
        }
        public async Task<string> GetReportByUserIdAsync(int id)
        {
            User user = await userRepository.GetByIdAsync(id);
            
            List<Todo> todosUser = await todoRepository.GetByUserIdAsync(id);

            List<Post> postsUser = await postRepository.GetLastByUserId(id);

            if(user != null)
            {
                string textResult = createTextResult(user, todosUser, postsUser);
                WriteToFile(textResult);
                return user.Name;
            }
            return "User not found!";
        }

        private string createTextResult(User user, List<Todo> todosUser, List<Post>  postsUser)
        {
            string todosText = string.Empty;
            foreach (Todo todos in todosUser)
            {
                todosText += todos.Title + ",\n";
            }
            todosText = todosText.Substring(0, todosText.Length - 2);

            string postsText = string.Empty;
            foreach(Post post in postsUser)
            {
                postsText += post.Title + ",\n";
            }
            postsText = postsText.Substring(0, postsText.Length - 2);

            string result = string.Format(textPattern, user.Username, todosText, postsText);
            return result;
        }

        private async void WriteToFile(string text)
        {
            string path = config.GetValue<string>("PathToResultFolder");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path += "//report.txt";

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                await writer.WriteLineAsync(text);
            }
        }
    }
}
