using System.ComponentModel.DataAnnotations;

namespace CommentsApp.Application.Comments.Dtos
{
    public class InsertCommentDto
    {
        [Required] public string Text { get; set; }
    }
}
