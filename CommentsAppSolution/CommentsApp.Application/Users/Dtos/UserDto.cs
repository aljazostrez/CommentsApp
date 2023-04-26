using CommentsApp.Core;

namespace CommentsApp.Application.Users.Dtos
{
    public class UserDto
    {
        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
