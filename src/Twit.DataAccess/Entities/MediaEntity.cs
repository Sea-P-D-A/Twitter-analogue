using Twit.DataAccess.Entities.Primitives;

namespace Twit.DataAccess.Entities;

public class MediaEntity : BaseEntity
{
    //public string FileType { get; set; }           // "image/jpeg", "image/png"
    public MediaFileType FileType { get; set; }

    public string FileUrl { get; set; }            // URL или путь к файлу
    public int DisplayOrder { get; set; }          // Порядок отображения
    
    // К какому посту относится медиа (если это медиа поста)
    public int? PostId { get; set; }
    public PostEntity Post { get; set; }
    // К какому посту относится медиа

    
    // Если это аватар пользователя - обратная связь
    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
}