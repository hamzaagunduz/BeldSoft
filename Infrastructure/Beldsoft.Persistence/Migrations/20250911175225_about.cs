using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beldsoft.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class about : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BigImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmallImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExperienceText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title1Step1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title1Step2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title2Step1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title2Step2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title3Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title3Step1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title3Step2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSections", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutSections");
        }
    }
}
