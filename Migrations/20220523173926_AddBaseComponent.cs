using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShorteningWebService.Migrations
{
    public partial class AddBaseComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LinkMaps",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "LinkMaps",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "LinkMapErrors",
                columns: table => new
                {
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "LinkMapUses",
                columns: table => new
                {
                    LinkMapId = table.Column<Guid>(type: "TEXT", nullable: false),
                    When = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_LinkMapUses_LinkMaps_LinkMapId",
                        column: x => x.LinkMapId,
                        principalTable: "LinkMaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkMapUses_LinkMapId",
                table: "LinkMapUses",
                column: "LinkMapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkMapErrors");

            migrationBuilder.DropTable(
                name: "LinkMapUses");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LinkMaps",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "LinkMaps",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
