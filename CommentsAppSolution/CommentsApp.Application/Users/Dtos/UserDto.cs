using CommentsApp.Core;

namespace CommentsApp.Application.Users.Dtos
{
    public class UserDto
    {
        public UserDto(User user)
        {
            Name = user.Name;
            Email = user.Email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
