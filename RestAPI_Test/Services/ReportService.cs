using RestAPI_Test.Models;
using RestAPI_Test.Repositories.Interfaces;
using RestAPI_Test.Services.Interfaces;
using System.Text;

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
            StringBuilder sb = new StringBuilder(textPattern);

            StringBuilder todosText = new StringBuilder();
            foreach (Todo todos in todosUser)
            {
                todosText.Append(todos.Title);
                todosText.Append(",\n");
            }
            todosText.Remove(todosText.Length - 2, 2);

            StringBuilder postsText = new StringBuilder();
            foreach (Post post in postsUser)
            {
                postsText.Append(post.Title);
                postsText.Append(",\n");
            }
            postsText.Remove(postsText.Length - 2, 2);

            sb.Replace("{0}", user.Name);
            sb.Replace("{1}", todosText.ToString());
            sb.Replace("{2}", postsText.ToString());
            return sb.ToString();
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
