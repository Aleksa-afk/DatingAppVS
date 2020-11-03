using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] //return all users, no need for list since we don't need to do anything with the returned results so IEnumerable is more appropriate.
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")] //Get individual users by ID. ex: api/users/3
        public async Task<ActionResult<AppUser>>  GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
