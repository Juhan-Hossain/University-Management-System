using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly ApplicationDbContext Context;
        public UsersController(ApplicationDbContext dbContext)
        {
            Context = dbContext;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await Context.Users.ToListAsync();
        }


       
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var p = id;

            return await Context.Users.FindAsync(id);
        }





    }
}
