using Microsoft.EntityFrameworkCore.Migrations;

namespace Gombka.pl.Data.Migrations
{
    public partial class ThumbType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailMimeType",
                table: "Videos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailMimeType",
                table: "Videos");
        }
    }
}
