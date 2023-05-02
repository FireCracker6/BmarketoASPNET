using BMarketo_API.Helpers.Services;
using BMarketo_API.Models.DTO;
using BMarketo_API.Models.Schemas;
using Microsoft.AspNetCore.Mvc;


namespace BMarketo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
          return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetUser([FromQuery] string? id, [FromQuery] string? email)
        {
            User user = null!;

            if (!string.IsNullOrEmpty(id)) 
               user = await _userService.GetAsync(x => x.Id == id);


            else if (!string.IsNullOrEmpty(email))
                user = await _userService.GetAsync(x => x.Email == email);

            if (user != null)
            return Ok(user);

            return NotFound();
        }

     

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRegisterSchema userRegisterSchema)
        {

            if (ModelState.IsValid)
            {
                if (await _userService.UserExistsAsync(x => x.Email == userRegisterSchema.Email))
                    return Conflict("User with the same email address already exists");

               
                if (await _userService.RegisterAsync(userRegisterSchema))
                {
                   var user = await _userService.GetAsync(x => x.Email == userRegisterSchema.Email);
                    return Created($"https://domain.com/api/users/{user.Id}", user );
                }
                  

                ModelState.AddModelError("", "Something went wrong. Please contact support.");
            }
             return BadRequest(userRegisterSchema);
         
        }

    }
}
