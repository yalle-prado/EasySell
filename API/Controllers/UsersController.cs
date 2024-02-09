using System.Collections.Generic;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : BaseApiController
{
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
       _context = context;
    }

    // private readonly DataContext context;
    // public UsersController(DataContext context)
    // {
    //    this.context = context;
    // }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
          var users = await _context.Users.ToListAsync();
          return users;
    }

    [HttpGet("{id}")] // /api/users/2
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    // [HttpPost("{id}")]
    // public ActionResult<AppUser> AddUser( int id, string name)
    // {
    //     var user =
    // }

    // [HttpPost("{id}")]
    // public ActionResult<AppUser> UpdateUser( int id, string name)
    // {
    //     var user =
    // }

}
