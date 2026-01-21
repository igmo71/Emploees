using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emploees.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdUsers",
                columns: table => new
                {
                    Sid = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    DistinguishedName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdUsers", x => x.Sid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdUsers");
        }
    }
}
