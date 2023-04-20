
using Microsoft.AspNetCore.Mvc;
using Task = שיעור_2.Models.Task;
using  שיעור_2.Models;
using  שיעור_2.Interfaces;
using  שיעור_2.Services;
using Microsoft.AspNetCore.Authorization;

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
        // [Authorize(Policy="Admin")]
        public List<Task> Get()
        {
            return TaskService.Get();
        }
        [Route("GetUser")]
        [HttpGet]
        //   [Authorize(Policy="User")]
        public ActionResult <List<Task>> GetUser()
        {
           string token=HttpContext.Request.Headers["Aouthorize"];
           var task=TaskService.Get(token);
            if (task == null)
                return NotFound();
             return task;
        }
        
        [HttpPost]
         [Authorize(Policy="User")]
        public ActionResult Post(Task task)
        {
            TaskService.Post(task);

            return CreatedAtAction(nameof(Post), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        // [Authorize(Policy="User")]
        public ActionResult Put(string id, Task task)
        {
            if (!TaskService.Put(id, task))
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        // [Authorize(Policy="User")]
        public ActionResult Delete (string id)
        {
            if (!TaskService.Delete(id))
                return NotFound();
            return NoContent();            
        }
         }
