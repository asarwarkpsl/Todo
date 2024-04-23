﻿// <auto-generated />
using System;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20240423110557_automig_seeding_Migration")]
    partial class automig_seeding_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.18");

            modelBuilder.Entity("Core.Model.List", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("isEnabled")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Lists");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Timestamp = new DateTime(2024, 4, 23, 14, 13, 0, 0, DateTimeKind.Unspecified),
                            Title = "Lorem ipsum",
                            isEnabled = true
                        },
                        new
                        {
                            id = 2,
                            Timestamp = new DateTime(2024, 4, 23, 10, 13, 0, 0, DateTimeKind.Unspecified),
                            Title = "dolor sit amet",
                            isEnabled = true
                        });
                });

            modelBuilder.Entity("Core.Model.Task", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileURL")
                        .HasColumnType("TEXT");

                    b.Property<int>("ListId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("NextRemindDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isEnabled")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("ListId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Description = "viverra tellus in hac habitasse",
                            DueDate = new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FileURL = "File/Image.png",
                            ListId = 1,
                            NextRemindDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Active",
                            Timestamp = new DateTime(2024, 4, 23, 14, 13, 0, 0, DateTimeKind.Unspecified),
                            Title = "tincidunt ornare",
                            Type = "None",
                            isEnabled = true
                        },
                        new
                        {
                            id = 2,
                            Description = "viverra tellus in hac habitasse",
                            DueDate = new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FileURL = "File/Image.png",
                            ListId = 1,
                            NextRemindDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Active",
                            Timestamp = new DateTime(2024, 4, 23, 14, 13, 0, 0, DateTimeKind.Unspecified),
                            Title = "tincidunt ornare",
                            Type = "None",
                            isEnabled = true
                        });
                });

            modelBuilder.Entity("Core.Model.Task", b =>
                {
                    b.HasOne("Core.Model.List", null)
                        .WithMany("Tasks")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Model.List", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
