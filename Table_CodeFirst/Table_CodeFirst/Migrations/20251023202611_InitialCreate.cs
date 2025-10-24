using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Table_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguoiCho");

            migrationBuilder.CreateTable(
                name: "ChoNguoi",
                columns: table => new
                {
                    ChuSoHuuId = table.Column<int>(type: "int", nullable: false),
                    DanhSachChoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoNguoi", x => new { x.ChuSoHuuId, x.DanhSachChoId });
                    table.ForeignKey(
                        name: "FK_ChoNguoi_Cho_DanhSachChoId",
                        column: x => x.DanhSachChoId,
                        principalTable: "Cho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoNguoi_Nguoi_ChuSoHuuId",
                        column: x => x.ChuSoHuuId,
                        principalTable: "Nguoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChoNguoi_DanhSachChoId",
                table: "ChoNguoi",
                column: "DanhSachChoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChoNguoi");

            migrationBuilder.CreateTable(
                name: "NguoiCho",
                columns: table => new
                {
                    ChoId = table.Column<int>(type: "int", nullable: false),
                    NguoiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiCho", x => new { x.ChoId, x.NguoiId });
                    table.ForeignKey(
                        name: "FK_NguoiCho_Cho_ChoId",
                        column: x => x.ChoId,
                        principalTable: "Cho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NguoiCho_Nguoi_NguoiId",
                        column: x => x.NguoiId,
                        principalTable: "Nguoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiCho_NguoiId",
                table: "NguoiCho",
                column: "NguoiId");
        }
    }
}
