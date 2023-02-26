using  שיעור_2.Models;
using System.Collections.Generic;
using System.Linq;
using Task = שיעור_2.Models.Task;

namespace שיעור_2.Controllers
{
    public class TaskService
    {
        private static List<Task> tasks =new List<Task>
        {
            new Task{Id=1,Description="to do hw in Java",IsDone=false},
            new Task{Id=2,Description="to bake a cake",IsDone=true},
            new Task{Id=3,Description="to do shopping",IsDone=false},
            new Task{Id=2,Description="to sleep",IsDone=false}
        };
       public static List<Task> GetAll() => tasks;
        public static Task Get(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }

        public static void Add(Task task)
        {
            task.Id = tasks.Max(t => t.Id) + 1;
            tasks.Add(task);
        }

        public static bool Update(int id, Task newTask)
        {
            if (newTask.Id != id)
                return false;
            
            var task = tasks.FirstOrDefault(p => p.Id == id);
            task.Description = newTask.Description;
            task.IsDone = newTask.IsDone;
            return true;
        }

        public static bool Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return false;
            tasks.Remove(task);
            return true;
        }
    }
}