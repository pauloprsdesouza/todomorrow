using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todomorrow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFollower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_UserId",
                schema: "todomorrow",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserId",
                schema: "todomorrow",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "todomorrow",
                table: "User");

            migrationBuilder.CreateTable(
                name: "Followers",
                schema: "todomorrow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FolloweeId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Followers_User_FolloweeId",
                        column: x => x.FolloweeId,
                        principalSchema: "todomorrow",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Followers_User_FollowerId",
                        column: x => x.FollowerId,
                        principalSchema: "todomorrow",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FolloweeId",
                schema: "todomorrow",
                table: "Followers",
                column: "FolloweeId");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowerId",
                schema: "todomorrow",
                table: "Followers",
                column: "FollowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Followers",
                schema: "todomorrow");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "todomorrow",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                schema: "todomorrow",
                table: "User",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_UserId",
                schema: "todomorrow",
                table: "User",
                column: "UserId",
                principalSchema: "todomorrow",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
