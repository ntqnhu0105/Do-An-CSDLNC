using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLVXBXMD.Migrations
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
                    MaKh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    MaKhuyenMai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhuyenMai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MucGiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMais", x => x.MaKhuyenMai);
                });

            migrationBuilder.CreateTable(
                name: "LoaiXes",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuongGhe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiXes", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "NhaXes",
                columns: table => new
                {
                    MaNhaXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNhaXe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXes", x => x.MaNhaXe);
                });

            migrationBuilder.CreateTable(
                name: "TaiXes",
                columns: table => new
                {
                    MaTaiXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BangLai = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    KinhNghiem = table.Column<int>(type: "int", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiXes", x => x.MaTaiXe);
                });

            migrationBuilder.CreateTable(
                name: "TuyenXes",
                columns: table => new
                {
                    MaTuyen = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiemDi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiemDen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KhoangCach = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThoiGianDuKien = table.Column<TimeSpan>(type: "time", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GiaThamKhao = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuyenXes", x => x.MaTuyen);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaNhaXe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanViens_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Xes",
                columns: table => new
                {
                    MaXe = table.Column<string>(type: "char(10)", nullable: false),
                    BienSoXe = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    MaLoai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xes", x => x.MaXe);
                    table.ForeignKey(
                        name: "FK_Xes_LoaiXes_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LoaiXes",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Xes_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diems",
                columns: table => new
                {
                    MaDiem = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDiem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaTuyen = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiDiem = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ToaDoGPS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diems", x => x.MaDiem);
                    table.ForeignKey(
                        name: "FK_Diems_TuyenXes_MaTuyen",
                        column: x => x.MaTuyen,
                        principalTable: "TuyenXes",
                        principalColumn: "MaTuyen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenXes",
                columns: table => new
                {
                    MaChuyen = table.Column<string>(type: "char(10)", nullable: false),
                    MaTuyen = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaXe = table.Column<string>(type: "char(10)", nullable: false),
                    NgayKhoiHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioKhoiHanh = table.Column<TimeSpan>(type: "time", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenXes", x => x.MaChuyen);
                    table.ForeignKey(
                        name: "FK_ChuyenXes_TuyenXes_MaTuyen",
                        column: x => x.MaTuyen,
                        principalTable: "TuyenXes",
                        principalColumn: "MaTuyen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChuyenXes_Xes_MaXe",
                        column: x => x.MaXe,
                        principalTable: "Xes",
                        principalColumn: "MaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenXeDiems",
                columns: table => new
                {
                    MaChuyen = table.Column<string>(type: "char(10)", nullable: false),
                    MaDiem = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThoiGianDuKien = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuyenXeDiems", x => new { x.MaChuyen, x.MaDiem });
                    table.ForeignKey(
                        name: "FK_ChuyenXeDiems_ChuyenXes_MaChuyen",
                        column: x => x.MaChuyen,
                        principalTable: "ChuyenXes",
                        principalColumn: "MaChuyen");
                    table.ForeignKey(
                        name: "FK_ChuyenXeDiems_Diems_MaDiem",
                        column: x => x.MaDiem,
                        principalTable: "Diems",
                        principalColumn: "MaDiem");
                });

            migrationBuilder.CreateTable(
                name: "SoGheSoGiuongs",
                columns: table => new
                {
                    MaSoGhe = table.Column<string>(type: "char(10)", nullable: false),
                    MaXe = table.Column<string>(type: "char(10)", nullable: false),
                    MaChuyen = table.Column<string>(type: "char(10)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoGheSoGiuongs", x => new { x.MaSoGhe, x.MaXe, x.MaChuyen });
                    table.ForeignKey(
                        name: "FK_SoGheSoGiuongs_ChuyenXes_MaChuyen",
                        column: x => x.MaChuyen,
                        principalTable: "ChuyenXes",
                        principalColumn: "MaChuyen");
                    table.ForeignKey(
                        name: "FK_SoGheSoGiuongs_Xes_MaXe",
                        column: x => x.MaXe,
                        principalTable: "Xes",
                        principalColumn: "MaXe");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXeDiems_MaDiem",
                table: "ChuyenXeDiems",
                column: "MaDiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXes_MaTuyen",
                table: "ChuyenXes",
                column: "MaTuyen");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXes_MaXe",
                table: "ChuyenXes",
                column: "MaXe");

            migrationBuilder.CreateIndex(
                name: "IX_Diems_MaTuyen",
                table: "Diems",
                column: "MaTuyen");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_MaNhaXe",
                table: "NhanViens",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_SoGheSoGiuongs_MaChuyen",
                table: "SoGheSoGiuongs",
                column: "MaChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_SoGheSoGiuongs_MaXe",
                table: "SoGheSoGiuongs",
                column: "MaXe");

            migrationBuilder.CreateIndex(
                name: "IX_Xes_MaLoai",
                table: "Xes",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Xes_MaNhaXe",
                table: "Xes",
                column: "MaNhaXe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChuyenXeDiems");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "SoGheSoGiuongs");

            migrationBuilder.DropTable(
                name: "TaiXes");

            migrationBuilder.DropTable(
                name: "Diems");

            migrationBuilder.DropTable(
                name: "ChuyenXes");

            migrationBuilder.DropTable(
                name: "TuyenXes");

            migrationBuilder.DropTable(
                name: "Xes");

            migrationBuilder.DropTable(
                name: "LoaiXes");

            migrationBuilder.DropTable(
                name: "NhaXes");
        }
    }
}
