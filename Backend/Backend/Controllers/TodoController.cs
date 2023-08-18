using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var user_id = HttpContext.Request.Cookies["user_id"];
            if (user_id == null)
            {
                return Unauthorized();
            }

            return Ok(_context.Todos.Where(todo => todo.userId == Int32.Parse(user_id)).Include(todo => todo.importance).ToList());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Todo todo)
        {
            var user_id = HttpContext.Request.Cookies["user_id"];
            if (user_id == null)
            {
                return Unauthorized();
            }
            Importance importance = _context.Importances.Find(todo.ImportanceId);
            if (importance == null)
            {
                return NotFound();
            }
            todo.importance = importance;
            todo.userId = Int32.Parse(user_id);
            todo.user = _context.Users.Find(todo.userId);
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Todo updatedTodo)
        {
            var user_id = HttpContext.Request.Cookies["user_id"];
            if (user_id == null)
            {
                return Unauthorized();
            }
            var todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            todo = updatedTodo;
            var importance = _context.Importances.Find(todo.ImportanceId);
            if (importance == null)
            {
                return NotFound();
            }
            todo.importance = importance;
            todo.userId = Int32.Parse(user_id);
            todo.user = _context.Users.Find(todo.userId);
            _context.Todos.Update(todo);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user_id = HttpContext.Request.Cookies["user_id"];
            if (user_id == null)
            {
                return Unauthorized();
            }
            var task = _context.Todos.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            _context.Todos.Remove(task);
            _context.SaveChanges();
            return Ok(task);
        }
        [HttpGet]
        [Route("GetTaskById/{id}")]
        public IActionResult GetTaskById(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }
    }
}
