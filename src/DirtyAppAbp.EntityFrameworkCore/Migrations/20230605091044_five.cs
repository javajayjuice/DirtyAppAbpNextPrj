using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtyAppAbp.Migrations
{
    public partial class five : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Parents_ParentId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ParentId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "People");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Parents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_PersonId",
                table: "Parents",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_People_PersonId",
                table: "Parents",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_People_PersonId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_PersonId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Parents");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "People",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_ParentId",
                table: "People",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Parents_ParentId",
                table: "People",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id");
        }
    }
}
