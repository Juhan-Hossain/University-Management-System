using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementDAL;
using StudentManagementEntity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using University_Student_Management.Controllers;
using University_Student_Management.Interfaces;

namespace StudentManagementEntity
{
    public class AccountController : BaseApiController
    {
        private readonly ApplicationDbContext Context;
        private readonly ITokenService _tokenService;

        public AccountController(ApplicationDbContext dbContext,ITokenService tokenService)
        {
            Context = dbContext;
            this._tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            Context.Users.Add(user);
            await Context.SaveChangesAsync();
            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await Context.Users
                .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);
            /*Console.WriteLine(user);*/
            if (user == null) return Unauthorized("Invalid Username");
           using var hmac = new HMACSHA512(user.PasswordSalt);

            var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            /*for (int i = 0; i < ComputedHash.Length; i++)
            {*/
                if (ComputedHash != user.PasswordHash) return Unauthorized("Invalid password");
            //}
            return new UserDto
            {
                UserName=user.UserName,
                Token=_tokenService.CreateToken(user)
            };
        }


        private async Task<bool> UserExists(string username)
        {
            return await Context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
