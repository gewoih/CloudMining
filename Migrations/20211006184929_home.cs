using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudMining.Migrations
{
    public partial class home : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "Members",
                newName: "roleId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fee = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_roleId",
                table: "Members",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Roles_roleId",
                table: "Members",
                column: "roleId",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Roles_roleId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Members_roleId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Members",
                newName: "role");
        }
    }
}
