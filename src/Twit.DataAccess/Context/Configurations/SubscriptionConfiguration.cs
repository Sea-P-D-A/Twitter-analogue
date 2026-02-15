using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Twit.DataAccess.Entities;

namespace Twit.DataAccess.Context.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<SubscriptionEntity>
{
    public void Configure(EntityTypeBuilder<SubscriptionEntity> e)
    {
        e.HasKey(s => s.Id);
        e.HasIndex(s => s.ExternalId).IsUnique();
        
        // Уникальная подписка (чтобы нельзя было подписаться дважды)
        e.HasIndex(s => new { s.SubscriberId, s.TargetUserId })
            .IsUnique();
    }
}