using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todomorrow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPartner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partner",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsOwner = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partner_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "todomorrow",
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partner_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "todomorrow",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partner_OrganizationId",
                schema: "todomorrow",
                table: "Partner",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_UserId",
                schema: "todomorrow",
                table: "Partner",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partner",
                schema: "todomorrow");
        }
    }
}
