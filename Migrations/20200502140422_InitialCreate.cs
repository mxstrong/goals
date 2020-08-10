﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Mxstrong.Migrations
{
  public partial class InitialCreate : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Users",
          columns: table => new
          {
            UserId = table.Column<string>(nullable: false),
            Email = table.Column<string>(nullable: true),
            PasswordHash = table.Column<byte[]>(nullable: true),
            PasswordSalt = table.Column<byte[]>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Users", x => x.UserId);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Users");
    }
  }
}
