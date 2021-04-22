using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendOrganizer.DataAccess.Migrations
{
    public partial class AddedProgrammingLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoriteLanguageID",
                table: "Friends",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Java" },
                    { 3, "JavaScript" },
                    { 4, "PHP" },
                    { 5, "Python" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FavoriteLanguageID",
                table: "Friends",
                column: "FavoriteLanguageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_ProgrammingLanguages_FavoriteLanguageID",
                table: "Friends",
                column: "FavoriteLanguageID",
                principalTable: "ProgrammingLanguages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_ProgrammingLanguages_FavoriteLanguageID",
                table: "Friends");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Friends_FavoriteLanguageID",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "FavoriteLanguageID",
                table: "Friends");
        }
    }
}
