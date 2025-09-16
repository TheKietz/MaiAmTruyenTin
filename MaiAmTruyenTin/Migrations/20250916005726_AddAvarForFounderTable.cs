using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaiAmTruyenTin.Migrations
{
    /// <inheritdoc />
    public partial class AddAvarForFounderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avarta",
                table: "Founders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avarta",
                table: "Founders");
        }
    }
}
