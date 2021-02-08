using Microsoft.EntityFrameworkCore.Migrations;

namespace Gombka.pl.Data.Migrations
{
    public partial class AddThumbnailFileNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailFileName",
                table: "Videos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailFileName",
                table: "Videos");
        }
    }
}
