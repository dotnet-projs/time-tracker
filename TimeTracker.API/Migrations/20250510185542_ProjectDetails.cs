using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeTracker.API.Migrations
{
    /// <inheritdoc />
    public partial class ProjectDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails",
                column: "ProjectId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetails_ProjectId",
                table: "ProjectDetails",
                column: "ProjectId");
        }
    }
}
