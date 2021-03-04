using Microsoft.EntityFrameworkCore.Migrations;

namespace Group25_Final_Project.Migrations
{
    public partial class it : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_GiftRecId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Movies_MovieID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_MovieID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Orders_GiftRecId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "GiftRecId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "GiftRec",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiftRec",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GiftRecId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieID",
                table: "Tickets",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GiftRecId",
                table: "Orders",
                column: "GiftRecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_GiftRecId",
                table: "Orders",
                column: "GiftRecId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Movies_MovieID",
                table: "Tickets",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
