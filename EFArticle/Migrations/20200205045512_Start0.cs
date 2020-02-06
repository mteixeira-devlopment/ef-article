using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFArticle.Migrations
{
    public partial class Start0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    name = table.Column<string>(type: "VARCHAR(120)", nullable: false),
                    doc_unique_identifier_register = table.Column<string>(type: "VARCHAR(11)", nullable: true),
                    doc_drive_licence = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    city = table.Column<string>(type: "VARCHAR(40)", nullable: false),
                    street = table.Column<string>(type: "VARCHAR(120)", nullable: false),
                    number = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    id_person = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_addresses_persons_id_person",
                        column: x => x.id_person,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_id_person",
                table: "addresses",
                column: "id_person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
