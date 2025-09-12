using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beldsoft.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class settings_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoogleMapAddress",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleMapAddress",
                table: "SiteSettings");
        }
    }
}
