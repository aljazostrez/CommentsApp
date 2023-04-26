using CommentsApp.Application.Comments;
using CommentsApp.Application.Comments.Dtos;
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
        private readonly ICommentsService _commentsService;

        public UsersController(IUsersService usersService, ICommentsService commentsService)
        {
            _usersService= usersService;
            _commentsService= commentsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<UserDto>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usersService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(UserDto))]
        public async Task<IActionResult> InsertUser([FromBody] InsertUserDto insertUser)
        {
            var result = await _usersService.Insert(insertUser);
            return Created("", result);
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(200, Type = typeof(int))]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _usersService.Delete(userId);
            return Ok(result);
        }

        [HttpGet("{userId}/comments")]
        [ProducesResponseType(200, Type = typeof(List<CommentDto>))]
        public async Task<IActionResult> GetAllCommentsForUser(int userId)
        {
            var result = await _commentsService.GetCommentsByUserId(userId);
            return Ok(result);
        }

        [HttpPost("{userId}/comments")]
        [ProducesResponseType(200, Type = typeof(CommentDto))]
        public async Task<IActionResult> GetAllCommentsForUser(int userId, [FromBody] InsertCommentDto insertComment)
        {
            var result = await _commentsService.InsertCommentForUser(userId, insertComment);
            return Ok(result);
        }

        [HttpDelete("{userId}/comments")]
        [ProducesResponseType(200, Type = typeof(List<int>))]
        public async Task<IActionResult> DeleteAllCommentsForUser(int userId)
        {
            var result = await _commentsService.DeleteAllCommentsForUser(userId);
            return Ok(result);
        }

        [HttpDelete("{userId}/comments/{commentId}")]
        [ProducesResponseType(200, Type = typeof(List<int>))]
        public async Task<IActionResult> DeleteCommentForUserById(int userId, int commentId)
        {
            var result = await _commentsService.DeleteCommentByIdAndUserId(commentId, userId);
            return Ok(result);
        }
    }
}
