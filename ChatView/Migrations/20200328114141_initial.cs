using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatView.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mcustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerCode = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(maxLength: 60, nullable: true),
                    LastName = table.Column<string>(maxLength: 60, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mcustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Seen = table.Column<bool>(nullable: true),
                    CallOrChat = table.Column<bool>(nullable: true),
                    McustomerFromId = table.Column<Guid>(nullable: true),
                    McustomerToId = table.Column<Guid>(nullable: true),
                    FilePath = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Mcustomers_McustomerFromId",
                        column: x => x.McustomerFromId,
                        principalTable: "Mcustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_Mcustomers_McustomerToId",
                        column: x => x.McustomerToId,
                        principalTable: "Mcustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_McustomerFromId",
                table: "Chats",
                column: "McustomerFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_McustomerToId",
                table: "Chats",
                column: "McustomerToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Mcustomers");
        }
    }
}
