using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBanVeXeBenXeMienDong.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KHACH_HANG",
                columns: table => new
                {
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHACH_HANG", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "LOAI_XE",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAI_XE", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "NHA_XE",
                columns: table => new
                {
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenNhaXe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHA_XE", x => x.MaNhaXe);
                });

            migrationBuilder.CreateTable(
                name: "TAI_XE",
                columns: table => new
                {
                    MaTaiXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BangLai = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    KinhNghiem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAI_XE", x => x.MaTaiXe);
                });

            migrationBuilder.CreateTable(
                name: "CSKH",
                columns: table => new
                {
                    MaCSKH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayCSKH = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CSKH", x => x.MaCSKH);
                    table.ForeignKey(
                        name: "FK_CSKH_KHACH_HANG_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CSKH_NHA_XE_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NHA_XE",
                        principalColumn: "MaNhaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NHAN_VIEN",
                columns: table => new
                {
                    MANV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHAN_VIEN", x => x.MANV);
                    table.ForeignKey(
                        name: "FK_NHAN_VIEN_NHA_XE_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NHA_XE",
                        principalColumn: "MaNhaXe");
                });

            migrationBuilder.CreateTable(
                name: "XE",
                columns: table => new
                {
                    MaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BienSoXe = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    SoLuongGhe = table.Column<int>(type: "int", nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XE", x => x.MaXe);
                    table.ForeignKey(
                        name: "FK_XE_LOAI_XE_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LOAI_XE",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XE_NHA_XE_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NHA_XE",
                        principalColumn: "MaNhaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CHUYEN_XE",
                columns: table => new
                {
                    MaChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayKhoiHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioKhoiHanh = table.Column<TimeSpan>(type: "time", nullable: false),
                    DiemDi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiemDen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHUYEN_XE", x => x.MaChuyen);
                    table.ForeignKey(
                        name: "FK_CHUYEN_XE_XE_MaXe",
                        column: x => x.MaXe,
                        principalTable: "XE",
                        principalColumn: "MaXe");
                });

            migrationBuilder.CreateTable(
                name: "SoGhe_SoGiuong",
                columns: table => new
                {
                    MaSoGhe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoGhe_SoGiuong", x => new { x.MaSoGhe, x.MaXe });
                    table.ForeignKey(
                        name: "FK_SoGhe_SoGiuong_XE_MaXe",
                        column: x => x.MaXe,
                        principalTable: "XE",
                        principalColumn: "MaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VE_XE",
                columns: table => new
                {
                    MaVeXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaSoGhe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MANV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayDatVe = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VE_XE", x => x.MaVeXe);
                    table.ForeignKey(
                        name: "FK_VE_XE_CHUYEN_XE_MaChuyen",
                        column: x => x.MaChuyen,
                        principalTable: "CHUYEN_XE",
                        principalColumn: "MaChuyen");
                    table.ForeignKey(
                        name: "FK_VE_XE_KHACH_HANG_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VE_XE_NHAN_VIEN_MANV",
                        column: x => x.MANV,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MANV");
                    table.ForeignKey(
                        name: "FK_VE_XE_NHA_XE_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NHA_XE",
                        principalColumn: "MaNhaXe");
                    table.ForeignKey(
                        name: "FK_VE_XE_SoGhe_SoGiuong_MaSoGhe_MaXe",
                        columns: x => new { x.MaSoGhe, x.MaXe },
                        principalTable: "SoGhe_SoGiuong",
                        principalColumns: new[] { "MaSoGhe", "MaXe" });
                });

            migrationBuilder.CreateTable(
                name: "THANH_TOAN",
                columns: table => new
                {
                    MaGiaoDich = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaVeXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THANH_TOAN", x => x.MaGiaoDich);
                    table.ForeignKey(
                        name: "FK_THANH_TOAN_KHACH_HANG_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKh");
                    table.ForeignKey(
                        name: "FK_THANH_TOAN_NHA_XE_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NHA_XE",
                        principalColumn: "MaNhaXe");
                    table.ForeignKey(
                        name: "FK_THANH_TOAN_VE_XE_MaVeXe",
                        column: x => x.MaVeXe,
                        principalTable: "VE_XE",
                        principalColumn: "MaVeXe");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHUYEN_XE_MaXe",
                table: "CHUYEN_XE",
                column: "MaXe");

            migrationBuilder.CreateIndex(
                name: "IX_CSKH_MaKh",
                table: "CSKH",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_CSKH_MaNhaXe",
                table: "CSKH",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_NHAN_VIEN_MaNhaXe",
                table: "NHAN_VIEN",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_SoGhe_SoGiuong_MaXe",
                table: "SoGhe_SoGiuong",
                column: "MaXe");

            migrationBuilder.CreateIndex(
                name: "IX_THANH_TOAN_MaKh",
                table: "THANH_TOAN",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_THANH_TOAN_MaNhaXe",
                table: "THANH_TOAN",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_THANH_TOAN_MaVeXe",
                table: "THANH_TOAN",
                column: "MaVeXe");

            migrationBuilder.CreateIndex(
                name: "IX_VE_XE_MaChuyen",
                table: "VE_XE",
                column: "MaChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_VE_XE_MaKh",
                table: "VE_XE",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_VE_XE_MaNhaXe",
                table: "VE_XE",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_VE_XE_MANV",
                table: "VE_XE",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_VE_XE_MaSoGhe_MaXe",
                table: "VE_XE",
                columns: new[] { "MaSoGhe", "MaXe" });

            migrationBuilder.CreateIndex(
                name: "IX_XE_MaLoai",
                table: "XE",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_XE_MaNhaXe",
                table: "XE",
                column: "MaNhaXe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CSKH");

            migrationBuilder.DropTable(
                name: "TAI_XE");

            migrationBuilder.DropTable(
                name: "THANH_TOAN");

            migrationBuilder.DropTable(
                name: "VE_XE");

            migrationBuilder.DropTable(
                name: "CHUYEN_XE");

            migrationBuilder.DropTable(
                name: "KHACH_HANG");

            migrationBuilder.DropTable(
                name: "NHAN_VIEN");

            migrationBuilder.DropTable(
                name: "SoGhe_SoGiuong");

            migrationBuilder.DropTable(
                name: "XE");

            migrationBuilder.DropTable(
                name: "LOAI_XE");

            migrationBuilder.DropTable(
                name: "NHA_XE");
        }
    }
}
