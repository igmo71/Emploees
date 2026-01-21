using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emploees.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmploees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emploees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    JobTitleId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CostItemId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    DepartmentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    CityId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    LocationId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UserUtId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    UserAdId = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    EmploeeBuhId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    EmploeeZupId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    OperationManagerId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true),
                    LocationManagerId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emploees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emploees_AdUsers_UserAdId",
                        column: x => x.UserAdId,
                        principalTable: "AdUsers",
                        principalColumn: "Sid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emploees_Catalog_Пользователи_UserUtId",
                        column: x => x.UserUtId,
                        principalTable: "Catalog_Пользователи",
                        principalColumn: "Ref_Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emploees_Catalog_Сотрудники_Buh_EmploeeBuhId",
                        column: x => x.EmploeeBuhId,
                        principalTable: "Catalog_Сотрудники_Buh",
                        principalColumn: "Ref_Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emploees_Catalog_Сотрудники_Zup_EmploeeZupId",
                        column: x => x.EmploeeZupId,
                        principalTable: "Catalog_Сотрудники_Zup",
                        principalColumn: "Ref_Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emploees_Catalog_СхемаПредприятия_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Catalog_СхемаПредприятия",
                        principalColumn: "Ref_Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emploees_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emploees_CostItems_CostItemId",
                        column: x => x.CostItemId,
                        principalTable: "CostItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emploees_Emploees_LocationManagerId",
                        column: x => x.LocationManagerId,
                        principalTable: "Emploees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emploees_Emploees_OperationManagerId",
                        column: x => x.OperationManagerId,
                        principalTable: "Emploees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emploees_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emploees_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_CityId",
                table: "Emploees",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_CostItemId",
                table: "Emploees",
                column: "CostItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_DepartmentId",
                table: "Emploees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_EmploeeBuhId",
                table: "Emploees",
                column: "EmploeeBuhId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_EmploeeZupId",
                table: "Emploees",
                column: "EmploeeZupId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_JobTitleId",
                table: "Emploees",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_LocationId",
                table: "Emploees",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_LocationManagerId",
                table: "Emploees",
                column: "LocationManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_OperationManagerId",
                table: "Emploees",
                column: "OperationManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_UserAdId",
                table: "Emploees",
                column: "UserAdId");

            migrationBuilder.CreateIndex(
                name: "IX_Emploees_UserUtId",
                table: "Emploees",
                column: "UserUtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emploees");
        }
    }
}
