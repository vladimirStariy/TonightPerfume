﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TonightPerfume.Data;

#nullable disable

namespace TonightPerfume.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230830203452_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProductNotes", b =>
                {
                    b.Property<uint>("PerfumeNotesNote_ID")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("ProductsProduct_ID")
                        .HasColumnType("int unsigned");

                    b.HasKey("PerfumeNotesNote_ID", "ProductsProduct_ID");

                    b.HasIndex("ProductsProduct_ID");

                    b.ToTable("ProductNotes");
                });

            modelBuilder.Entity("TonightPerfume.Domain.Models.BaseUser", b =>
                {
                    b.Property<uint>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("User_ID");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("TonightPerfume.Domain.Models.Brand", b =>
                {
                    b.Property<uint>("Brand_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Brand_ID");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("TonightPerfume.Domain.Models.Category", b =>
                {
                    b.Property<uint>("Category_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Category_ID");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("TonightPerfume.Domain.Models.PerfumeNote", b =>
                {
                    b.Property<uint>("Note_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Note_ID");

                    b.ToTable("PermumeNotes", (string)null);
                });

            modelBuilder.Entity("TonightPerfume.Domain.Models.Product", b =>
                {
                    b.Property<uint>("Product_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned");

                    b.Property<uint>("Brand_ID")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("Category_ID")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Product_ID");

                    b.HasIndex("Brand_ID");

                    b.HasIndex("Category_ID");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("TonightPerfume.Domain.Models.RefreshToken", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DeviceData")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<uint>("User_ID")
                        .HasColumnType("int unsigned");

                    b.HasKey("Token");

                    b.HasIndex("User_ID");

                    b.ToTable("Tokens", (string)null);
                });

            modelBuilder.Entity("ProductNotes", b =>
                {
                    b.HasOne("TonightPerfume.Domain.Models.PerfumeNote", null)
                        .WithMany()
                        .HasForeignKey("PerfumeNotesNote_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TonightPerfume.Domain.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProduct_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TonightPerfume.Domain.Models.Product", b =>
                {
                    b.HasOne("TonightPerfume.Domain.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("Brand_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TonightPerfume.Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("Category_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TonightPerfume.Domain.Models.RefreshToken", b =>
                {
                    b.HasOne("TonightPerfume.Domain.Models.BaseUser", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TonightPerfume.Domain.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("TonightPerfume.Domain.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
