
using Task = שיעור_2.Models.Task;
using  שיעור_2.Models;
using   שיעור_2.Utilities;
using  שיעור_2.Interfaces;
using System.IO;
using System.Text.Json;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace שיעור_2.Services;
  
    public class TaskService:TaskInterface
    { 
    

         List<Task> tasks{ get; }=new List<Task>();
 

    private IWebHostEnvironment  webHost;
        private string filePath;
        public TaskService(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
            this.filePath = Path.Combine(webHost.ContentRootPath, "data", "task.json");
             using (var jsonFile = File.OpenText(this.filePath))
            {
                List<Task>?temp = JsonSerializer.Deserialize<List<Task>>(jsonFile.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if(temp!=null)
                {
                    this.tasks=temp;
                }
            }
        }
         static string idToken;
        private void saveList(List<Task>list)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(tasks));
        }
        
       public  List<Task> Get()
       {
        return tasks;
       }
       public List<Task>Get(string token)
       {
        string id=TokenService.DecodeToken(token);
        List<Task>tasksFilter=tasks.Where(t=>t.userId==id).ToList();
        return tasksFilter;
       }
       
        public Task Post(Task task)
        {
            task.Id = tasks.Max(t => t.Id) + 1;
            tasks.Add(task);
            saveList(tasks);
            return task;
            
        }

        public  bool Put(string id, Task newTask)
        {
            if (newTask.Id != id)
                return false;
            
            var task = tasks.FirstOrDefault(p => p.Id == id);
           if(task!=null)
           {
            task.Description = newTask.Description;
            task.IsDone = newTask.IsDone;
            saveList(tasks);
            return true;
            }
            return false;
        }

        public  bool Delete(string id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return false;
            tasks.Remove(task);
            saveList(tasks);
            return true;
        }

    


}
