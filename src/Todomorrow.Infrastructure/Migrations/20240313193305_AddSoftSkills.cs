using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todomorrow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSkills",
                schema: "todomorrow");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "todomorrow",
                table: "SoftSkill",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "SubcategoryId",
                schema: "todomorrow",
                table: "SoftSkill",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequiredSoftSkill",
                schema: "todomorrow",
                columns: table => new
                {
                    ActionItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftSkillId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredSoftSkill", x => new { x.ActionItemId, x.SoftSkillId });
                    table.ForeignKey(
                        name: "FK_RequiredSoftSkill_ActionItem_ActionItemId",
                        column: x => x.ActionItemId,
                        principalSchema: "todomorrow",
                        principalTable: "ActionItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequiredSoftSkill_SoftSkill_SoftSkillId",
                        column: x => x.SoftSkillId,
                        principalSchema: "todomorrow",
                        principalTable: "SoftSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkill",
                schema: "todomorrow",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftSkillId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkill", x => new { x.UserId, x.SoftSkillId });
                    table.ForeignKey(
                        name: "FK_UserSkill_SoftSkill_SoftSkillId",
                        column: x => x.SoftSkillId,
                        principalSchema: "todomorrow",
                        principalTable: "SoftSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkill_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "todomorrow",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subcategory",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "todomorrow",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoftSkill_SubcategoryId",
                schema: "todomorrow",
                table: "SoftSkill",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                schema: "todomorrow",
                table: "Category",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredSoftSkill_SoftSkillId",
                schema: "todomorrow",
                table: "RequiredSoftSkill",
                column: "SoftSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_CategoryId",
                schema: "todomorrow",
                table: "Subcategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_Name",
                schema: "todomorrow",
                table: "Subcategory",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkill_SoftSkillId",
                schema: "todomorrow",
                table: "UserSkill",
                column: "SoftSkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoftSkill_Subcategory_SubcategoryId",
                schema: "todomorrow",
                table: "SoftSkill",
                column: "SubcategoryId",
                principalSchema: "todomorrow",
                principalTable: "Subcategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoftSkill_Subcategory_SubcategoryId",
                schema: "todomorrow",
                table: "SoftSkill");

            migrationBuilder.DropTable(
                name: "RequiredSoftSkill",
                schema: "todomorrow");

            migrationBuilder.DropTable(
                name: "Subcategory",
                schema: "todomorrow");

            migrationBuilder.DropTable(
                name: "UserSkill",
                schema: "todomorrow");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "todomorrow");

            migrationBuilder.DropIndex(
                name: "IX_SoftSkill_SubcategoryId",
                schema: "todomorrow",
                table: "SoftSkill");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                schema: "todomorrow",
                table: "SoftSkill");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "todomorrow",
                table: "SoftSkill",
                newName: "Type");

            migrationBuilder.CreateTable(
                name: "UserSkills",
                schema: "todomorrow",
                columns: table => new
                {
                    SoftSkillsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => new { x.SoftSkillsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserSkills_SoftSkill_SoftSkillsId",
                        column: x => x.SoftSkillsId,
                        principalSchema: "todomorrow",
                        principalTable: "SoftSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkills_User_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "todomorrow",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_UsersId",
                schema: "todomorrow",
                table: "UserSkills",
                column: "UsersId");
        }
    }
}
