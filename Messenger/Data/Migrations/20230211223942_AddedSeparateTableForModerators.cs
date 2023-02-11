using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeparateTableForModerators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChats_Users_ModeratorId",
                table: "GroupChats");

            migrationBuilder.DropIndex(
                name: "IX_GroupChats_ModeratorId",
                table: "GroupChats");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Moderators",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderators", x => x.Login);
                    table.ForeignKey(
                        name: "FK_Moderators_Users_Login",
                        column: x => x.Login,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_ModeratorId",
                table: "GroupChats",
                column: "ModeratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChats_Moderators_ModeratorId",
                table: "GroupChats",
                column: "ModeratorId",
                principalTable: "Moderators",
                principalColumn: "Login",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChats_Moderators_ModeratorId",
                table: "GroupChats");

            migrationBuilder.DropTable(
                name: "Moderators");

            migrationBuilder.DropIndex(
                name: "IX_GroupChats_ModeratorId",
                table: "GroupChats");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_ModeratorId",
                table: "GroupChats",
                column: "ModeratorId",
                unique: true,
                filter: "[ModeratorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChats_Users_ModeratorId",
                table: "GroupChats",
                column: "ModeratorId",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
