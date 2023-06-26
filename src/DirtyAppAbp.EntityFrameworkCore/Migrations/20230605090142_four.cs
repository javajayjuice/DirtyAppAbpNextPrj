using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtyAppAbp.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
