using System;
using System.Collections.Generic;
using System.Linq;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task = שיעור_2.Models.Task;

namespace שיעור_2.Controllers
{
  

    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return TaskService.GetAll();
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
            TaskService.Add(task);

            return CreatedAtAction(nameof(Post), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Task task)
        {
            if (!TaskService.Update(id, task))
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
}