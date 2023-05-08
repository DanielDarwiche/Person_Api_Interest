using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Person_Api_Interest.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Linkid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "InterestDescription", "InterestName" },
                values: new object[,]
                {
                    { 1, "Tennis is a competitive sport where you hit a ball with a racket", "Tennis" },
                    { 2, "Fotball is a team sport where you hit a ball, but not with your hand", "Fotball" },
                    { 3, "Boxing is a competitive sport where you hit a person with a gloved hand", "Boxing" },
                    { 4, "Readig is a calm activity", "Reading" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "LinkURL" },
                values: new object[,]
                {
                    { 1, "https://duckduckgo.com/?q=boxing&t=h_&ia=web" },
                    { 2, "https://duckduckgo.com/?q=boxing&t=h_&iax=images&ia=images" },
                    { 3, "https://duckduckgo.com/?q=tennis&t=h_&ia=web" },
                    { 4, "https://duckduckgo.com/?q=tennis&t=h_&iax=images&ia=images" },
                    { 5, "https://duckduckgo.com/?q=fotball&t=h_&iax=images&ia=images" },
                    { 6, "https://duckduckgo.com/?q=fotball+zlatan&t=h_&iar=images&iax=images&ia=images" },
                    { 7, "https://duckduckgo.com/?q=Reading&t=h_&iax=images&ia=images" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Age", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, 4, "Daniella", "Khoury", "07649024234" },
                    { 2, 33, "Emelie", "Bojanic", "0764999934" },
                    { 3, 38, "Jennifer", "Dara", "034049024234" },
                    { 4, 42, "Elias", "Jovanovic", "033023454234" },
                    { 5, 27, "Daniel", "Darwiche", "073535356565" },
                    { 6, 29, "Alvin", "Andersson", "07634594994" },
                    { 7, 49, "Damir", "Slopovic", "08191233" },
                    { 8, 99, "Ulf", "Karlsson", "2342343434" }
                });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "InterestId", "Linkid", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 3, 1 },
                    { 2, 1, 4, 1 },
                    { 3, 1, 3, 2 },
                    { 4, 2, 5, 3 },
                    { 5, 2, 6, 3 },
                    { 6, 3, 1, 4 },
                    { 7, 3, 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
