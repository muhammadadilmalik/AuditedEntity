using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditedEntity.Migrations
{
    public partial class PrimaryKeyColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PrimaryKey",
                table: "AuditReport",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryKey",
                table: "AuditReport");
        }
    }
}
