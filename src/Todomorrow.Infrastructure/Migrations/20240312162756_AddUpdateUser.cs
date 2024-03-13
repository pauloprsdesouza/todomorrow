using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todomorrow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollaboratorId",
                schema: "todomorrow",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CollaboratorId",
                schema: "todomorrow",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
