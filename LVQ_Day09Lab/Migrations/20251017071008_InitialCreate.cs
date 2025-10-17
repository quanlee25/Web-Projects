using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LVQ_Day09Lab.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Lvq_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lvq_MaKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_HoTenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lvq_TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Lvq_ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    Lvq_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lvq_MaLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.Lvq_ID);
                });

            migrationBuilder.CreateTable(
                name: "QuanTris",
                columns: table => new
                {
                    Lvq_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lvq_TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanTris", x => x.Lvq_ID);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Lvq_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lvq_MaHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_KhachHangID = table.Column<int>(type: "int", nullable: false),
                    Lvq_NgayHoaDon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lvq_NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lvq_HoTenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_TongTriGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lvq_TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Lvq_ID);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_Lvq_KhachHangID",
                        column: x => x.Lvq_KhachHangID,
                        principalTable: "KhachHangs",
                        principalColumn: "Lvq_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Lvq_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lvq_MaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lvq_SoLuong = table.Column<int>(type: "int", nullable: false),
                    Lvq_DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lvq_TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    Lvq_LoaiSanPhamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Lvq_ID);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_Lvq_LoaiSanPhamID",
                        column: x => x.Lvq_LoaiSanPhamID,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "Lvq_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    Lvq_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lvq_HoaDonID = table.Column<int>(type: "int", nullable: false),
                    Lvq_SanPhamID = table.Column<int>(type: "int", nullable: false),
                    Lvq_SoLuongMua = table.Column<int>(type: "int", nullable: false),
                    Lvq_DonGiaMua = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lvq_ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lvq_TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.Lvq_ID);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_Lvq_HoaDonID",
                        column: x => x.Lvq_HoaDonID,
                        principalTable: "HoaDons",
                        principalColumn: "Lvq_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_SanPhams_Lvq_SanPhamID",
                        column: x => x.Lvq_SanPhamID,
                        principalTable: "SanPhams",
                        principalColumn: "Lvq_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_Lvq_HoaDonID",
                table: "ChiTietHoaDons",
                column: "Lvq_HoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_Lvq_SanPhamID",
                table: "ChiTietHoaDons",
                column: "Lvq_SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_Lvq_KhachHangID",
                table: "HoaDons",
                column: "Lvq_KhachHangID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_Lvq_LoaiSanPhamID",
                table: "SanPhams",
                column: "Lvq_LoaiSanPhamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "QuanTris");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");
        }
    }
}
