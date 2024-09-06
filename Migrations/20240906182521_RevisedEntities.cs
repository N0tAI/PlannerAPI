using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskPlanner.API.Migrations
{
    /// <inheritdoc />
    public partial class RevisedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "fk_tasks_goals_goal_id",
                table: "tasks");

            migrationBuilder.DropTable(
                name: "tasks_subtasks");

            migrationBuilder.DropIndex(
                name: "ix_tasks_goal_id",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "goal_id",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "task_db_model_task_id",
                table: "task_categories",
                newName: "tasks_id");

            migrationBuilder.RenameColumn(
                name: "categories_category_id",
                table: "task_categories",
                newName: "categories_id");

            migrationBuilder.RenameIndex(
                name: "ix_task_categories_task_db_model_task_id",
                table: "task_categories",
                newName: "ix_task_categories_tasks_id");

            migrationBuilder.RenameColumn(
                name: "parent_goal_goal_id",
                table: "goal_milestones",
                newName: "milestone_id");

            migrationBuilder.RenameColumn(
                name: "child_goal_goal_id",
                table: "goal_milestones",
                newName: "goal_id");

            migrationBuilder.RenameIndex(
                name: "ix_goal_milestones_parent_goal_goal_id",
                table: "goal_milestones",
                newName: "ix_goal_milestones_milestone_id");

            migrationBuilder.RenameColumn(
                name: "goal_db_model_goal_id",
                table: "goal_categories",
                newName: "goals_id");

            migrationBuilder.RenameColumn(
                name: "categories_category_id",
                table: "goal_categories",
                newName: "categories_id");

            migrationBuilder.RenameIndex(
                name: "ix_goal_categories_goal_db_model_goal_id",
                table: "goal_categories",
                newName: "ix_goal_categories_goals_id");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "tasks",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "goals",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(240)",
                oldMaxLength: 240,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "goal_tasks",
                columns: table => new
                {
                    parent_goals_id = table.Column<long>(type: "bigint", nullable: false),
                    tasks_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_goal_tasks", x => new { x.parent_goals_id, x.tasks_id });
                    table.ForeignKey(
                        name: "fk_goal_tasks_goals_parent_goals_id",
                        column: x => x.parent_goals_id,
                        principalTable: "goals",
                        principalColumn: "goal_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_goal_tasks_tasks_tasks_id",
                        column: x => x.tasks_id,
                        principalTable: "tasks",
                        principalColumn: "task_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "task_subtasks",
                columns: table => new
                {
                    task_id = table.Column<long>(type: "bigint", nullable: false),
                    subtask_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_subtasks", x => new { x.task_id, x.subtask_id });
                    table.ForeignKey(
                        name: "fk_task_subtasks_tasks_subtask_id",
                        column: x => x.subtask_id,
                        principalTable: "tasks",
                        principalColumn: "task_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_task_subtasks_tasks_task_id",
                        column: x => x.task_id,
                        principalTable: "tasks",
                        principalColumn: "task_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_goal_tasks_tasks_id",
                table: "goal_tasks",
                column: "tasks_id");

            migrationBuilder.CreateIndex(
                name: "ix_task_subtasks_subtask_id",
                table: "task_subtasks",
                column: "subtask_id");

            migrationBuilder.AddForeignKey(
                name: "fk_goal_categories_categories_categories_id",
                table: "goal_categories",
                column: "categories_id",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_categories_goals_goals_id",
                table: "goal_categories",
                column: "goals_id",
                principalTable: "goals",
                principalColumn: "goal_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_milestones_goals_goal_id",
                table: "goal_milestones",
                column: "goal_id",
                principalTable: "goals",
                principalColumn: "goal_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_goal_milestones_goals_milestone_id",
                table: "goal_milestones",
                column: "milestone_id",
                principalTable: "goals",
                principalColumn: "goal_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_task_categories_categories_categories_id",
                table: "task_categories",
                column: "categories_id",
                principalTable: "categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_task_categories_tasks_tasks_id",
                table: "task_categories",
                column: "tasks_id",
                principalTable: "tasks",
                principalColumn: "task_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_goal_categories_categories_categories_id",
                table: "goal_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_categories_goals_goals_id",
                table: "goal_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_milestones_goals_goal_id",
                table: "goal_milestones");

            migrationBuilder.DropForeignKey(
                name: "fk_goal_milestones_goals_milestone_id",
                table: "goal_milestones");

            migrationBuilder.DropForeignKey(
                name: "fk_task_categories_categories_categories_id",
                table: "task_categories");

            migrationBuilder.DropForeignKey(
                name: "fk_task_categories_tasks_tasks_id",
                table: "task_categories");

            migrationBuilder.DropTable(
                name: "goal_tasks");

            migrationBuilder.DropTable(
                name: "task_subtasks");

            migrationBuilder.DropColumn(
                name: "description",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "tasks_id",
                table: "task_categories",
                newName: "task_db_model_task_id");

            migrationBuilder.RenameColumn(
                name: "categories_id",
                table: "task_categories",
                newName: "categories_category_id");

            migrationBuilder.RenameIndex(
                name: "ix_task_categories_tasks_id",
                table: "task_categories",
                newName: "ix_task_categories_task_db_model_task_id");

            migrationBuilder.RenameColumn(
                name: "milestone_id",
                table: "goal_milestones",
                newName: "parent_goal_goal_id");

            migrationBuilder.RenameColumn(
                name: "goal_id",
                table: "goal_milestones",
                newName: "child_goal_goal_id");

            migrationBuilder.RenameIndex(
                name: "ix_goal_milestones_milestone_id",
                table: "goal_milestones",
                newName: "ix_goal_milestones_parent_goal_goal_id");

            migrationBuilder.RenameColumn(
                name: "goals_id",
                table: "goal_categories",
                newName: "goal_db_model_goal_id");

            migrationBuilder.RenameColumn(
                name: "categories_id",
                table: "goal_categories",
                newName: "categories_category_id");

            migrationBuilder.RenameIndex(
                name: "ix_goal_categories_goals_id",
                table: "goal_categories",
                newName: "ix_goal_categories_goal_db_model_goal_id");

            migrationBuilder.AddColumn<long>(
                name: "goal_id",
                table: "tasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "goals",
                type: "character varying(240)",
                maxLength: 240,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tasks_subtasks",
                columns: table => new
                {
                    child_task_task_id = table.Column<long>(type: "bigint", nullable: false),
                    parent_task_task_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tasks_subtasks", x => new { x.child_task_task_id, x.parent_task_task_id });
                    table.ForeignKey(
                        name: "fk_tasks_subtasks_tasks_child_task_task_id",
                        column: x => x.child_task_task_id,
                        principalTable: "tasks",
                        principalColumn: "task_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tasks_subtasks_tasks_parent_task_task_id",
                        column: x => x.parent_task_task_id,
                        principalTable: "tasks",
                        principalColumn: "task_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tasks_goal_id",
                table: "tasks",
                column: "goal_id");

            migrationBuilder.CreateIndex(
                name: "ix_tasks_subtasks_parent_task_task_id",
                table: "tasks_subtasks",
                column: "parent_task_task_id");

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
                name: "fk_tasks_goals_goal_id",
                table: "tasks",
                column: "goal_id",
                principalTable: "goals",
                principalColumn: "goal_id");
        }
    }
}
