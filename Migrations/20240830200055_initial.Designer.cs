﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaskPlanner.API.Database;

#nullable disable

namespace TaskPlanner.API.Migrations
{
    [DbContext(typeof(PlannerDbContext))]
    [Migration("20240830200055_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GoalCategories", b =>
                {
                    b.Property<long>("CategoriesId")
                        .HasColumnType("bigint")
                        .HasColumnName("categories_id");

                    b.Property<long>("GoalDbModelId")
                        .HasColumnType("bigint")
                        .HasColumnName("goal_db_model_id");

                    b.HasKey("CategoriesId", "GoalDbModelId")
                        .HasName("pk_goal_categories");

                    b.HasIndex("GoalDbModelId")
                        .HasDatabaseName("ix_goal_categories_goal_db_model_id");

                    b.ToTable("goal_categories", (string)null);
                });

            modelBuilder.Entity("TaskCategories", b =>
                {
                    b.Property<long>("CategoriesId")
                        .HasColumnType("bigint")
                        .HasColumnName("categories_id");

                    b.Property<long>("TaskDbModelId")
                        .HasColumnType("bigint")
                        .HasColumnName("task_db_model_id");

                    b.HasKey("CategoriesId", "TaskDbModelId")
                        .HasName("pk_task_categories");

                    b.HasIndex("TaskDbModelId")
                        .HasDatabaseName("ix_task_categories_task_db_model_id");

                    b.ToTable("task_categories", (string)null);
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.CategoryDbModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CategoryId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.GoalDbModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("GoalId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(240)
                        .HasColumnType("character varying(240)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_goals");

                    b.ToTable("Goals", (string)null);
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.GoalToMilestoneJoinDbModel", b =>
                {
                    b.Property<long>("ChildGoalId")
                        .HasColumnType("bigint")
                        .HasColumnName("child_goal_id");

                    b.Property<long>("ParentGoalId")
                        .HasColumnType("bigint")
                        .HasColumnName("parent_goal_id");

                    b.HasKey("ChildGoalId", "ParentGoalId")
                        .HasName("pk_goal_milestones");

                    b.HasIndex("ParentGoalId")
                        .HasDatabaseName("ix_goal_milestones_parent_goal_id");

                    b.ToTable("GoalMilestones", (string)null);
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.TaskDbModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("TaskId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("GoalId")
                        .HasColumnType("bigint")
                        .HasColumnName("goal_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int?>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("priority")
                        .HasComment("Lower number is lower priority");

                    b.HasKey("Id")
                        .HasName("pk_tasks");

                    b.HasIndex("GoalId")
                        .HasDatabaseName("ix_tasks_goal_id");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.TaskToSubTaskJoinDbModel", b =>
                {
                    b.Property<long>("ChildTaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("child_task_id");

                    b.Property<long>("ParentTaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("parent_task_id");

                    b.HasKey("ChildTaskId", "ParentTaskId")
                        .HasName("pk_tasks_subtasks");

                    b.HasIndex("ParentTaskId")
                        .HasDatabaseName("ix_tasks_subtasks_parent_task_id");

                    b.ToTable("TasksSubtasks", (string)null);
                });

            modelBuilder.Entity("GoalCategories", b =>
                {
                    b.HasOne("TaskPlanner.API.Database.Models.CategoryDbModel", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_goal_categories_categories_categories_id");

                    b.HasOne("TaskPlanner.API.Database.Models.GoalDbModel", null)
                        .WithMany()
                        .HasForeignKey("GoalDbModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_goal_categories_goals_goal_db_model_id");
                });

            modelBuilder.Entity("TaskCategories", b =>
                {
                    b.HasOne("TaskPlanner.API.Database.Models.CategoryDbModel", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_categories_categories_categories_id");

                    b.HasOne("TaskPlanner.API.Database.Models.TaskDbModel", null)
                        .WithMany()
                        .HasForeignKey("TaskDbModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_categories_tasks_task_db_model_id");
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.GoalToMilestoneJoinDbModel", b =>
                {
                    b.HasOne("TaskPlanner.API.Database.Models.GoalDbModel", "ChildGoal")
                        .WithMany()
                        .HasForeignKey("ChildGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_goal_milestones_goals_child_goal_id");

                    b.HasOne("TaskPlanner.API.Database.Models.GoalDbModel", "ParentGoal")
                        .WithMany()
                        .HasForeignKey("ParentGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_goal_milestones_goals_parent_goal_id");

                    b.Navigation("ChildGoal");

                    b.Navigation("ParentGoal");
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.TaskDbModel", b =>
                {
                    b.HasOne("TaskPlanner.API.Database.Models.GoalDbModel", "Goal")
                        .WithMany("Tasks")
                        .HasForeignKey("GoalId")
                        .HasConstraintName("fk_tasks_goals_goal_id");

                    b.Navigation("Goal");
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.TaskToSubTaskJoinDbModel", b =>
                {
                    b.HasOne("TaskPlanner.API.Database.Models.TaskDbModel", "ChildTask")
                        .WithMany()
                        .HasForeignKey("ChildTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tasks_subtasks_tasks_child_task_id");

                    b.HasOne("TaskPlanner.API.Database.Models.TaskDbModel", "ParentTask")
                        .WithMany()
                        .HasForeignKey("ParentTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tasks_subtasks_tasks_parent_task_id");

                    b.Navigation("ChildTask");

                    b.Navigation("ParentTask");
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.GoalDbModel", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
