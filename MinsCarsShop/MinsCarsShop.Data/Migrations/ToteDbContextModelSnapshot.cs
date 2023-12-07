﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinsCarsShop.Data.EF;

#nullable disable

namespace MinsCarsShop.Data.Migrations
{
    [DbContext(typeof(ToteDbContext))]
    partial class ToteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MinsCarsShop.Data.Models.Cart", b =>
                {
                    b.Property<int>("ToteId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("ToteId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            ToteId = 1,
                            UserId = 1,
                            Amount = 2,
                            IsDeleted = false
                        },
                        new
                        {
                            ToteId = 2,
                            UserId = 1,
                            Amount = 10,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(4563));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(4956));

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "1.jpg",
                            IsDeleted = false,
                            Name = "Canvas Tote"
                        },
                        new
                        {
                            Id = 2,
                            Image = "2.jpg",
                            IsDeleted = false,
                            Name = "Jean Tote"
                        });
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OrderTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeliveryTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4267),
                            OrderTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4266),
                            StatusId = 1,
                            Total = 0m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            DeliveryTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4271),
                            OrderTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4270),
                            StatusId = 2,
                            Total = 0m,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            DeliveryTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4272),
                            OrderTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4272),
                            StatusId = 3,
                            Total = 0m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            DeliveryTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4274),
                            OrderTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4273),
                            StatusId = 4,
                            Total = 0m,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ToteId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("OrderPrice")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ToteId");

                    b.HasIndex("ToteId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ToteId = 1,
                            Amount = 2,
                            OrderPrice = 138000
                        },
                        new
                        {
                            OrderId = 2,
                            ToteId = 2,
                            Amount = 10,
                            OrderPrice = 999000
                        });
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Chưa xử lý"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Đang chuẩn bị"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Đang giao hàng"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Giao hàng thành công"
                        });
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Tote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(5800));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(6190));

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Totes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4076),
                            Image = "1.jpg",
                            IsDeleted = false,
                            Name = "Ha Noi",
                            Price = 9
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4088),
                            Image = "2.jpg",
                            IsDeleted = false,
                            Name = "Women in front of the windown",
                            Price = 9
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreatedTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4089),
                            Image = "4.jpg",
                            IsDeleted = false,
                            Name = "Portal to the Cat Dimension",
                            Price = 9
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            CreatedTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4090),
                            Image = "5.jpg",
                            IsDeleted = false,
                            Name = "Stay Positive",
                            Price = 9
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            CreatedTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4092),
                            Image = "6.jpg",
                            IsDeleted = false,
                            Name = "Couple see the earth",
                            Price = 9
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            CreatedTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4093),
                            Image = "7.jpg",
                            IsDeleted = false,
                            Name = "The Bodacious Period",
                            Price = 9
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 1,
                            CreatedTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4094),
                            Image = "8.jpg",
                            IsDeleted = false,
                            Name = "Hide from reality",
                            Price = 9
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 1,
                            CreatedTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4095),
                            Image = "9.jpg",
                            IsDeleted = false,
                            Name = "Blue purple OLDI",
                            Price = 9
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            CreatedTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4096),
                            Image = "10.jpg",
                            IsDeleted = false,
                            Name = "Purple Elephent angry",
                            Price = 9
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 1,
                            CreatedTime = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4097),
                            Image = "11.jpg",
                            IsDeleted = false,
                            Name = "Bag of Holand",
                            Price = 9
                        });
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("default.png");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("RegisteredDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(7594));

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 10, 16, 9, 22, 11, 597, DateTimeKind.Local).AddTicks(7849));

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "3/2, Ninh Kieu, Can Tho",
                            Avatar = "myAvatar.jpg",
                            Email = "minhkhalectu@gmail.com",
                            Name = "Le Minh Kha",
                            Password = "leminhkha123",
                            Phone = "0398897634",
                            RegisteredDate = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4309),
                            UpdatedDate = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4310)
                        },
                        new
                        {
                            Id = 2,
                            Address = "622/10, phuong 13, Cong Hoa, Tan Binh. Tp. HCM",
                            Avatar = "myChongiu.jpg",
                            Email = "silasnguyen@gmail.com",
                            Name = "Nguyen Tung Lam",
                            Password = "chongiu23",
                            Phone = "0338307449",
                            RegisteredDate = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4311),
                            UpdatedDate = new DateTime(2023, 10, 16, 9, 22, 11, 598, DateTimeKind.Local).AddTicks(4312)
                        });
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Cart", b =>
                {
                    b.HasOne("MinsCarsShop.Data.Models.Tote", "Tote")
                        .WithMany()
                        .HasForeignKey("ToteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinsCarsShop.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tote");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Order", b =>
                {
                    b.HasOne("MinsCarsShop.Data.Models.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinsCarsShop.Data.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("MinsCarsShop.Data.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinsCarsShop.Data.Models.Tote", "Tote")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ToteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Tote");
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Tote", b =>
                {
                    b.HasOne("MinsCarsShop.Data.Models.Category", "Category")
                        .WithMany("Totes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Category", b =>
                {
                    b.Navigation("Totes");
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.Tote", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MinsCarsShop.Data.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
