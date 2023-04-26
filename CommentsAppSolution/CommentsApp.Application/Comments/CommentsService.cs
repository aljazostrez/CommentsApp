using CommentsApp.Application.Comments.Dtos;
using CommentsApp.Core;
using CommentsApp.EFCore;
using Microsoft.EntityFrameworkCore;

namespace CommentsApp.Application.Comments
{
    public class CommentsService : ICommentsService
    {
        private CommentsAppDbContext _dbContext;

        public CommentsService(CommentsAppDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public async Task<List<UserCommentDto>> GetAllUserComments()
        {
            var userComments = await _dbContext.Comments.Include(x => x.User).Select(x => new UserCommentDto(x)).ToListAsync();
            return userComments;
        }

        public async Task<List<CommentDto>> GetCommentsByUserId(int userId)
        {
            // check if user with id exists
            var userExists = await _dbContext.Users.AnyAsync(x => x.Id == userId);
            if (!userExists)
                throw new Exception($"User with id {userId} does not exists.");

            var comments = await _dbContext.Comments.Where(x => x.UserId == userId).Select(x => new CommentDto(x)).ToListAsync();
            return comments;
        }

        public async Task<CommentDto> InsertCommentForUser(int userId, InsertCommentDto insertComment)
        {
            // check if user with id exists
            var userExists = await _dbContext.Users.AnyAsync(x => x.Id == userId);
            if (!userExists)
                throw new Exception($"User with id {userId} does not exists.");

            // insert comment in DB
            var comment = await _dbContext.Comments.AddAsync(new Comment
            {
                UserId = userId,
                Text = insertComment.Text
            });
            await _dbContext.SaveChangesAsync();

            // returning comment as CommentDto
            return new CommentDto(comment.Entity);
        }

        public async Task<int> DeleteCommentByIdAndUserId(int commentId, int userId)
        {
            // check if comment with combination of commentId and userId exists
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == commentId && x.UserId == userId);
            if (comment == null)
                throw new Exception($"Comment with id={commentId} and userId={userId} does not exists.");

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();

            return commentId;
        }

        public async Task<List<int>> DeleteAllCommentsForUser(int userId)
        {
            // check if comment with combination of commentId and userId exists
            var comments = await _dbContext.Comments.Where(x => x.UserId == userId).ToListAsync();
            if (comments.Count == 0)
            {
                // in this case, we do not throw error, just an empty List
                return new List<int>();
            }

            _dbContext.Comments.RemoveRange(comments);
            var commentsDeletedIds = comments.Select(x => x.Id).ToList();
            await _dbContext.SaveChangesAsync();

            return commentsDeletedIds;
        }
    }
}
