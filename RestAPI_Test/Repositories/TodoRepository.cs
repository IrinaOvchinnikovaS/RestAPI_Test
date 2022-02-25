
using RestAPI_Test.Models;
using RestAPI_Test.Repositories.Interfaces;

namespace RestAPI_Test.Repositories
{
    public class TodoRepository : AbstractRepository, ITodoRepository
    {
        public async Task<List<Todo>> GetAllAsync()
        {
            var stringJson = await GetAllFromSourceAsync("https://jsonplaceholder.typicode.com/todos");
            List<Todo> todos = Todo.FromJson(stringJson);
            return todos;
        }
    }
}
