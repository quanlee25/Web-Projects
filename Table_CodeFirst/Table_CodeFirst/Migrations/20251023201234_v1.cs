using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Table_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Giong = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nguoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tuoi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nguoi", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NguoiCho");

            migrationBuilder.DropTable(
                name: "Cho");

            migrationBuilder.DropTable(
                name: "Nguoi");
        }
    }
}
