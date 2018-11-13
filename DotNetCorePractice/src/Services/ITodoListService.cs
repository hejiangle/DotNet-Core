
using System.Collections.Generic;

namespace DotNetCorePractice.Services
{
    public interface ITodoListService
    {
        string Create(string value);

        string Update(int id, string value);

        string Delete(int id);

        string Find(int id);

        IList<string> GetAll();
    }
}