namespace Twit.DataAccess.Entities;

public class LikeEntity : BaseEntity
{
    // Кто поставил лайк
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    // Лайк на пост (может быть null если лайк на комментарий)
    public int? PostId { get; set; }
    public PostEntity Post { get; set; }
    
    // Лайк на комментарий (может быть null если лайк на пост)
    public int? CommentId { get; set; }
    public CommentEntity Comment { get; set; }
}