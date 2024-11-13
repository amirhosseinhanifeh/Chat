using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mozer.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageItemActions",
                schema: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MessageItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageAction = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageItemActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageItemActions_MessageItems_MessageItemId",
                        column: x => x.MessageItemId,
                        principalSchema: "Messages",
                        principalTable: "MessageItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageItemActions_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identites",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageItemActions_MessageItemId",
                schema: "Messages",
                table: "MessageItemActions",
                column: "MessageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageItemActions_UserId_MessageAction",
                schema: "Messages",
                table: "MessageItemActions",
                columns: new[] { "UserId", "MessageAction" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageItemActions",
                schema: "Messages");
        }
    }
}
