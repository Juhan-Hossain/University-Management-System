using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University_Student_Management.Controllers
{
   
    public class ApplicationUserController : BaseApiController
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public ApplicationUserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        //POST:/api/ApplicationUser/Register:
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var ApplicationUser = new User()
            {
                UserName = model.UserName,
                Email=model.Email,
                FirstName=model.FirstName,
                LastName=model.LastName
            };

            try
            {
                var result = await _userManager.CreateAsync(ApplicationUser, model.Password);
                if (result.Succeeded) return Ok(result);
                else return BadRequest(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }




    }
}
