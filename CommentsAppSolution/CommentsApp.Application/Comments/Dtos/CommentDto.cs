using CommentsApp.Core;

namespace CommentsApp.Application.Comments.Dtos
{
    public class CommentDto
    {
        public CommentDto(Comment comment)
        {
            Id = comment.Id;
            UserId = comment.UserId;
            Text = comment.Text;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}
