using CommentsApp.Application.Users.Dtos;
using CommentsApp.Core;
using CommentsApp.EFCore;
using Microsoft.EntityFrameworkCore;

namespace CommentsApp.Application.Users
{
    public class UsersService : IUsersService
    {
        private CommentsAppDbContext _dbContext;

        public UsersService(CommentsAppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<List<UserDto>> GetAll()
        {
            return await _dbContext.Users.Select(x => new UserDto(x)).ToListAsync();
        }

        public async Task<UserDto> Insert(InsertUserDto insertUser)
        {
            // check if an user with the same email already exists
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == insertUser.Email);
            if (existingUser != null)
                throw new Exception("User with this email already exists.");

            // insert user in DB
            var user = await _dbContext.Users.AddAsync(new User
            {
                Name = insertUser.Name,
                Email = insertUser.Email
            });
            await _dbContext.SaveChangesAsync();

            // returning user as UserDto
            return new UserDto(user.Entity);
        }

        public async Task<int> Delete(int id)
        {
            // find the user with id to delete
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
                throw new Exception($"User with id {id} does not exists.");

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return id;

        }
    }
}
