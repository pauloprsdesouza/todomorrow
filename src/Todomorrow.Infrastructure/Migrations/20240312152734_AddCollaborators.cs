using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todomorrow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCollaborators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Organization_OrganizationId",
                schema: "todomorrow",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_OrganizationId",
                schema: "todomorrow",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AdmissionDate",
                schema: "todomorrow",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                schema: "todomorrow",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResignationDate",
                schema: "todomorrow",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "CollaboratorId",
                schema: "todomorrow",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Collaborator",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdmissionDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ResignationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collaborator_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "todomorrow",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collaborator_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "todomorrow",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_OrganizationId",
                schema: "todomorrow",
                table: "Collaborator",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaborator_UserId",
                schema: "todomorrow",
                table: "Collaborator",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborator",
                schema: "todomorrow");

            migrationBuilder.DropColumn(
                name: "CollaboratorId",
                schema: "todomorrow",
                table: "User");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AdmissionDate",
                schema: "todomorrow",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                schema: "todomorrow",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ResignationDate",
                schema: "todomorrow",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganizationId",
                schema: "todomorrow",
                table: "User",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Organization_OrganizationId",
                schema: "todomorrow",
                table: "User",
                column: "OrganizationId",
                principalSchema: "todomorrow",
                principalTable: "Organization",
                principalColumn: "Id");
        }
    }
}
