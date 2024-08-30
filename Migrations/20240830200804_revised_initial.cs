using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskPlanner.API.Migrations
{
    /// <inheritdoc />
    public partial class revised_initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_goal_categories_categories_categories_id",
                table: "goal_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_categories_goals_goal_db_model_id",
                table: "goal_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_milestones_goals_child_goal_id",
                table: "GoalMilestones");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_milestones_goals_parent_goal_id",
                table: "GoalMilestones");

            migrationBuilder.DropForeignKey(
                name: "fk_task_categories_categories_categories_id",
                table: "task_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_task_categories_tasks_task_db_model_id",
                table: "task_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_tasks_subtasks_tasks_child_task_id",
                table: "TasksSubtasks");

            migrationBuilder.DropForeignKey(
                name: "fk_tasks_subtasks_tasks_parent_task_id",
                table: "TasksSubtasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "tasks");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "goals");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "TasksSubtasks",
                newName: "tasks_subtasks");

            migrationBuilder.RenameTable(
                name: "GoalMilestones",
                newName: "goal_milestones");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "tasks",
                newName: "task_id");

            migrationBuilder.RenameColumn(
                name: "task_db_model_id",
                table: "task_categories",
                newName: "task_db_model_task_id");

            migrationBuilder.RenameColumn(
                name: "categories_id",
                table: "task_categories",
                newName: "categories_category_id");

            migrationBuilder.RenameIndex(
                name: "ix_task_categories_task_db_model_id",
                table: "task_categories",
                newName: "ix_task_categories_task_db_model_task_id");

            migrationBuilder.RenameColumn(
                name: "GoalId",
                table: "goals",
                newName: "goal_id");

            migrationBuilder.RenameColumn(
                name: "goal_db_model_id",
                table: "goal_categories",
                newName: "goal_db_model_goal_id");

            migrationBuilder.RenameColumn(
                name: "categories_id",
                table: "goal_categories",
                newName: "categories_category_id");

            migrationBuilder.RenameIndex(
                name: "ix_goal_categories_goal_db_model_id",
                table: "goal_categories",
                newName: "ix_goal_categories_goal_db_model_goal_id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "categories",
                newName: "category_id");

            migrationBuilder.RenameColumn(
                name: "parent_task_id",
                table: "tasks_subtasks",
                newName: "parent_task_task_id");

            migrationBuilder.RenameColumn(
                name: "child_task_id",
                table: "tasks_subtasks",
                newName: "child_task_task_id");

            migrationBuilder.RenameIndex(
                name: "ix_tasks_subtasks_parent_task_id",
                table: "tasks_subtasks",
                newName: "ix_tasks_subtasks_parent_task_task_id");

            migrationBuilder.RenameColumn(
                name: "parent_goal_id",
                table: "goal_milestones",
                newName: "parent_goal_goal_id");

            migrationBuilder.RenameColumn(
                name: "child_goal_id",
                table: "goal_milestones",
                newName: "child_goal_goal_id");

            migrationBuilder.RenameIndex(
                name: "ix_goal_milestones_parent_goal_id",
                table: "goal_milestones",
                newName: "ix_goal_milestones_parent_goal_goal_id");

            migrationBuilder.AddForeignKey(
                name: "fk_goal_categories_categories_categories_category_id",
                table: "goal_categories",
                column: "categories_category_id",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_categories_goals_goal_db_model_goal_id",
                table: "goal_categories",
                column: "goal_db_model_goal_id",
                principalTable: "goals",
                principalColumn: "goal_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_milestones_goals_child_goal_goal_id",
                table: "goal_milestones",
                column: "child_goal_goal_id",
                principalTable: "goals",
                principalColumn: "goal_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_milestones_goals_parent_goal_goal_id",
                table: "goal_milestones",
                column: "parent_goal_goal_id",
                principalTable: "goals",
                principalColumn: "goal_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_task_categories_categories_categories_category_id",
                table: "task_categories",
                column: "categories_category_id",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_task_categories_tasks_task_db_model_task_id",
                table: "task_categories",
                column: "task_db_model_task_id",
                principalTable: "tasks",
                principalColumn: "task_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_subtasks_tasks_child_task_task_id",
                table: "tasks_subtasks",
                column: "child_task_task_id",
                principalTable: "tasks",
                principalColumn: "task_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_subtasks_tasks_parent_task_task_id",
                table: "tasks_subtasks",
                column: "parent_task_task_id",
                principalTable: "tasks",
                principalColumn: "task_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_goal_categories_categories_categories_category_id",
                table: "goal_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_categories_goals_goal_db_model_goal_id",
                table: "goal_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_milestones_goals_child_goal_goal_id",
                table: "goal_milestones");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_milestones_goals_parent_goal_goal_id",
                table: "goal_milestones");

            migrationBuilder.DropForeignKey(
                name: "fk_task_categories_categories_categories_category_id",
                table: "task_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_task_categories_tasks_task_db_model_task_id",
                table: "task_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_tasks_subtasks_tasks_child_task_task_id",
                table: "tasks_subtasks");

            migrationBuilder.DropForeignKey(
                name: "fk_tasks_subtasks_tasks_parent_task_task_id",
                table: "tasks_subtasks");

            migrationBuilder.RenameTable(
                name: "tasks",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "goals",
                newName: "Goals");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "tasks_subtasks",
                newName: "TasksSubtasks");

            migrationBuilder.RenameTable(
                name: "goal_milestones",
                newName: "GoalMilestones");

            migrationBuilder.RenameColumn(
                name: "task_id",
                table: "Tasks",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "task_db_model_task_id",
                table: "task_categories",
                newName: "task_db_model_id");

            migrationBuilder.RenameColumn(
                name: "categories_category_id",
                table: "task_categories",
                newName: "categories_id");

            migrationBuilder.RenameIndex(
                name: "ix_task_categories_task_db_model_task_id",
                table: "task_categories",
                newName: "ix_task_categories_task_db_model_id");

            migrationBuilder.RenameColumn(
                name: "goal_id",
                table: "Goals",
                newName: "GoalId");

            migrationBuilder.RenameColumn(
                name: "goal_db_model_goal_id",
                table: "goal_categories",
                newName: "goal_db_model_id");

            migrationBuilder.RenameColumn(
                name: "categories_category_id",
                table: "goal_categories",
                newName: "categories_id");

            migrationBuilder.RenameIndex(
                name: "ix_goal_categories_goal_db_model_goal_id",
                table: "goal_categories",
                newName: "ix_goal_categories_goal_db_model_id");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "parent_task_task_id",
                table: "TasksSubtasks",
                newName: "parent_task_id");

            migrationBuilder.RenameColumn(
                name: "child_task_task_id",
                table: "TasksSubtasks",
                newName: "child_task_id");

            migrationBuilder.RenameIndex(
                name: "ix_tasks_subtasks_parent_task_task_id",
                table: "TasksSubtasks",
                newName: "ix_tasks_subtasks_parent_task_id");

            migrationBuilder.RenameColumn(
                name: "parent_goal_goal_id",
                table: "GoalMilestones",
                newName: "parent_goal_id");

            migrationBuilder.RenameColumn(
                name: "child_goal_goal_id",
                table: "GoalMilestones",
                newName: "child_goal_id");

            migrationBuilder.RenameIndex(
                name: "ix_goal_milestones_parent_goal_goal_id",
                table: "GoalMilestones",
                newName: "ix_goal_milestones_parent_goal_id");

            migrationBuilder.AddForeignKey(
                name: "fk_goal_categories_categories_categories_id",
                table: "goal_categories",
                column: "categories_id",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_categories_goals_goal_db_model_id",
                table: "goal_categories",
                column: "goal_db_model_id",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_milestones_goals_child_goal_id",
                table: "GoalMilestones",
                column: "child_goal_id",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_milestones_goals_parent_goal_id",
                table: "GoalMilestones",
                column: "parent_goal_id",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_task_categories_categories_categories_id",
                table: "task_categories",
                column: "categories_id",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_task_categories_tasks_task_db_model_id",
                table: "task_categories",
                column: "task_db_model_id",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_subtasks_tasks_child_task_id",
                table: "TasksSubtasks",
                column: "child_task_id",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_subtasks_tasks_parent_task_id",
                table: "TasksSubtasks",
                column: "parent_task_id",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
