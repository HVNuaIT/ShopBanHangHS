using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopBanHangHS.Migrations
{
    public partial class DBFIST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    maDanhMuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.maDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "Quyen",
                columns: table => new
                {
                    maQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenQuen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quyen", x => x.maQuyen);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    maTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quyen = table.Column<bool>(type: "bit", nullable: false),
                    diaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soDT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    xacThucEmail = table.Column<bool>(type: "bit", nullable: false),
                    ActivationCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.maTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    maSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    danhmucmaDanhMuc = table.Column<int>(type: "int", nullable: true),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    soLuong = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    moTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.maSanPham);
                    table.ForeignKey(
                        name: "FK_SanPham_DanhMuc_danhmucmaDanhMuc",
                        column: x => x.danhmucmaDanhMuc,
                        principalTable: "DanhMuc",
                        principalColumn: "maDanhMuc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    maDatHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsermaTaiKhoan = table.Column<int>(type: "int", nullable: true),
                    diaChiGH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SanPhammaSanPham = table.Column<int>(type: "int", nullable: true),
                    trangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.maDatHang);
                    table.ForeignKey(
                        name: "FK_Order_SanPham_SanPhammaSanPham",
                        column: x => x.SanPhammaSanPham,
                        principalTable: "SanPham",
                        principalColumn: "maSanPham",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_TaiKhoan_UsermaTaiKhoan",
                        column: x => x.UsermaTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "maTaiKhoan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_SanPhammaSanPham",
                table: "Order",
                column: "SanPhammaSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UsermaTaiKhoan",
                table: "Order",
                column: "UsermaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_danhmucmaDanhMuc",
                table: "SanPham",
                column: "danhmucmaDanhMuc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Quyen");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "DanhMuc");
        }
    }
}
