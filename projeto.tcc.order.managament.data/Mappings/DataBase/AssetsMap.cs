using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto.tcc.order.managament.domain;
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


            builder.Property<string>(assets => assets.Segment)
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired();

            builder.Ignore(assets => assets.DomainEvents);

        }
    }
}
