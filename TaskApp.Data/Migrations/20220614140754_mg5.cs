using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskApp.Data.Migrations
{
    public partial class mg5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TaskWithDocuments_DocumentId",
                table: "TaskWithDocuments",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskWithDocuments_Documents_DocumentId",
                table: "TaskWithDocuments",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskWithDocuments_Documents_DocumentId",
                table: "TaskWithDocuments");

            migrationBuilder.DropIndex(
                name: "IX_TaskWithDocuments_DocumentId",
                table: "TaskWithDocuments");
        }
    }
}
