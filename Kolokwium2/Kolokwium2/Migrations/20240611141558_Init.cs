using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CurrentWeight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("characters_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("items_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("titles_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "backpacks",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("backpacks_pk", x => new { x.ItemId, x.CharacterId });
                    table.ForeignKey(
                        name: "backpacks_characters",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "backpacks_items",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "character_titles",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("character_titles_pk", x => new { x.CharacterId, x.TitleId });
                    table.ForeignKey(
                        name: "character_titles_characters",
                        column: x => x.CharacterId,
                        principalTable: "characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "character_titles_titles",
                        column: x => x.TitleId,
                        principalTable: "titles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "characters",
                columns: new[] { "Id", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[] { 1, 50, "John", "Doe", 100 });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Name", "Weight" },
                values: new object[] { 1, "Sword", 10 });

            migrationBuilder.InsertData(
                table: "titles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Knight" });

            migrationBuilder.InsertData(
                table: "backpacks",
                columns: new[] { "CharacterId", "ItemId", "Amount" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "character_titles",
                columns: new[] { "CharacterId", "TitleId", "AcquiredAt" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2022) });

            migrationBuilder.CreateIndex(
                name: "IX_backpacks_CharacterId",
                table: "backpacks",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_character_titles_TitleId",
                table: "character_titles",
                column: "TitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "backpacks");

            migrationBuilder.DropTable(
                name: "character_titles");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "titles");
        }
    }
}
