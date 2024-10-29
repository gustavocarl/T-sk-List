using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_List.Data.Implementation;
using Task_List.Dtos;
using Task_List.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_List.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskDBContext _context;

        public TasksController(TaskDBContext context)
        {
            _context = context;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(tasks);
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return task!;
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<ActionResult<Tasks>> CreateTask(Tasks task)
        {
            if (task == null)
                return BadRequest();

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateTasksDto>> Put(int id, UpdateTasksDto task)
        {
            var existingTask = await _context.Tasks.FindAsync(id);

            if (existingTask == null)
            {
                return BadRequest("Task not found");
            }

            _context.Entry(existingTask).CurrentValues.SetValues(task);
            // Update the task as needed
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tasks>> Delete(int id)
        {
            var existingTask = await _context.Tasks.FindAsync(id);

            if (existingTask == null)
            {
                return BadRequest("Task not found");
            }

            _context.Remove(existingTask);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}