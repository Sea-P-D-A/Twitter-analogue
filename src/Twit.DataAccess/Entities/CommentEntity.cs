using Twit.DataAccess.Entities.Primitives;

namespace Twit.DataAccess.Entities;

public class CommentEntity : BaseEntity
{
    public string Text { get; set; }                   // Текст комментария
    public DateTime PublishedDate { get; set; }        // Дата публикации
    
    // Статус комментария (Active, Hidden, Deleted)
    public Status Status { get; set; }
    
    // К какому посту комментарий
    public int PostId { get; set; }
    public PostEntity Post { get; set; }
    
    // Автор комментария
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    // Лайки на комментарий
    public ICollection<LikeEntity> Likes { get; set; }
}