using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto.tcc.order.managament.domain.Aggregates.OrderAggregate;

namespace projeto.tcc.order.managament.data.Mappings.DataBase
{
    public class OrderTypeMap : IEntityTypeConfiguration<OrderType>
    {
        public void Configure(EntityTypeBuilder<OrderType> builder)
        {
            builder.ToTable("OrderType");
            builder.HasKey(oderType => oderType.Id);

            builder.Property<int>(oderType => oderType.Id)
                   .HasDefaultValue(1)
                   .ValueGeneratedNever()
                   .IsRequired()
                   .HasColumnName("Id");

            builder.Property<string>(oderType => oderType.Name)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasColumnName("Type");

        }
    }
}
