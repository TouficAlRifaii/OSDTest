using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportanceController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ImportanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Importances);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Importance importance)
        {
            _context.Importances.Add(importance);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string name)
        {
            var importance = _context.Importances.Find(id);
            if (importance == null)
            {
                return NotFound();
            }
            importance.name = name;
            _context.Importances.Update(importance);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var importance = _context.Importances.Find(id);
            if (importance == null)
            {
                return NotFound();
            }
            _context.Importances.Remove(importance);
            _context.SaveChanges();
            return Ok(importance);
        }
        [HttpGet]
        [Route("GetImportanceById/{id}")]
        public IActionResult GetImportanceById(int id)
        {
            var importance = _context.Importances.Find(id);
            if (importance == null)
            {
                return NotFound();
            }
            return Ok(importance);
        }

    }
}
