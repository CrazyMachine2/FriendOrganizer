using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendOrganizer.DataAccess.Migrations
{
    public partial class AddedMeetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FriendMeeting",
                columns: table => new
                {
                    FriendsID = table.Column<int>(type: "int", nullable: false),
                    MeetingsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendMeeting", x => new { x.FriendsID, x.MeetingsID });
                    table.ForeignKey(
                        name: "FK_FriendMeeting_Friends_FriendsID",
                        column: x => x.FriendsID,
                        principalTable: "Friends",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendMeeting_Meetings_MeetingsID",
                        column: x => x.MeetingsID,
                        principalTable: "Meetings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "ID", "DateFrom", "DateTo", "Title" },
                values: new object[] { 1, new DateTime(2021, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Football game" });

            migrationBuilder.CreateIndex(
                name: "IX_FriendMeeting_MeetingsID",
                table: "FriendMeeting",
                column: "MeetingsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendMeeting");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
