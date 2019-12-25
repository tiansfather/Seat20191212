using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Migrations
{
    public partial class SeatUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeatUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Avata = table.Column<string>(nullable: true),
                    OpenId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatUser", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatUser");
        }
    }
}
