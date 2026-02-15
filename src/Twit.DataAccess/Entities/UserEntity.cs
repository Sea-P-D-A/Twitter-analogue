using Twit.DataAccess.Entities.Primitives;
using System.ComponentModel.DataAnnotations.Schema;


namespace Twit.DataAccess.Entities;

[Table("Users")]
public class UserEntity : BaseEntity
{
    public string Username { get; set; }
    public string UniqueName { get; set; }
    public string Email { get; set; }
    public DateTime AccountCreatedDate { get; set; }
    public Role Role { get; set; }

    // Связи с другими сущностями (позже добавим)
    public int? MediaId { get; set; }
    //public MediaEntity Avatar { get; set; }
    
    // Navigation properties (позже раскомментируем)
    public ICollection<SubscriptionEntity> Subscriptions { get; set; }     // На кого Я подписан
    public ICollection<SubscriptionEntity> Subscribers { get; set; }       // Кто подписан на меня
    public ICollection<BlockEntity> Blocks { get; set; }                   // Блокировки
    public ICollection<PostEntity> Posts { get; set; }                  // Мои посты
    public ICollection<CommentEntity> Comments { get; set; }            // Мои комментарии
    public ICollection<LikeEntity> Likes { get; set; }                  // Мои лайки
    
}