using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emploees.Migrations
{
    /// <inheritdoc />
    public partial class CreateCatalog_Сотрудники_Buh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog_Сотрудники_Buh",
                columns: table => new
                {
                    Ref_Key = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DeletionMark = table.Column<bool>(type: "bit", nullable: false),
                    ВАрхиве = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_Сотрудники_Buh", x => x.Ref_Key);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog_Сотрудники_Buh");
        }
    }
}
