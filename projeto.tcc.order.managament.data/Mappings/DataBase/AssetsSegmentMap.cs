using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto.tcc.order.managament.domain.Aggregates.AssetsAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace projeto.tcc.order.managament.data.Mappings.DataBase
{
    public class AssetsSegmentMap : IEntityTypeConfiguration<AssetsSegment>
    {
        public void Configure(EntityTypeBuilder<AssetsSegment> builder)
        {
            builder.ToTable("AssetsSegment");
            builder.HasKey(assetsSegment => assetsSegment.Id);

            builder.Property<int>(assetsSegment => assetsSegment.Id)
                   .HasDefaultValue(1)
                   .ValueGeneratedNever()
                   .IsRequired()
                   .HasColumnName("Id");

            builder.Property<string>(assetsSegment => assetsSegment.Name)
                   .HasMaxLength(200)
                   .IsRequired()
                   .HasColumnName("Type");

        }
    
    }
}
