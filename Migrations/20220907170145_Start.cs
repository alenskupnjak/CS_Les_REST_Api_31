using Microsoft.EntityFrameworkCore.Migrations;

namespace Commander.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandsTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HowTo = table.Column<string>(maxLength: 200, nullable: false),
                    Line = table.Column<string>(nullable: false),
                    Platform = table.Column<string>(nullable: false),
                    Dodatak = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandsTableAlen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HowTo = table.Column<string>(maxLength: 200, nullable: false),
                    Line = table.Column<string>(nullable: false),
                    Platform = table.Column<string>(nullable: false),
                    Dodatak = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandsTableAlen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandsTable");

            migrationBuilder.DropTable(
                name: "CommandsTableAlen");
        }
    }
}
