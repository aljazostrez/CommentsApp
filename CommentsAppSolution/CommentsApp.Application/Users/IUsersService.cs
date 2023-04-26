using CommentsApp.Application.Users.Dtos;

namespace CommentsApp.Application.Users
{
    public interface IUsersService
    {
        Task<List<UserDto>> GetAll();
        Task<UserDto> Insert(InsertUserDto insertUser);
        Task<int> Delete(int id);
    }
}
