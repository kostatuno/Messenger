using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedManyToManyForMessangerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_StatusMessege_StatusId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserName",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "MessageUser");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserName",
                table: "MessageUser",
                newName: "IX_MessageUser_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_StatusId",
                table: "MessageUser",
                newName: "IX_MessageUser_StatusId");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "MessageUser",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "MessageUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageUser",
                table: "MessageUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GroupChats_Messages",
                columns: table => new
                {
                    GroupChatsId = table.Column<int>(type: "int", nullable: false),
                    MessagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChats_Messages", x => new { x.GroupChatsId, x.MessagesId });
                    table.ForeignKey(
                        name: "FK_GroupChats_Messages_GroupChats_GroupChatsId",
                        column: x => x.GroupChatsId,
                        principalTable: "GroupChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupChats_Messages_MessageUser_MessagesId",
                        column: x => x.MessagesId,
                        principalTable: "MessageUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalChats_Messages",
                columns: table => new
                {
                    MessagesId = table.Column<int>(type: "int", nullable: false),
                    PersonalChatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalChats_Messages", x => new { x.MessagesId, x.PersonalChatsId });
                    table.ForeignKey(
                        name: "FK_PersonalChats_Messages_MessageUser_MessagesId",
                        column: x => x.MessagesId,
                        principalTable: "MessageUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalChats_Messages_PersonalChats_PersonalChatsId",
                        column: x => x.PersonalChatsId,
                        principalTable: "PersonalChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_Messages_MessagesId",
                table: "GroupChats_Messages",
                column: "MessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalChats_Messages_PersonalChatsId",
                table: "PersonalChats_Messages",
                column: "PersonalChatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUser_StatusMessege_StatusId",
                table: "MessageUser",
                column: "StatusId",
                principalTable: "StatusMessege",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUser_Users_UserName",
                table: "MessageUser",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageUser_StatusMessege_StatusId",
                table: "MessageUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUser_Users_UserName",
                table: "MessageUser");

            migrationBuilder.DropTable(
                name: "GroupChats_Messages");

            migrationBuilder.DropTable(
                name: "PersonalChats_Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageUser",
                table: "MessageUser");

            migrationBuilder.RenameTable(
                name: "MessageUser",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_MessageUser_UserName",
                table: "Messages",
                newName: "IX_Messages_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_MessageUser_StatusId",
                table: "Messages",
                newName: "IX_Messages_StatusId");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Messages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_StatusMessege_StatusId",
                table: "Messages",
                column: "StatusId",
                principalTable: "StatusMessege",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserName",
                table: "Messages",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
