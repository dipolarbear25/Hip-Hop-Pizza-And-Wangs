﻿// <auto-generated />
using System;
using HHPW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hip_Hop_Pizza_and_Wangs.Migrations
{
    [DbContext(typeof(HipHopPizzaAndWangsDbContext))]
    partial class HipHopPizzaAndWangsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HHPW.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Small batch of Wings",
                            Price = 15
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium batch of Wings",
                            Price = 20
                        });
                });

            modelBuilder.Entity("HHPW.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<int>("Tip")
                        .HasColumnType("integer");

                    b.Property<int>("Total")
                        .HasColumnType("integer");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2024, 4, 19, 19, 40, 5, 315, DateTimeKind.Local).AddTicks(2921),
                            Email = "mangumaustin@gmail.com",
                            Name = "Austin",
                            PaymentType = "Debit",
                            PhoneNum = "931-999-0000",
                            Status = true,
                            Tip = 5,
                            Total = 20,
                            Uid = "zN5lhMboI3Sv4UwtErkrlHlvPfn2"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2024, 4, 19, 19, 40, 5, 316, DateTimeKind.Local).AddTicks(7032),
                            Email = "mangumbria@gmail.com",
                            Name = "Bria",
                            PaymentType = "Cash",
                            PhoneNum = "931-999-0000",
                            Status = false,
                            Tip = 5,
                            Total = 20,
                            Uid = "2"
                        });
                });

            modelBuilder.Entity("HHPW.Models.OrderItemDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItemDto");
                });

            modelBuilder.Entity("HHPW.Models.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Credit"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Debit"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Phone"
                        });
                });

            modelBuilder.Entity("HHPW.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Austin Mangum",
                            Uid = ""
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bria M",
                            Uid = ""
                        });
                });

            modelBuilder.Entity("HHPW.Models.OrderItemDto", b =>
                {
                    b.HasOne("HHPW.Models.Item", "Item")
                        .WithMany("Order")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HHPW.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("HHPW.Models.Item", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("HHPW.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
