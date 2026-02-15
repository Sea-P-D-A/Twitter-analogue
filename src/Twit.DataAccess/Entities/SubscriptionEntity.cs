namespace Twit.DataAccess.Entities;

public class SubscriptionEntity : BaseEntity
{
    public DateTime SubscriptionDate { get; set; } //возможно не нужна тк у нас есть в базовом классе

    // Кто подписывается (подписчик)
    public int SubscriberId { get; set; }
    public UserEntity Subscriber { get; set; }
    
    // На кого подписываются
    public int TargetUserId { get; set; }
    public UserEntity TargetUser { get; set; }
    
}