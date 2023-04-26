using CommentsApp.Application.Users;
using CommentsApp.Application.Users.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommentsApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService= usersService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<UserDto>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usersService.GetAll();
            return Ok(result);
        }

        //// GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertUserDto insertUser)
        {
            var result = await _usersService.Insert(insertUser);
            return Created("", result);
        }

        //// PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _usersService.Delete(id);
            return Ok(result);
        }
    }
}
