using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emploees.Migrations
{
    /// <inheritdoc />
    public partial class Create_Пользователь_СхемаПредприятия : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Catalog_Пользователи",
            //    columns: table => new
            //    {
            //        Ref_Key = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        DeletionMark = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Catalog_Пользователи", x => x.Ref_Key);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Catalog_СхемаПредприятия",
            //    columns: table => new
            //    {
            //        Ref_Key = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
            //        Parent_Key = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
            //        Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        DeletionMark = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Catalog_СхемаПредприятия", x => x.Ref_Key);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Пользователь_СхемаПредприятия",
            //    columns: table => new
            //    {
            //        Пользователь_Key = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
            //        СхемаПредприятия_Key = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Пользователь_СхемаПредприятия", x => x.Пользователь_Key);
            //        table.ForeignKey(
            //            name: "FK_Пользователь_СхемаПредприятия_Catalog_Пользователи_Пользователь_Key",
            //            column: x => x.Пользователь_Key,
            //            principalTable: "Catalog_Пользователи",
            //            principalColumn: "Ref_Key",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Пользователь_СхемаПредприятия_Catalog_СхемаПредприятия_СхемаПредприятия_Key",
            //            column: x => x.СхемаПредприятия_Key,
            //            principalTable: "Catalog_СхемаПредприятия",
            //            principalColumn: "Ref_Key");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Пользователь_СхемаПредприятия_СхемаПредприятия_Key",
            //    table: "Пользователь_СхемаПредприятия",
            //    column: "СхемаПредприятия_Key",
            //    unique: true,
            //    filter: "[СхемаПредприятия_Key] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Пользователь_СхемаПредприятия");

            //migrationBuilder.DropTable(
            //    name: "Catalog_Пользователи");

            //migrationBuilder.DropTable(
            //    name: "Catalog_СхемаПредприятия");
        }
    }
}
