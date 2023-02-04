using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class modifiedPersonalChatTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_PersonalChats");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "PersonalChats");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "GroupChats",
                newName: "Length");

            migrationBuilder.AddColumn<string>(
                name: "FirstUserLogin",
                table: "PersonalChats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondUserLogin",
                table: "PersonalChats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalChats_FirstUserLogin",
                table: "PersonalChats",
                column: "FirstUserLogin");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalChats_SecondUserLogin",
                table: "PersonalChats",
                column: "SecondUserLogin");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalChats_Users_FirstUserLogin",
                table: "PersonalChats");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalChats_Users_SecondUserLogin",
                table: "PersonalChats");

            migrationBuilder.DropIndex(
                name: "IX_PersonalChats_FirstUserLogin",
                table: "PersonalChats");

            migrationBuilder.DropIndex(
                name: "IX_PersonalChats_SecondUserLogin",
                table: "PersonalChats");

            migrationBuilder.DropColumn(
                name: "FirstUserLogin",
                table: "PersonalChats");

            migrationBuilder.DropColumn(
                name: "SecondUserLogin",
                table: "PersonalChats");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "GroupChats",
                newName: "Count");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "PersonalChats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users_PersonalChats",
                columns: table => new
                {
                    PersonalChatsId = table.Column<int>(type: "int", nullable: false),
                    UsersLogin = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_PersonalChats", x => new { x.PersonalChatsId, x.UsersLogin });
                    table.ForeignKey(
                        name: "FK_Users_PersonalChats_PersonalChats_PersonalChatsId",
                        column: x => x.PersonalChatsId,
                        principalTable: "PersonalChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_PersonalChats_Users_UsersLogin",
                        column: x => x.UsersLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonalChats_UsersLogin",
                table: "Users_PersonalChats",
                column: "UsersLogin");
        }
    }
}
