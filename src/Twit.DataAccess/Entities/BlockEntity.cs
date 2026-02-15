namespace Twit.DataAccess.Entities;

public class BlockEntity : BaseEntity
{
    public DateTime BlockDate { get; set; }        // Дата блокировки
    public string Reason { get; set; }             // Причина блокировки
    public DateTime ValidUntil { get; set; }       // Действует до
    
    // Кем выдана (имя админа/модератора)
    public int BlockedById { get; set; }
    public UserEntity BlockedBy { get; set; }

    
    // Кого блокируют
    public int BlockedUserId { get; set; }
    public UserEntity BlockedUser { get; set; }
}