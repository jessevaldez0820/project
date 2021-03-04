using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Group25_Final_Project.Migrations
{
    public partial class _3staxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleID",
                table: "Showings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieID",
                table: "Tickets",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Showings_ScheduleID",
                table: "Showings",
                column: "ScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Showings_Schedule_ScheduleID",
                table: "Showings",
                column: "ScheduleID",
                principalTable: "Schedule",
                principalColumn: "ScheduleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_MovieID",
                table: "Tickets",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Showings_Schedule_ScheduleID",
                table: "Showings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_MovieID",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_MovieID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Showings_ScheduleID",
                table: "Showings");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ScheduleID",
                table: "Showings");
        }
    }
}
