using Microsoft.AspNetCore.Mvc;
using Task = שיעור_2.Models.Task;
using User = שיעור_2.Models.User;
using שיעור_2.Models;
using שיעור_2.Interfaces;
using שיעור_2.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace שיעור_2.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
 private UserInterface UserService;
 public UserController(UserInterface UserS)
 {
    this.UserService=UserS;
 }
 [HttpPost]
 [Route("[action]")]
    public ActionResult<String> Login([FromBody] User User)
    {
      
        User? authUser=UserService.Login(User);
        if(authUser==null)
        return Unauthorized();
        var claims=new List<Claim>
        {
            new Claim("type",authUser.Kind),
            new Claim("Id",authUser.Id)
        };
        var token = TokenService.GetToken(claims);
        return new OkObjectResult(TokenService.WriteToken(token));

    }
  [HttpGet]
    [Authorize(Policy = "Admin")]
    public List<User>Get()
    {
        return UserService.Get();
    }

  //    var token = HttpContext.Request.Headers["Aouthorize"];
    //     string id = TokenService.DecodeToken(token!);
    [HttpGet]
    [Route("GetUser")]
    [Authorize(Policy = "Admin")]
    public ActionResult<User> GetUser(string id)
    {
        var user = UserService.Get(id);
        if (user == null)
            return NotFound();
        return user;
    }
     [HttpPost]
    [Authorize(Policy = "Admin")]
   
    public ActionResult Post(User user)
    {
        UserService.Post(user);

        return CreatedAtAction(nameof(Post), new { id = user.Id }, user);
    }

     [HttpPut("{id}")]
    [Authorize(Policy = "Admin")]

    public ActionResult Put(string id, User task)
    {
        if (!UserService.Put(id, task))
            return BadRequest();
        return NoContent();
    }

    [HttpDelete]
    [Authorize(Policy = "Admin")]
    public ActionResult Delete()
    {
        string? token = HttpContext.Request.Headers["Authorization"];
        string id = TokenService.DecodeToken(token!);
        if (!UserService.Delete(id))
            return NotFound();
        return NoContent();
    }
}



