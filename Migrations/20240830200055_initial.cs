using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TaskPlanner.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_goals", x => x.GoalId);
                });

            migrationBuilder.CreateTable(
                name: "goal_categories",
                columns: table => new
                {
                    categories_id = table.Column<long>(type: "bigint", nullable: false),
                    goal_db_model_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_goal_categories", x => new { x.categories_id, x.goal_db_model_id });
                    table.ForeignKey(
                        name: "fk_goal_categories_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_goal_categories_goals_goal_db_model_id",
                        column: x => x.goal_db_model_id,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoalMilestones",
                columns: table => new
                {
                    child_goal_id = table.Column<long>(type: "bigint", nullable: false),
                    parent_goal_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_goal_milestones", x => new { x.child_goal_id, x.parent_goal_id });
                    table.ForeignKey(
                        name: "fk_goal_milestones_goals_child_goal_id",
                        column: x => x.child_goal_id,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_goal_milestones_goals_parent_goal_id",
                        column: x => x.parent_goal_id,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: true, defaultValue: 0, comment: "Lower number is lower priority"),
                    goal_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "fk_tasks_goals_goal_id",
                        column: x => x.goal_id,
                        principalTable: "Goals",
                        principalColumn: "GoalId");
                });

            migrationBuilder.CreateTable(
                name: "task_categories",
                columns: table => new
                {
                    categories_id = table.Column<long>(type: "bigint", nullable: false),
                    task_db_model_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_categories", x => new { x.categories_id, x.task_db_model_id });
                    table.ForeignKey(
                        name: "fk_task_categories_categories_categories_id",
                        column: x => x.categories_id,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_task_categories_tasks_task_db_model_id",
                        column: x => x.task_db_model_id,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TasksSubtasks",
                columns: table => new
                {
                    child_task_id = table.Column<long>(type: "bigint", nullable: false),
                    parent_task_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tasks_subtasks", x => new { x.child_task_id, x.parent_task_id });
                    table.ForeignKey(
                        name: "fk_tasks_subtasks_tasks_child_task_id",
                        column: x => x.child_task_id,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tasks_subtasks_tasks_parent_task_id",
                        column: x => x.parent_task_id,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_goal_categories_goal_db_model_id",
                table: "goal_categories",
                column: "goal_db_model_id");

            migrationBuilder.CreateIndex(
                name: "ix_goal_milestones_parent_goal_id",
                table: "GoalMilestones",
                column: "parent_goal_id");

            migrationBuilder.CreateIndex(
                name: "ix_task_categories_task_db_model_id",
                table: "task_categories",
                column: "task_db_model_id");

            migrationBuilder.CreateIndex(
                name: "ix_tasks_goal_id",
                table: "Tasks",
                column: "goal_id");

            migrationBuilder.CreateIndex(
                name: "ix_tasks_subtasks_parent_task_id",
                table: "TasksSubtasks",
                column: "parent_task_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "goal_categories");

            migrationBuilder.DropTable(
                name: "GoalMilestones");

            migrationBuilder.DropTable(
                name: "task_categories");

            migrationBuilder.DropTable(
                name: "TasksSubtasks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Goals");
        }
    }
}
