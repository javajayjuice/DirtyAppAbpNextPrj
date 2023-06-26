using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtyAppAbp.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_People_PersonId",
                table: "ApplicantSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Parents_PersonId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantSubjects_PersonId",
                table: "ApplicantSubjects");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "ApplicantSubjects");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_PersonId",
                table: "Parents",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Parents_PersonId",
                table: "Parents");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "ApplicantSubjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_PersonId",
                table: "Parents",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantSubjects_PersonId",
                table: "ApplicantSubjects",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSubjects_People_PersonId",
                table: "ApplicantSubjects",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
