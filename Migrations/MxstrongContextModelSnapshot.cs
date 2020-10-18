﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mxstrong.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mxstrong.Migrations
{
    [DbContext(typeof(MxstrongContext))]
    partial class MxstrongContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Mxstrong.Models.ActivationToken", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ActivationTokens");
                });

            modelBuilder.Entity("Mxstrong.Models.Comment", b =>
                {
                    b.Property<string>("CommentId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ParentId")
                        .HasColumnType("text");

                    b.Property<string>("PostId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CommentId");

                    b.HasIndex("ParentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Mxstrong.Models.Goal", b =>
                {
                    b.Property<string>("GoalId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParentGoalId")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GoalId");

                    b.HasIndex("UserId");

                    b.ToTable("Goals");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Goal");
                });

            modelBuilder.Entity("Mxstrong.Models.Post", b =>
                {
                    b.Property<string>("PostId")
                        .HasColumnType("text");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TopicId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PostId");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Mxstrong.Models.Topic", b =>
                {
                    b.Property<string>("TopicId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Mxstrong.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<bool>("Activated")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mxstrong.Models.CheckBox", b =>
                {
                    b.HasBaseType("Mxstrong.Models.Goal");

                    b.Property<bool>("Checked")
                        .HasColumnType("boolean");

                    b.HasIndex("ParentGoalId");

                    b.HasDiscriminator().HasValue("CheckBox");
                });

            modelBuilder.Entity("Mxstrong.Models.DayCounter", b =>
                {
                    b.HasBaseType("Mxstrong.Models.Goal");

                    b.Property<int>("DayGoal")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasIndex("ParentGoalId");

                    b.HasDiscriminator().HasValue("DayCounter");
                });

            modelBuilder.Entity("Mxstrong.Models.ProgressBar", b =>
                {
                    b.HasBaseType("Mxstrong.Models.Goal");

                    b.HasIndex("ParentGoalId");

                    b.HasDiscriminator().HasValue("ProgressBar");
                });

            modelBuilder.Entity("Mxstrong.Models.Comment", b =>
                {
                    b.HasOne("Mxstrong.Models.Comment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.HasOne("Mxstrong.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mxstrong.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mxstrong.Models.Goal", b =>
                {
                    b.HasOne("Mxstrong.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mxstrong.Models.Post", b =>
                {
                    b.HasOne("Mxstrong.Models.Topic", "Topic")
                        .WithMany("Posts")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mxstrong.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mxstrong.Models.CheckBox", b =>
                {
                    b.HasOne("Mxstrong.Models.ProgressBar", "ParentGoal")
                        .WithMany("SubGoals")
                        .HasForeignKey("ParentGoalId");
                });

            modelBuilder.Entity("Mxstrong.Models.DayCounter", b =>
                {
                    b.HasOne("Mxstrong.Models.ProgressBar", "ParentGoal")
                        .WithMany("DayCounters")
                        .HasForeignKey("ParentGoalId");
                });

            modelBuilder.Entity("Mxstrong.Models.ProgressBar", b =>
                {
                    b.HasOne("Mxstrong.Models.ProgressBar", "ParentGoal")
                        .WithMany("ChildBars")
                        .HasForeignKey("ParentGoalId");
                });
#pragma warning restore 612, 618
        }
    }
}
