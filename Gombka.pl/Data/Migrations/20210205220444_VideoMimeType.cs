using Microsoft.EntityFrameworkCore.Migrations;

namespace Gombka.pl.Data.Migrations
{
    public partial class VideoMimeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "Videos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "Videos");
        }
    }
}
