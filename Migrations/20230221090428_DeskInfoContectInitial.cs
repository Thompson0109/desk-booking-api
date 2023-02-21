using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleTest.Migrations
{
    public partial class DeskInfoContectInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "desk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeskNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    isAvailable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_desk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bookingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    deskID = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookingStatus_desk_deskID",
                        column: x => x.deskID,
                        principalTable: "desk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingStatus_deskID",
                table: "bookingStatus",
                column: "deskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingStatus");

            migrationBuilder.DropTable(
                name: "desk");
        }
    }
}
