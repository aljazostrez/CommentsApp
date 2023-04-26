using System.ComponentModel.DataAnnotations;

namespace CommentsApp.Application.Users.Dtos
{
    public class InsertUserDto
    {
        [Required] public string Name { get; set; }
        [Required] public string Email { get; set; }
    }
}
