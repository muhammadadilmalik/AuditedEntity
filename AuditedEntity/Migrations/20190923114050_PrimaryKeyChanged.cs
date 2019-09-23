using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditedEntity.Migrations
{
    public partial class PrimaryKeyChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PrimaryKey",
                table: "AuditReport",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PrimaryKey",
                table: "AuditReport",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
