using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirtyAppAbp.Migrations
{
    public partial class eleven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_People_PersonId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_People_ApplicantId",
                table: "ApplicantSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_People_AbpUsers_UserId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_People_ApplicantId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_People_ApplicantId",
                table: "Qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_StoredFiles_People_ApplicantId",
                table: "StoredFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_People_UserId",
                table: "Persons",
                newName: "IX_Persons_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_People_ApplicantId",
                table: "Persons",
                newName: "IX_Persons_ApplicantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Persons_PersonId",
                table: "Address",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSubjects_Persons_ApplicantId",
                table: "ApplicantSubjects",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_AbpUsers_UserId",
                table: "Persons",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_ApplicantId",
                table: "Persons",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_Persons_ApplicantId",
                table: "Qualifications",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoredFiles_Persons_ApplicantId",
                table: "StoredFiles",
                column: "ApplicantId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Persons_PersonId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantSubjects_Persons_ApplicantId",
                table: "ApplicantSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_AbpUsers_UserId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_ApplicantId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_Persons_ApplicantId",
                table: "Qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_StoredFiles_Persons_ApplicantId",
                table: "StoredFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "People");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_UserId",
                table: "People",
                newName: "IX_People_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_ApplicantId",
                table: "People",
                newName: "IX_People_ApplicantId");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "People",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_People_PersonId",
                table: "Address",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantSubjects_People_ApplicantId",
                table: "ApplicantSubjects",
                column: "ApplicantId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_AbpUsers_UserId",
                table: "People",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_ApplicantId",
                table: "People",
                column: "ApplicantId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_People_ApplicantId",
                table: "Qualifications",
                column: "ApplicantId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoredFiles_People_ApplicantId",
                table: "StoredFiles",
                column: "ApplicantId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
