using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAlternateKeyForPersonalChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_StatusMessege_StatusId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "StatusMessege");

            migrationBuilder.DropTable(
                name: "UsersRooms");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomStatus");

            migrationBuilder.DropColumn(
                name: "IsWriting",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Messages",
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
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GroupChatStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChatStatus", x => x.Id);
                    table.UniqueConstraint("AK_GroupChatStatus_Status", x => x.Status);
                });

            migrationBuilder.CreateTable(
                name: "MessageStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageStatus", x => x.Id);
                    table.UniqueConstraint("AK_MessageStatus_Status", x => x.Status);
                });

            migrationBuilder.CreateTable(
                name: "PersonalChats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstUserLogin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SecondUserLogin = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalChats", x => x.Id);
                    table.UniqueConstraint("AK_PersonalChats_FirstUserLogin_SecondUserLogin", x => new { x.FirstUserLogin, x.SecondUserLogin });
                    table.ForeignKey(
                        name: "FK_PersonalChats_Users_FirstUserLogin",
                        column: x => x.FirstUserLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalChats_Users_SecondUserLogin",
                        column: x => x.SecondUserLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "GroupChats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ModeratorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: false),
                    IsFull = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupChats_GroupChatStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "GroupChatStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupChats_Users_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.SetNull);
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
                        name: "FK_PersonalChats_Messages_Messages_MessagesId",
                        column: x => x.MessagesId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalChats_Messages_PersonalChats_PersonalChatsId",
                        column: x => x.PersonalChatsId,
                        principalTable: "PersonalChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_GroupChats_Messages_Messages_MessagesId",
                        column: x => x.MessagesId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_GroupChats",
                columns: table => new
                {
                    GroupChatsId = table.Column<int>(type: "int", nullable: false),
                    UsersLogin = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_GroupChats", x => new { x.GroupChatsId, x.UsersLogin });
                    table.ForeignKey(
                        name: "FK_Users_GroupChats_GroupChats_GroupChatsId",
                        column: x => x.GroupChatsId,
                        principalTable: "GroupChats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_GroupChats_Users_UsersLogin",
                        column: x => x.UsersLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GroupChatStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Сlosed" },
                    { 2, "Open" },
                    { 3, "Full" }
                });

            migrationBuilder.InsertData(
                table: "MessageStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "NotRead" },
                    { 2, "Read" },
                    { 3, "Changed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_ModeratorId",
                table: "GroupChats",
                column: "ModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_StatusId",
                table: "GroupChats",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_Messages_MessagesId",
                table: "GroupChats_Messages",
                column: "MessagesId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalChats_SecondUserLogin",
                table: "PersonalChats",
                column: "SecondUserLogin");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalChats_Messages_PersonalChatsId",
                table: "PersonalChats_Messages",
                column: "PersonalChatsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_MyFriendsLogin",
                table: "UserFriends",
                column: "MyFriendsLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupChats_UsersLogin",
                table: "Users_GroupChats",
                column: "UsersLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessageStatus_StatusId",
                table: "Messages",
                column: "StatusId",
                principalTable: "MessageStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessageStatus_StatusId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "GroupChats_Messages");

            migrationBuilder.DropTable(
                name: "MessageStatus");

            migrationBuilder.DropTable(
                name: "PersonalChats_Messages");

            migrationBuilder.DropTable(
                name: "UserFriends");

            migrationBuilder.DropTable(
                name: "Users_GroupChats");

            migrationBuilder.DropTable(
                name: "PersonalChats");

            migrationBuilder.DropTable(
                name: "GroupChats");

            migrationBuilder.DropTable(
                name: "GroupChatStatus");

            migrationBuilder.AddColumn<bool>(
                name: "IsWriting",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.CreateTable(
                name: "RoomStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStatus", x => x.Id);
                    table.UniqueConstraint("AK_RoomStatus_Status", x => x.Status);
                });

            migrationBuilder.CreateTable(
                name: "StatusMessege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMessege", x => x.Id);
                    table.UniqueConstraint("AK_StatusMessege_Status", x => x.Status);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeratorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "RoomStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UsersRooms",
                columns: table => new
                {
                    RoomsId = table.Column<int>(type: "int", nullable: false),
                    UsersLogin = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRooms", x => new { x.RoomsId, x.UsersLogin });
                    table.ForeignKey(
                        name: "FK_UsersRooms_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRooms_Users_UsersLogin",
                        column: x => x.UsersLogin,
                        principalTable: "Users",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RoomStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Сlosed" },
                    { 2, "Open" },
                    { 3, "Full" }
                });

            migrationBuilder.InsertData(
                table: "StatusMessege",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "NotRead" },
                    { 2, "Read" },
                    { 3, "Changed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ModeratorId",
                table: "Rooms",
                column: "ModeratorId",
                unique: true,
                filter: "[ModeratorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_StatusId",
                table: "Rooms",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRooms_UsersLogin",
                table: "UsersRooms",
                column: "UsersLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_StatusMessege_StatusId",
                table: "Messages",
                column: "StatusId",
                principalTable: "StatusMessege",
                principalColumn: "Id");
        }
    }
}
