using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updatedNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Todos_PostTitle",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "posts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts",
                table: "posts",
                column: "Title");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_posts_PostTitle",
                table: "Comments",
                column: "PostTitle",
                principalTable: "posts",
                principalColumn: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_posts_PostTitle",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_posts",
                table: "posts");

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "Todos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Title");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Todos_PostTitle",
                table: "Comments",
                column: "PostTitle",
                principalTable: "Todos",
                principalColumn: "Title");
        }
    }
}
