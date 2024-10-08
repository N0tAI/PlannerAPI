﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaskPlanner.API.Database;

#nullable disable

namespace TaskPlanner.API.Migrations
{
    [DbContext(typeof(PlannerDbContext))]
    partial class TaskPlannerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TaskPlanner.API.Database.Models.CategoryDbModel", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("CategoryId")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.GoalDbModel", b =>
                {
                    b.Property<long>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("goal_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("GoalId"));

                    b.Property<string>("Description")
                        .HasMaxLength(240)
                        .HasColumnType("character varying(240)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("GoalId")
                        .HasName("pk_goals");

                    b.ToTable("goals", (string)null);
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.GoalToMilestoneJoinDbModel", b =>
                {
                    b.Property<long>("ChildGoalGoalId")
                        .HasColumnType("bigint")
                        .HasColumnName("child_goal_goal_id");

                    b.Property<long>("ParentGoalGoalId")
                        .HasColumnType("bigint")
                        .HasColumnName("parent_goal_goal_id");

                    b.HasKey("ChildGoalGoalId", "ParentGoalGoalId")
                        .HasName("pk_goal_milestones");

                    b.HasIndex("ParentGoalGoalId")
                        .HasDatabaseName("ix_goal_milestones_parent_goal_goal_id");

                    b.ToTable("goal_milestones", (string)null);
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.TaskDbModel", b =>
                {
                    b.Property<long>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("task_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("TaskId"));

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

                    b.HasKey("TaskId")
                        .HasName("pk_tasks");

                    b.HasIndex("GoalId")
                        .HasDatabaseName("ix_tasks_goal_id");

                    b.ToTable("tasks", (string)null);
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.TaskToSubTaskJoinDbModel", b =>
                {
                    b.Property<long>("ChildTaskTaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("child_task_task_id");

                    b.Property<long>("ParentTaskTaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("parent_task_task_id");

                    b.HasKey("ChildTaskTaskId", "ParentTaskTaskId")
                        .HasName("pk_tasks_subtasks");

                    b.HasIndex("ParentTaskTaskId")
                        .HasDatabaseName("ix_tasks_subtasks_parent_task_task_id");

                    b.ToTable("tasks_subtasks", (string)null);
                });

            modelBuilder.Entity("goal_categories", b =>
                {
                    b.Property<long>("CategoriesCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("categories_category_id");

                    b.Property<long>("GoalDbModelGoalId")
                        .HasColumnType("bigint")
                        .HasColumnName("goal_db_model_goal_id");

                    b.HasKey("CategoriesCategoryId", "GoalDbModelGoalId")
                        .HasName("pk_goal_categories");

                    b.HasIndex("GoalDbModelGoalId")
                        .HasDatabaseName("ix_goal_categories_goal_db_model_goal_id");

                    b.ToTable("goal_categories", (string)null);
                });

            modelBuilder.Entity("task_categories", b =>
                {
                    b.Property<long>("CategoriesCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("categories_category_id");

                    b.Property<long>("TaskDbModelTaskId")
                        .HasColumnType("bigint")
                        .HasColumnName("task_db_model_task_id");

                    b.HasKey("CategoriesCategoryId", "TaskDbModelTaskId")
                        .HasName("pk_task_categories");

                    b.HasIndex("TaskDbModelTaskId")
                        .HasDatabaseName("ix_task_categories_task_db_model_task_id");

                    b.ToTable("task_categories", (string)null);
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.GoalToMilestoneJoinDbModel", b =>
                {
                    b.HasOne("TaskPlanner.API.Database.Models.GoalDbModel", "ChildGoal")
                        .WithMany()
                        .HasForeignKey("ChildGoalGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_goal_milestones_goals_child_goal_goal_id");

                    b.HasOne("TaskPlanner.API.Database.Models.GoalDbModel", "ParentGoal")
                        .WithMany()
                        .HasForeignKey("ParentGoalGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_goal_milestones_goals_parent_goal_goal_id");

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
                        .HasForeignKey("ChildTaskTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tasks_subtasks_tasks_child_task_task_id");

                    b.HasOne("TaskPlanner.API.Database.Models.TaskDbModel", "ParentTask")
                        .WithMany()
                        .HasForeignKey("ParentTaskTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tasks_subtasks_tasks_parent_task_task_id");

                    b.Navigation("ChildTask");

                    b.Navigation("ParentTask");
                });

            modelBuilder.Entity("goal_categories", b =>
                {
                    b.HasOne("TaskPlanner.API.Database.Models.CategoryDbModel", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_goal_categories_categories_categories_category_id");

                    b.HasOne("TaskPlanner.API.Database.Models.GoalDbModel", null)
                        .WithMany()
                        .HasForeignKey("GoalDbModelGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_goal_categories_goals_goal_db_model_goal_id");
                });

            modelBuilder.Entity("task_categories", b =>
                {
                    b.HasOne("TaskPlanner.API.Database.Models.CategoryDbModel", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_categories_categories_categories_category_id");

                    b.HasOne("TaskPlanner.API.Database.Models.TaskDbModel", null)
                        .WithMany()
                        .HasForeignKey("TaskDbModelTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_categories_tasks_task_db_model_task_id");
                });

            modelBuilder.Entity("TaskPlanner.API.Database.Models.GoalDbModel", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
