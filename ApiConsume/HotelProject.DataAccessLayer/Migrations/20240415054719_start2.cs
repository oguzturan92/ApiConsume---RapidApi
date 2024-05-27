using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class start2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutRoomCount = table.Column<int>(type: "int", nullable: false),
                    AboutStaffCount = table.Column<int>(type: "int", nullable: false),
                    AboutCustomerCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");
        }
    }
}
