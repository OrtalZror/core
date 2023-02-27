
using Microsoft.AspNetCore.Mvc;
using Task = שיעור_2.Models.Task;
using  שיעור_2.Models;
using  שיעור_2.Interfaces;
using  שיעור_2.Services;
namespace שיעור_2.Controllers;

  
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private TaskInterface TaskService;
        public TaskController(TaskInterface task)
        {
            this.TaskService=task;
        }
        [HttpGet]
        public List<Task> Get()
        {
            return TaskService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id)
        {
            var t = TaskService.Get(id);
            if (t == null)
                return NotFound();
             return t;
        }

        [HttpPost]
        public ActionResult Post(Task task)
        {
            TaskService.Post(task);

            return CreatedAtAction(nameof(Post), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Task task)
        {
            if (!TaskService.Put(id, task))
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            if (!TaskService.Delete(id))
                return NotFound();
            return NoContent();            
        }
         }
