using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todomorrow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSkill",
                schema: "todomorrow",
                table: "UserSkill");

            migrationBuilder.DropColumn(
                name: "Level",
                schema: "todomorrow",
                table: "SoftSkill");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "todomorrow",
                table: "UserSkill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "todomorrow",
                table: "UserSkill",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "todomorrow",
                table: "UserSkill",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "todomorrow",
                table: "UserSkill",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSkill",
                schema: "todomorrow",
                table: "UserSkill",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_UserId",
                schema: "todomorrow",
                table: "UserSkill",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSkill",
                schema: "todomorrow",
                table: "UserSkill");

            migrationBuilder.DropIndex(
                name: "IX_UserSkill_UserId",
                schema: "todomorrow",
                table: "UserSkill");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "todomorrow",
                table: "UserSkill");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "todomorrow",
                table: "UserSkill");

            migrationBuilder.DropColumn(
                name: "Level",
                schema: "todomorrow",
                table: "UserSkill");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "todomorrow",
                table: "UserSkill");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "todomorrow",
                table: "SoftSkill",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSkill",
                schema: "todomorrow",
                table: "UserSkill",
                columns: new[] { "UserId", "SoftSkillId" });
        }
    }
}
