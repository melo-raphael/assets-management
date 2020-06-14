using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto.tcc.order.managament.domain;
using projeto.tcc.order.managament.domain.Aggregates.AssetsAggregate;
using System;

namespace projeto.tcc.order.managament.data.Mappings.DataBase
{
    public class AssetsMap : IEntityTypeConfiguration<Assets>
    {
        public void Configure(EntityTypeBuilder<Assets> builder)
        {
            builder.ToTable("Assets");

            builder.HasKey(assets => assets.Id);

            builder.Property(assets => assets.Id)
                    .HasDefaultValue(Guid.NewGuid());

            builder.Property<string>(asseets => asseets.Name)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .IsRequired();

            builder.Property<string>(assets => assets.Symbol)
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired();


            builder.Property<string>(assets => assets.ImageUrl)
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired();


            builder.Property<int>(assets => assets.SegmentId)
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .HasColumnName("SegmentId")
                   .IsRequired();

            builder.HasOne(asset => asset.AssetsSegment)
                             .WithMany()
                             .IsRequired()
                             //.HasForeignKey("_segmentId")
                             .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(assets => assets.DomainEvents);

        }
    }
}
