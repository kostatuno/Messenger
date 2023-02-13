using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class FriendTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFriends",
                columns: table => new
                {
                    ItsFriendsLogin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MyFriendsLogin = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriends", x => new { x.ItsFriendsLogin, x.MyFriendsLogin });
                    table.ForeignKey(
                        name: "FK_UserFriends_Users_ItsFriendsLogin",
                        column: x => x.ItsFriendsLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFriends_Users_MyFriendsLogin",
                        column: x => x.MyFriendsLogin,
                        principalTable: "Users",
                        principalColumn: "Login");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_MyFriendsLogin",
                table: "UserFriends",
                column: "MyFriendsLogin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFriends");
        }
    }
}
