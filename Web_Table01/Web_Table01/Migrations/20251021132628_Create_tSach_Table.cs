using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Table01.Migrations
{
    /// <inheritdoc />
    public partial class Create_tSach_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tSach",
                columns: table => new
                {
                    MaSach = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TacGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaTheLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaNXB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonGiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    SoTrang = table.Column<int>(type: "int", nullable: false),
                    TrongLuong = table.Column<double>(type: "float", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tSach", x => x.MaSach);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tSach");
        }
    }
}
