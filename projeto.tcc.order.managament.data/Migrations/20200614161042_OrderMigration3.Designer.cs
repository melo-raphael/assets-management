﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using projeto.tcc.order.managament.data.Context;

namespace projeto.tcc.order.managament.data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200614161042_OrderMigration3")]
    partial class OrderMigration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("projeto.tcc.order.managament.domain.Aggregates.AssetsAggregate.AssetsSegment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Type")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("AssetsSegment");
                });

            modelBuilder.Entity("projeto.tcc.order.managament.domain.Aggregates.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("e0645829-6560-4e0a-9612-31481197f553"));

                    b.Property<Guid>("AssetId")
                        .HasColumnName("AssetId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OrderActiveId")
                        .HasColumnType("uuid");

                    b.Property<int>("_amount")
                        .HasColumnName("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("_orderTypeId")
                        .HasColumnName("OrderTypeId")
                        .HasColumnType("integer");

                    b.Property<Guid>("_userId")
                        .HasColumnName("UserId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("_value")
                        .HasColumnName("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("OrderActiveId");

                    b.HasIndex("_orderTypeId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("projeto.tcc.order.managament.domain.Aggregates.OrderAggregate.OrderActive", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("_activeAmount")
                        .HasColumnName("ActiveAmount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("_updateAt")
                        .HasColumnName("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("OrderActive");
                });

            modelBuilder.Entity("projeto.tcc.order.managament.domain.Aggregates.OrderAggregate.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Type")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("OrderType");
                });

            modelBuilder.Entity("projeto.tcc.order.managament.domain.Assets", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValue(new Guid("9f905251-9a5e-4b29-9ea9-49a85eee4cbe"));

                    b.Property<int>("AssetsSegmentId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SegmentId")
                        .HasColumnName("SegmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AssetsSegmentId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("projeto.tcc.order.managament.domain.Aggregates.OrderAggregate.Order", b =>
                {
                    b.HasOne("projeto.tcc.order.managament.domain.Assets", null)
                        .WithMany()
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("projeto.tcc.order.managament.domain.Aggregates.OrderAggregate.OrderActive", "OrderActive")
                        .WithMany()
                        .HasForeignKey("OrderActiveId");

                    b.HasOne("projeto.tcc.order.managament.domain.Aggregates.OrderAggregate.OrderType", "OrderType")
                        .WithMany()
                        .HasForeignKey("_orderTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("projeto.tcc.order.managament.domain.Assets", b =>
                {
                    b.HasOne("projeto.tcc.order.managament.domain.Aggregates.AssetsAggregate.AssetsSegment", "AssetsSegment")
                        .WithMany()
                        .HasForeignKey("AssetsSegmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}