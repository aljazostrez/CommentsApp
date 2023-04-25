namespace CommentsApp.Application.Users
{
    public interface IUsersService
    {
        Task<List<UserDto>> GetAllUsers(); 
    }
}
