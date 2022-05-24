using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShorteningWebService.Migrations
{
    public partial class AddMissingKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LinkMapUses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LinkMapErrors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkMapUses",
                table: "LinkMapUses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkMapErrors",
                table: "LinkMapErrors",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkMapUses",
                table: "LinkMapUses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkMapErrors",
                table: "LinkMapErrors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LinkMapUses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LinkMapErrors");
        }
    }
}
