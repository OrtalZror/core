

using Microsoft.AspNetCore.Mvc;

namespace שיעור_2.Controllers
{
      public interface TaskInterface
      {
        public IEnumerable<Task> Get();
         public ActionResult<Task> Get(int id);
         public ActionResult Post(Task task);
          public ActionResult Put(int id, Task task);
           public ActionResult Delete (int id);
      }
}