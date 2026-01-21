using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emploees.Migrations
{
    /// <inheritdoc />
    public partial class CreateCostItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostItems");
        }
    }
}
