using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class initialCasually : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChats_Moderators_ModeratorId",
                table: "GroupChats");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_StatusMessege_StatusId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Moderators");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_StatusMessege_Status",
                table: "StatusMessege");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatusMessege",
                table: "StatusMessege");

            migrationBuilder.RenameTable(
                name: "StatusMessege",
                newName: "MessageStatus");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MessageStatus_Status",
                table: "MessageStatus",
                column: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageStatus",
                table: "MessageStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChats_Users_ModeratorId",
                table: "GroupChats",
                column: "ModeratorId",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageStatus_StatusId",
                table: "Messages",
                column: "StatusId",
                principalTable: "MessageStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChats_Users_ModeratorId",
                table: "GroupChats");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageStatus_StatusId",
                table: "Messages");

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

            migrationBuilder.DropUniqueConstraint(
                name: "AK_MessageStatus_Status",
                table: "MessageStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageStatus",
                table: "MessageStatus");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "MessageStatus",
                newName: "StatusMessege");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_StatusMessege_Status",
                table: "StatusMessege",
                column: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatusMessege",
                table: "StatusMessege",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Moderators",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_StatusMessege_StatusId",
                table: "Messages",
                column: "StatusId",
                principalTable: "StatusMessege",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
