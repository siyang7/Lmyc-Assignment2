using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LmycWeb.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RolesModelRoleId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RolesModel",
                columns: table => new
                {
                    RoleId = table.Column<string>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesModel", x => x.RoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RolesModelRoleId",
                table: "AspNetUsers",
                column: "RolesModelRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RolesModel_RolesModelRoleId",
                table: "AspNetUsers",
                column: "RolesModelRoleId",
                principalTable: "RolesModel",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RolesModel_RolesModelRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RolesModel");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RolesModelRoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RolesModelRoleId",
                table: "AspNetUsers");
        }
    }
}
