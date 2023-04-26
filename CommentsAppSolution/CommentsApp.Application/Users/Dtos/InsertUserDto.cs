using System.ComponentModel.DataAnnotations;

namespace CommentsApp.Application.Users.Dtos
{
    public class InsertUserDto
    {
        [Required] public string Name { get; set; }
        [Required, EmailAddress] public string Email { get; set; }
    }
}
