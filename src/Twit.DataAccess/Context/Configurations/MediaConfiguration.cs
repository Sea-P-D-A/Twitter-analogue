using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twit.DataAccess.Entities;

namespace Twit.DataAccess.Context.Configurations;

public class MediaConfiguration : IEntityTypeConfiguration<MediaEntity>
{
    public void Configure(EntityTypeBuilder<MediaEntity> e)
    {
        e.HasKey(m => m.Id);
        e.HasIndex(m => m.ExternalId).IsUnique();
        
        e.Property(m => m.FileType).HasMaxLength(50);
        e.Property(m => m.FileUrl).HasMaxLength(500);
        
        // Связь с постом (опционально)
        e.HasOne(m => m.Post)
            .WithMany(p => p.Media)
            .HasForeignKey(m => m.PostId)
            .IsRequired(false); // Медиа может быть без поста (аватар)
    }
}