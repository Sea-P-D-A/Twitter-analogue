using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twit.DataAccess.Entities;

namespace Twit.DataAccess.Context.Configurations;

public class LikeConfiguration : IEntityTypeConfiguration<LikeEntity>
{
    public void Configure(EntityTypeBuilder<LikeEntity> e)
    {
        e.HasKey(l => l.Id);
        e.HasIndex(l => l.ExternalId).IsUnique();
        
        // Проверка: лайк должен быть либо на пост, либо на комментарий
        //e.HasCheckConstraint("CH_likes_post_or_comment", 
          //  "(\"PostId\" IS NOT NULL AND \"CommentId\" IS NULL) OR (\"PostId\" IS NULL AND \"CommentId\" IS NOT NULL)");
    }
}