using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Chats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRooms");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomStatus");

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
                name: "PersonalChats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalChats", x => x.Id);
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
                    Count = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_ModeratorId",
                table: "GroupChats",
                column: "ModeratorId",
                unique: true,
                filter: "[ModeratorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_StatusId",
                table: "GroupChats",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupChats_UsersLogin",
                table: "Users_GroupChats",
                column: "UsersLogin");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonalChats_UsersLogin",
                table: "Users_PersonalChats",
                column: "UsersLogin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_GroupChats");

            migrationBuilder.DropTable(
                name: "Users_PersonalChats");

            migrationBuilder.DropTable(
                name: "GroupChats");

            migrationBuilder.DropTable(
                name: "PersonalChats");

            migrationBuilder.DropTable(
                name: "GroupChatStatus");

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
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeratorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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
        }
    }
}
