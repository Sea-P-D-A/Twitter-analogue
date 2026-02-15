using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twit.DataAccess.Entities;

namespace Twit.DataAccess.Context.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> e)
    {
        e.HasKey(u => u.Id);
        e.HasIndex(u => u.ExternalId).IsUnique();
        
        e.Property(u => u.Username).HasMaxLength(50);
        e.Property(u => u.UniqueName).HasMaxLength(50);
        e.Property(u => u.Email).HasMaxLength(100);
        
        e.HasMany(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
            
        e.HasMany(u => u.Subscriptions)
            .WithOne(s => s.Subscriber)
            .HasForeignKey(s => s.SubscriberId);
            
        e.HasMany(u => u.Subscribers)
            .WithOne(s => s.TargetUser)
            .HasForeignKey(s => s.TargetUserId);
    }
}