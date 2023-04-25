using System.ComponentModel.DataAnnotations.Schema;

namespace CommentsApp.Core
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }

        [ForeignKey(nameof(UserId))] public User User { get; set; }
    }
}
