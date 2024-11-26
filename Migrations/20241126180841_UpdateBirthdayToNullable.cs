using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVMazeScraper.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBirthdayToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastInfo_Person_PersonId",
                table: "CastInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CastInfo_Shows_ShowId",
                table: "CastInfo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Shows",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Shows",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Person",
                newName: "birthday");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ShowId",
                table: "CastInfo",
                newName: "Showid");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "CastInfo",
                newName: "personid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CastInfo",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_CastInfo_ShowId",
                table: "CastInfo",
                newName: "IX_CastInfo_Showid");

            migrationBuilder.RenameIndex(
                name: "IX_CastInfo_PersonId",
                table: "CastInfo",
                newName: "IX_CastInfo_personid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "Person",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_CastInfo_Person_personid",
                table: "CastInfo",
                column: "personid",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CastInfo_Shows_Showid",
                table: "CastInfo",
                column: "Showid",
                principalTable: "Shows",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CastInfo_Person_personid",
                table: "CastInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CastInfo_Shows_Showid",
                table: "CastInfo");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Shows",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Shows",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Person",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "birthday",
                table: "Person",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Person",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "personid",
                table: "CastInfo",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Showid",
                table: "CastInfo",
                newName: "ShowId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CastInfo",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CastInfo_Showid",
                table: "CastInfo",
                newName: "IX_CastInfo_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_CastInfo_personid",
                table: "CastInfo",
                newName: "IX_CastInfo_PersonId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Person",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CastInfo_Person_PersonId",
                table: "CastInfo",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CastInfo_Shows_ShowId",
                table: "CastInfo",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id");
        }
    }
}
