using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto.tcc.order.managament.domain.Aggregates.OrderAggregate;
using System;

namespace projeto.tcc.order.managament.data.Mappings.DataBase
{
    public class OrderActiveMap : IEntityTypeConfiguration<OrderActive>
    {
        public void Configure(EntityTypeBuilder<OrderActive> builder)
        {
            builder.ToTable("OrderActive");
            builder.HasKey(orderActive => orderActive.Id);

            builder.Property<DateTime>("_updateAt")
                    .HasColumnName("UpdateAt")
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .IsRequired();

            builder.Property<int>("_activeAmount")
                    .HasColumnName("ActiveAmount")
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .IsRequired();

            builder.Ignore(orderActive => orderActive.DomainEvents);

        }
    }
}
