using CommentsApp.Application.Comments;
using CommentsApp.Application.Comments.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommentsApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<UserCommentDto>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await _commentsService.GetAllUserComments();
            return Ok(result);
        }
    }
}
