using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoMVC;
using TodoMVC.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoMVC2.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {

        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/todo
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _context.Items.OrderBy(item => item.ID);
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public TodoItem Get(int id)
        {
            var result = _context.Items.SingleOrDefault(item => item.ID == id);

            return result;
        }

        // POST api/todo
        [HttpPost]
        public TodoItem Post([FromBody] TodoItem item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();

            return item;
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TodoItem todo)
        {
			var item = _context.Items.SingleOrDefault(x => x.ID == id);

			if (item == null)
				return;

			if (todo == null)
				return;

			if (item.ID != todo.ID)
				return;

			item.Complete = todo.Complete;
			item.Title = todo.Title;

			_context.SaveChanges();
		}

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _context.Items.SingleOrDefault(x => x.ID == id);

            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
