
using Task = שיעור_2.Models.Task;
using  שיעור_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace שיעור_2.Interfaces;

      
      public interface TaskInterface
      {
        public List<Task> Get();
         public List<Task> Get(string token);
         public Task Post(Task task);
          public bool Put(string id, Task task);
           public bool Delete (string id);
      
}
