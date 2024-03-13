using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todomorrow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "todomorrow");

            migrationBuilder.CreateTable(
                name: "Organization",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftSkill",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftSkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "todomorrow",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    AdmissionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ResignationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "todomorrow",
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "todomorrow",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Epic",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Epic_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "todomorrow",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "WorkItem",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EpicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItem_Epic_EpicId",
                        column: x => x.EpicId,
                        principalSchema: "todomorrow",
                        principalTable: "Epic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionItem",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    StartedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CompletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionItem_WorkItem_WorkItemId",
                        column: x => x.WorkItemId,
                        principalSchema: "todomorrow",
                        principalTable: "WorkItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_Name",
                schema: "todomorrow",
                table: "ActionItem",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_WorkItemId",
                schema: "todomorrow",
                table: "ActionItem",
                column: "WorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Epic_ProjectId",
                schema: "todomorrow",
                table: "Epic",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Name",
                schema: "todomorrow",
                table: "Organization",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Name",
                schema: "todomorrow",
                table: "Project",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OrganizationId",
                schema: "todomorrow",
                table: "Project",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "todomorrow",
                table: "User",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganizationId",
                schema: "todomorrow",
                table: "User",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                schema: "todomorrow",
                table: "User",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_UsersId",
                schema: "todomorrow",
                table: "UserSkills",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_EpicId",
                schema: "todomorrow",
                table: "WorkItem",
                column: "EpicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionItem",
                schema: "todomorrow");

            migrationBuilder.DropTable(
                name: "UserSkills",
                schema: "todomorrow");

            migrationBuilder.DropTable(
                name: "WorkItem",
                schema: "todomorrow");

            migrationBuilder.DropTable(
                name: "SoftSkill",
                schema: "todomorrow");

            migrationBuilder.DropTable(
                name: "User",
                schema: "todomorrow");

            migrationBuilder.DropTable(
                name: "Epic",
                schema: "todomorrow");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "todomorrow");

            migrationBuilder.DropTable(
                name: "Organization",
                schema: "todomorrow");
        }
    }
}
