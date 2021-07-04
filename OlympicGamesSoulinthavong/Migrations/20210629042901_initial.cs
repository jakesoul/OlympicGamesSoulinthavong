using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympicGamesSoulinthavong.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OlympicGames",
                columns: table => new
                {
                    OlympicGameId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OlympicGames", x => x.OlympicGameId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlympicGameId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_OlympicGames_OlympicGameId",
                        column: x => x.OlympicGameId,
                        principalTable: "OlympicGames",
                        principalColumn: "OlympicGameId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "OlympicGames",
                columns: new[] { "OlympicGameId", "Name" },
                values: new object[,]
                {
                    { "wo", "Winter Olympics" },
                    { "so", "Summer Olympics" },
                    { "po", "Paralympics" },
                    { "yo", "Youth Olympics" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Category", "Name" },
                values: new object[,]
                {
                    { "curl", "Indoor", "Curling" },
                    { "bob", "Outdoor", "Bobsleigh" },
                    { "div", "Indoor", "Diving" },
                    { "cycl", "Outdoor", "Road Cycling" },
                    { "arch", "Indoor", "Archery" },
                    { "cs", "Outdoor", "Canoe Sprint" },
                    { "break", "Indoor", "Breakdancing" },
                    { "skate", "Outdoor", "Skateboarding" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "LogoImage", "Name", "OlympicGameId", "SportId" },
                values: new object[,]
                {
                    { "can", "can.png", "Canada", "wo", "curl" },
                    { "fin", "fin.png", "Finland", "yo", "skate" },
                    { "rus", "rus.png", "Russia", "yo", "break" },
                    { "cyp", "cyp.png", "Cyprus", "yo", "break" },
                    { "fran", "fran.png", "France", "yo", "break" },
                    { "zim", "zim.png", "Zimbabwe", "po", "cs" },
                    { "pak", "pak.png", "Pakistan", "po", "cs" },
                    { "aus", "aus.png", "Austria", "po", "cs" },
                    { "ukr", "ukr.png", "Ukraine", "po", "arch" },
                    { "ur", "ur.png", "Uruguy", "po", "arch" },
                    { "thai", "thai.png", "Thailand", "po", "arch" },
                    { "usa", "usa.png", "USA", "so", "cycl" },
                    { "ne", "ne.png", "Netherlands", "so", "cycl" },
                    { "braz", "braz.png", "Brazil", "so", "cycl" },
                    { "mex", "mex.png", "Mexico", "so", "div" },
                    { "chi", "chi.png", "China", "so", "div" },
                    { "germ", "germ.png", "Germany", "so", "div" },
                    { "jp", "jp.png", "Japan", "wo", "bob" },
                    { "it", "it.png", "Italy", "wo", "bob" },
                    { "jam", "jam.png", "Jamaica", "wo", "bob" },
                    { "gb", "gb.png", "Great Britain", "wo", "curl" },
                    { "se", "se.png", "Sweden", "wo", "curl" },
                    { "slov", "slov.png", "Slovakia", "yo", "skate" },
                    { "port", "port.png", "Portugal", "yo", "skate" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_OlympicGameId",
                table: "Countries",
                column: "OlympicGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportId",
                table: "Countries",
                column: "SportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "OlympicGames");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
