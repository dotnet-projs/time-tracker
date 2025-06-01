using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class Projects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.DropIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails");

            migrationBuilder.DropColumn(
                name: "Project",
                table: "TimeEntries");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "TimeEntries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.ProjectsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_UsersId",
                table: "ProjectUser",
                column: "UsersId");
        }
    }
}
