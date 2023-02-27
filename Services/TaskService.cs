
using Task = שיעור_2.Models.Task;
using  שיעור_2.Models;
using   שיעור_2.Utilities;
using  שיעור_2.Interfaces;


namespace שיעור_2.Services;

    public class TaskService:TaskInterface
    {
        private  List<Task> tasks =new List<Task>
        {
            new Task{Id=1,Description="to do hw in Java",IsDone=false},
            new Task{Id=2,Description="to bake a cake",IsDone=true},
            new Task{Id=3,Description="to do shopping",IsDone=false},
            new Task{Id=2,Description="to sleep",IsDone=false}
        };
       public  List<Task> Get()
       {
        return tasks;
       }
        public  Task Get(int id)
        {
          Task task=tasks.FirstOrDefault(t => t.Id == id);
             return task;
        }

        public Task Post(Task task)
        {
            task.Id = tasks.Max(t => t.Id) + 1;
            tasks.Add(task);
            return task;
        }

        public  bool Put(int id, Task newTask)
        {
            if (newTask.Id != id)
                return false;
            
            var task = tasks.FirstOrDefault(p => p.Id == id);
            task.Description = newTask.Description;
            task.IsDone = newTask.IsDone;
            return true;
        }

        public  bool Delete(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return false;
            tasks.Remove(task);
            return true;
        }

}
