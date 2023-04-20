
using Task = שיעור_2.Models.Task;
using  שיעור_2.Models;
using   שיעור_2.Utilities;
using  שיעור_2.Interfaces;
using System.IO;
using System.Text.Json;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace שיעור_2.Services;
public class UserService: UserInterface
{
        List<User> users{ get; }=new List<User>();
 

    private IWebHostEnvironment  webHost;
        private string filePath;
        public UserService(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
            this.filePath = Path.Combine(webHost.ContentRootPath, "data", "user.json");
             using (var jsonFile = File.OpenText(this.filePath))
            {
                List<User>?temp = JsonSerializer.Deserialize<List<User>>(jsonFile.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                if(temp!=null)
                {
                    this.users=temp;
                    System.Console.WriteLine("in f");
                }
            }
        }
        private void saveList(List<User>list)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(users));
        }
          public  List<User> Get()
       {
        Console.Write("in ser");
        return users;
       }
       public User? Get(string id)
       {
          User? user = users.FirstOrDefault(t => t.Id == id);
          return user;
       }
        public User Post(User user)
        {
            user.Id = users.Max(t => t.Id) + 1;
            users.Add(user);
            saveList(users);
            return user;
        }

        public  bool Put(string id, User newUser)
        {
            if (newUser.Id != id)
                return false;
            
            var user = users.FirstOrDefault(p => p.Id == id);
           if(user!=null)
           {
             user.Username=newUser.Username;
             user.Password=newUser.Password;
            saveList(users);
            return true;
            }
            return false;
        }

        public  bool Delete(string id)
        {
            var user = users.FirstOrDefault(t => t.Id == id);
            if (user == null)
                return false;
            users.Remove(user);
            saveList(users);
            return true;
        }

    public User Login(User user)
    {
      User temp=users.FirstOrDefault(u=>u.Password==user.Password&&u.Username==user.Username);
    return temp;
    }
}