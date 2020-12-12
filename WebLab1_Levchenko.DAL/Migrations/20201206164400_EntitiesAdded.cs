using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLab1_Levchenko.DAL.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatsGroups",
                columns: table => new
                {
                    CatsGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatsGroups", x => x.CatsGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    CatsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatsName = table.Column<string>(nullable: true),
                    CatsColor = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CatsWeight = table.Column<int>(nullable: false),
                    CatsGroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.CatsID);
                    table.ForeignKey(
                        name: "FK_Cats_CatsGroups_CatsGroupID",
                        column: x => x.CatsGroupID,
                        principalTable: "CatsGroups",
                        principalColumn: "CatsGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cats_CatsGroupID",
                table: "Cats",
                column: "CatsGroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "CatsGroups");
        }
    }
}
