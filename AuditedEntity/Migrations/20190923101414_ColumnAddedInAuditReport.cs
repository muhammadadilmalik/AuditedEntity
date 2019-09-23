using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditedEntity.Migrations
{
    public partial class ColumnAddedInAuditReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Column",
                table: "AuditReport",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Column",
                table: "AuditReport");
        }
    }
}
