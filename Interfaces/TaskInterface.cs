
using Task = שיעור_2.Models.Task;
using  שיעור_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace שיעור_2.Interfaces;

      
      public interface TaskInterface
      {
        public List<Task> Get();
         public Task Get(int id);
         public Task Post(Task task);
          public bool Put(int id, Task task);
           public bool Delete (int id);
      
}
