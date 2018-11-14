using System.Collections.Generic;

namespace DotNetCorePractice.Services.Implementation
{
    public class TodoListService : ITodoListService
    {
        public string Create(string value)
        {
            return string.Format("Create new item {0}.", value);
        }

        public string Delete(int id)
        {
            return string.Format("Delete {0} is done.", id);
        }

        public string Find(int id)
        {
            return "New Item";
        }

        public IList<string> GetAll()
        {
            return new List<string> { "New Item" };
        }

        public string Update(int id, string value)
        {
            return string.Format("Update {0} to {1} is done.", id, value);
        }
    }
}