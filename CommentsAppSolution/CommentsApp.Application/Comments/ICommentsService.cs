using CommentsApp.Application.Comments.Dtos;

namespace CommentsApp.Application.Comments
{
    public interface ICommentsService
    {
        Task<List<UserCommentDto>> GetAllUserComments();
        Task<List<CommentDto>> GetCommentsByUserId(int userId);
        Task<CommentDto> InsertCommentForUser(int userId, InsertCommentDto insertComment);
        Task<int> DeleteCommentByIdAndUserId(int commentId, int userId);
        Task<List<int>> DeleteAllCommentsForUser(int userId);
    }
}
