using Twit.DataAccess.Entities.Primitives;

namespace Twit.DataAccess.Entities;

public class PostEntity : BaseEntity
{
    public string Text { get; set; }                   // Текст поста
    public DateTime PublishedDate { get; set; }        // Дата публикации
    public DateTime? EditedDate { get; set; }          // Дата редактирования (может быть null)
    public DateTime? DeletedDate { get; set; }         // Дата удаления (может быть null)
    
    // Статус поста (Active, Hidden, Deleted)
    public Status Status { get; set; }
    
    // Автор поста
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    // Медиа в посте (фото/видео)
    public ICollection<MediaEntity> Media { get; set; }
    
    // Комментарии к посту
    public ICollection<CommentEntity> Comments { get; set; }
    
    // Лайки поста
    public ICollection<LikeEntity> Likes { get; set; }

}