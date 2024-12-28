﻿// <auto-generated />
using ASP.NET_Core_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using AppContext = ASP.NET_Core_MVC.Data.AppContext;

#nullable disable

namespace ASP.NET_Core_MVC.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Clothing"
                        });
                });

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("SerialNumberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Name = "Laptop",
                            Price = 1000.0,
                            SerialNumberId = 10
                        });
                });

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.ItemClient", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("ItemClients");
                });

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.SerialNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId")
                        .IsUnique()
                        .HasFilter("[ItemId] IS NOT NULL");

                    b.ToTable("SerialNumber");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            ItemId = 4,
                            Name = "1234Laptop56"
                        });
                });

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.Item", b =>
                {
                    b.HasOne("ASP.NET_Core_MVC.Models.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.ItemClient", b =>
                {
                    b.HasOne("ASP.NET_Core_MVC.Models.Client", "Client")
                        .WithMany("ItemClients")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP.NET_Core_MVC.Models.Item", "Item")
                        .WithMany("ItemClients")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.SerialNumber", b =>
                {
                    b.HasOne("ASP.NET_Core_MVC.Models.Item", "Item")
                        .WithOne("SerialNumber")
                        .HasForeignKey("ASP.NET_Core_MVC.Models.SerialNumber", "ItemId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.Client", b =>
                {
                    b.Navigation("ItemClients");
                });

            modelBuilder.Entity("ASP.NET_Core_MVC.Models.Item", b =>
                {
                    b.Navigation("ItemClients");

                    b.Navigation("SerialNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
