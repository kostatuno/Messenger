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

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserName",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalChats_Users_FirstUserLogin",
                table: "PersonalChats");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalChats_Users_SecondUserLogin",
                table: "PersonalChats");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupChats_Users_UsersLogin",
                table: "Users_GroupChats");

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
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moderators", x => x.Login);
                    table.ForeignKey(
                        name: "FK_Moderators_UserStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "UserStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_ModeratorId",
                table: "GroupChats",
                column: "ModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Moderators_StatusId",
                table: "Moderators",
                column: "StatusId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserName",
                table: "Messages",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalChats_Users_FirstUserLogin",
                table: "PersonalChats",
                column: "FirstUserLogin",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalChats_Users_SecondUserLogin",
                table: "PersonalChats",
                column: "SecondUserLogin",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupChats_Users_UsersLogin",
                table: "Users_GroupChats",
                column: "UsersLogin",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
