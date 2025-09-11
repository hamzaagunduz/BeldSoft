using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beldsoft.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class session : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionSections", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionSections");
        }
    }
}
