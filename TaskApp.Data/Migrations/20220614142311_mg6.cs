using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskApp.Data.Migrations
{
    public partial class mg6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskAssignmentId",
                table: "TaskWithDocuments",
                newName: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "TaskWithDocuments",
                newName: "TaskAssignmentId");
        }
    }
}
