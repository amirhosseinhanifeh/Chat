using Microsoft.EntityFrameworkCore.Migrations;

namespace Mozer.Migrations
{
    public partial class AddIsRead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                schema: "Messages",
                table: "MessageItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                schema: "Messages",
                table: "MessageItems");
        }
    }
}
