using System;
using System.Collections.Generic;
using System.Linq;
using DotNetCorePractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCorePractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            this._todoListService = todoListService;
        }

        // GET api/todolist
        [HttpGet]
        public ActionResult<IList<string>> Get()
        {
            return _todoListService.GetAll().ToList();
        }

        // GET api/todolist/{id}
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return _todoListService.Find(id);
        }

        // POST api/todolist
        [HttpPost]
        public string Post([FromBody] string value)
        {
            // to save item.
            return _todoListService.Create(value);
        }

        // UPDATE api/todolist
        [HttpPut("{id}")]
        public string Put(
            [FromQuery] int id,
            [FromBody] string value
        )
        {
            // to upadte item.
            return _todoListService.Update(id, value);
        }

        // DELETE api/todolist/{id}
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            // to delete item.
            return _todoListService.Delete(id);
        }
    }
}