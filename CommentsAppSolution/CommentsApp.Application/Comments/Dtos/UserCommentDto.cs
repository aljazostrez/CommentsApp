using CommentsApp.Core;

namespace CommentsApp.Application.Comments.Dtos
{
    public class UserCommentDto
    {
        public UserCommentDto(Comment comment)
        {
            UserId = comment.User.Id;
            UserName = comment.User.Name;
            UserEmail = comment.User.Email;

            CommentId = comment.Id;
            CommentText = comment.Text;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public int CommentId { get; set; }
        public string CommentText { get; set; }
    }
}
