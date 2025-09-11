using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beldsoft.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class feedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedbackSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BigImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImageUrl3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPosition1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPosition2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPosition3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating1 = table.Column<int>(type: "int", nullable: true),
                    Rating2 = table.Column<int>(type: "int", nullable: true),
                    Rating3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackSections", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackSections");
        }
    }
}
