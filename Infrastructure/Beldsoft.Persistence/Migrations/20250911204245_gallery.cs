using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beldsoft.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class gallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GallerySections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heading1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heading2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heading3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heading4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GallerySections", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GallerySections");
        }
    }
}
