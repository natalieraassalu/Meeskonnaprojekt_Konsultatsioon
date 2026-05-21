using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberAuthorReal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Material",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Material",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Material");
        }
    }
}
