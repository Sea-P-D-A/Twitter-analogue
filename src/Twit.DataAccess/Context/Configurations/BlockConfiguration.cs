using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twit.DataAccess.Entities;

namespace Twit.DataAccess.Context.Configurations;

public class BlockConfiguration : IEntityTypeConfiguration<BlockEntity>
{
    public void Configure(EntityTypeBuilder<BlockEntity> e)
    {
        e.HasKey(b => b.Id);
        e.HasIndex(b => b.ExternalId).IsUnique();
        e.Property(b => b.Reason).HasMaxLength(500);
        
        // Явно указываем связи
        e.HasOne(b => b.BlockedBy)
            .WithMany()  // У пользователя может быть много выданных блокировок
            .HasForeignKey(b => b.BlockedById)
            .OnDelete(DeleteBehavior.Restrict);        
        // Связь с пользователем, которого блокируют
        e.HasOne(b => b.BlockedUser)
            .WithMany(u => u.Blocks)
            .HasForeignKey(b => b.BlockedUserId);
    }
}