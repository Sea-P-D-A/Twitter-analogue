using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twit.DataAccess.Entities;

namespace Twit.DataAccess.Context.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
{
    public void Configure(EntityTypeBuilder<PostEntity> e)
    {
        e.HasKey(p => p.Id);
        e.HasIndex(p => p.ExternalId).IsUnique();
        
        e.Property(p => p.Text).HasMaxLength(1000);
        
        e.HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId);
            
        e.HasMany(p => p.Likes)
            .WithOne(l => l.Post)
            .HasForeignKey(l => l.PostId);
            
        e.HasMany(p => p.Media)
            .WithOne(m => m.Post)
            .HasForeignKey(m => m.PostId);
    }
}