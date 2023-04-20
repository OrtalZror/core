using Task = שיעור_2.Models.Task;
using  שיעור_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace שיעור_2.Interfaces;
public interface UserInterface
{
    public User? Login(User user);
     public List<User> Get();
         public User? Get(string id);
         public User Post(User user);
          public bool Put(string id, User user);
           public bool Delete (string id);
}