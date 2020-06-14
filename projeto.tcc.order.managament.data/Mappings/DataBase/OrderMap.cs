using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto.tcc.order.managament.domain;
using projeto.tcc.order.managament.domain.Aggregates.OrderAggregate;
using System;

namespace projeto.tcc.order.managament.data.Mappings.DataBase
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(order => order.Id);

            builder.Property(order => order.Id)
                    .HasDefaultValue(Guid.NewGuid());

            builder.Property<Guid>(order => order.AssetId)
                    .HasColumnName("AssetId")
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .IsRequired();

            builder.Property<Guid>("_userId")
                         .HasColumnName("UserId")
                         .UsePropertyAccessMode(PropertyAccessMode.Field)
                         .IsRequired();


            builder.Property<decimal>("_value")
                    .HasColumnName("Value")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired();

            builder.Property<int>("_amount")
                             .HasColumnName("Amount")
                            .UsePropertyAccessMode(PropertyAccessMode.Field)
                            .IsRequired();

            builder.Property<int>("_orderTypeId")
                   .HasColumnName("OrderTypeId")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .IsRequired();


            var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderActive));

            // DDD Patterns comment:
            //Set as field (New since EF 1.1) to access the OrderItem collection property through its field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasOne(order => order.OrderType)
                   .WithMany()
                   .HasForeignKey("_orderTypeId")
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Assets>()
                   .WithMany()
                   .HasForeignKey("AssetId")
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(order => order.DomainEvents);

        }
    }
}
