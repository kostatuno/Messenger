using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChats_Messages_MessageUser_MessagesId",
                table: "GroupChats_Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUser_StatusMessege_StatusId",
                table: "MessageUser");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUser_Users_UserName",
                table: "MessageUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalChats_Messages_MessageUser_MessagesId",
                table: "PersonalChats_Messages");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChats_Messages_Messages_MessagesId",
                table: "GroupChats_Messages",
                column: "MessagesId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_StatusMessege_StatusId",
                table: "Messages",
                column: "StatusId",
                principalTable: "StatusMessege",
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
                name: "FK_PersonalChats_Messages_Messages_MessagesId",
                table: "PersonalChats_Messages",
                column: "MessagesId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChats_Messages_Messages_MessagesId",
                table: "GroupChats_Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_StatusMessege_StatusId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserName",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalChats_Messages_Messages_MessagesId",
                table: "PersonalChats_Messages");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageUser",
                table: "MessageUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChats_Messages_MessageUser_MessagesId",
                table: "GroupChats_Messages",
                column: "MessagesId",
                principalTable: "MessageUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalChats_Messages_MessageUser_MessagesId",
                table: "PersonalChats_Messages",
                column: "MessagesId",
                principalTable: "MessageUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
