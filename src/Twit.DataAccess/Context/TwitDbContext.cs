using Microsoft.EntityFrameworkCore;
using Twit.DataAccess.Entities;



namespace Twit.DataAccess.Context;

public class TwitDbContext : DbContext
{
    public TwitDbContext(DbContextOptions<TwitDbContext> options) : base(options)
    {
    }

    // DbSet для всех сущностей
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<LikeEntity> Likes { get; set; }
    public DbSet<MediaEntity> Media { get; set; }
    public DbSet<SubscriptionEntity> Subscriptions { get; set; }
    public DbSet<BlockEntity> Blocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //попытаться убрать после тестов
        base.OnModelCreating(modelBuilder);
        
        // конфигурации
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(TwitDbContext).Assembly);
        
        // Настройка enum'ов для сохранения как int в БД
        modelBuilder.Entity<UserEntity>()
            .Property(u => u.Role)
            .HasConversion<int>();
            
        modelBuilder.Entity<PostEntity>()
            .Property(p => p.Status)
            .HasConversion<int>();
            
        modelBuilder.Entity<CommentEntity>()
            .Property(c => c.Status)
            .HasConversion<int>();
    }
}