﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskApp.Data.Concrete.EF;

namespace TaskApp.Data.Migrations
{
    [DbContext(typeof(TaskAppContext))]
    [Migration("20220615165409_mg8")]
    partial class mg8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("TaskApp.Entity.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddedById")
                        .HasColumnType("TEXT");

                    b.Property<string>("DocumentTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("TaskApp.Entity.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TaskContent")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskDescription")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TaskFinishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TaskStateOfUrgency")
                        .HasColumnType("TEXT");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskApp.Entity.TaskAssignment", b =>
                {
                    b.Property<int>("TaskAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("TaskAssignmentId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskAssignments");
                });

            modelBuilder.Entity("TaskApp.Entity.TaskWithDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DocumentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("TaskWithDocuments");
                });

            modelBuilder.Entity("TaskApp.Entity.TaskAssignment", b =>
                {
                    b.HasOne("TaskApp.Entity.Task", "Task")
                        .WithMany("TaskAssignments")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("TaskApp.Entity.TaskWithDocument", b =>
                {
                    b.HasOne("TaskApp.Entity.Document", "Document")
                        .WithMany("TaskWithDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("TaskApp.Entity.Document", b =>
                {
                    b.Navigation("TaskWithDocuments");
                });

            modelBuilder.Entity("TaskApp.Entity.Task", b =>
                {
                    b.Navigation("TaskAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
