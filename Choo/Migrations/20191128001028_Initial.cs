using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Choo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainPassages",
                columns: table => new
                {
                    TrainPassageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainNumber = table.Column<int>(nullable: false),
                    PassTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainPassages", x => x.TrainPassageId);
                });

            migrationBuilder.CreateTable(
                name: "CarPassage",
                columns: table => new
                {
                    CarPassageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarNumber = table.Column<int>(nullable: false),
                    PassTime = table.Column<DateTime>(nullable: false),
                    TrainPassageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPassage", x => x.CarPassageId);
                    table.ForeignKey(
                        name: "FK_CarPassage_TrainPassages_TrainPassageId",
                        column: x => x.TrainPassageId,
                        principalTable: "TrainPassages",
                        principalColumn: "TrainPassageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TrainPassages",
                columns: new[] { "TrainPassageId", "PassTime", "TrainNumber" },
                values: new object[] { 1, new DateTime(2018, 8, 18, 7, 22, 16, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "TrainPassages",
                columns: new[] { "TrainPassageId", "PassTime", "TrainNumber" },
                values: new object[] { 2, new DateTime(2018, 8, 18, 8, 22, 16, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "CarPassage",
                columns: new[] { "CarPassageId", "CarNumber", "PassTime", "TrainPassageId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 8, 18, 7, 22, 16, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2018, 8, 18, 7, 22, 18, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 1, new DateTime(2018, 8, 18, 8, 22, 16, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 2, new DateTime(2018, 8, 18, 8, 22, 18, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPassage_TrainPassageId",
                table: "CarPassage",
                column: "TrainPassageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarPassage");

            migrationBuilder.DropTable(
                name: "TrainPassages");
        }
    }
}
