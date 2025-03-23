using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBanVeBenXeMienDong.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "LoaiXes",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiXes", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "NhaXes",
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
                    table.PrimaryKey("PK_NhaXes", x => x.MaNhaXe);
                });

            migrationBuilder.CreateTable(
                name: "TaiXes",
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
                    table.PrimaryKey("PK_TaiXes", x => x.MaTaiXe);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKh");
                });

            migrationBuilder.CreateTable(
                name: "CSKHs",
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
                    table.PrimaryKey("PK_CSKHs", x => x.MaCSKH);
                    table.ForeignKey(
                        name: "FK_CSKHs_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CSKHs_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MANV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HovaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MANV);
                    table.ForeignKey(
                        name: "FK_NhanViens_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe");
                });

            migrationBuilder.CreateTable(
                name: "Xes",
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
                        principalColumn: "MaNhaXe");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChuyenXes",
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
                    table.PrimaryKey("PK_ChuyenXes", x => x.MaChuyen);
                    table.ForeignKey(
                        name: "FK_ChuyenXes_Xes_MaXe",
                        column: x => x.MaXe,
                        principalTable: "Xes",
                        principalColumn: "MaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoGheSoGiuongs",
                columns: table => new
                {
                    MaSoGhe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoGheSoGiuongs", x => new { x.MaSoGhe, x.MaXe });
                    table.ForeignKey(
                        name: "FK_SoGheSoGiuongs_Xes_MaXe",
                        column: x => x.MaXe,
                        principalTable: "Xes",
                        principalColumn: "MaXe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeXes",
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
                    table.PrimaryKey("PK_VeXes", x => x.MaVeXe);
                    table.ForeignKey(
                        name: "FK_VeXes_ChuyenXes_MaChuyen",
                        column: x => x.MaChuyen,
                        principalTable: "ChuyenXes",
                        principalColumn: "MaChuyen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeXes_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeXes_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe");
                    table.ForeignKey(
                        name: "FK_VeXes_NhanViens_MANV",
                        column: x => x.MANV,
                        principalTable: "NhanViens",
                        principalColumn: "MANV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeXes_SoGheSoGiuongs_MaSoGhe_MaXe",
                        columns: x => new { x.MaSoGhe, x.MaXe },
                        principalTable: "SoGheSoGiuongs",
                        principalColumns: new[] { "MaSoGhe", "MaXe" });
                });

            migrationBuilder.CreateTable(
                name: "ThanhToans",
                columns: table => new
                {
                    MaGiaoDich = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaKh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaNhaXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaVeXe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToans", x => x.MaGiaoDich);
                    table.ForeignKey(
                        name: "FK_ThanhToans_KhachHangs_MaKh",
                        column: x => x.MaKh,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThanhToans_NhaXes_MaNhaXe",
                        column: x => x.MaNhaXe,
                        principalTable: "NhaXes",
                        principalColumn: "MaNhaXe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThanhToans_VeXes_MaVeXe",
                        column: x => x.MaVeXe,
                        principalTable: "VeXes",
                        principalColumn: "MaVeXe");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MaKh",
                table: "AspNetUsers",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChuyenXes_MaXe",
                table: "ChuyenXes",
                column: "MaXe");

            migrationBuilder.CreateIndex(
                name: "IX_CSKHs_MaKh",
                table: "CSKHs",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_CSKHs_MaNhaXe",
                table: "CSKHs",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_MaNhaXe",
                table: "NhanViens",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_SoGheSoGiuongs_MaXe",
                table: "SoGheSoGiuongs",
                column: "MaXe");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaKh",
                table: "ThanhToans",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaNhaXe",
                table: "ThanhToans",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaVeXe",
                table: "ThanhToans",
                column: "MaVeXe");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_MaChuyen",
                table: "VeXes",
                column: "MaChuyen");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_MaKh",
                table: "VeXes",
                column: "MaKh");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_MaNhaXe",
                table: "VeXes",
                column: "MaNhaXe");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_MANV",
                table: "VeXes",
                column: "MANV");

            migrationBuilder.CreateIndex(
                name: "IX_VeXes_MaSoGhe_MaXe",
                table: "VeXes",
                columns: new[] { "MaSoGhe", "MaXe" });

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CSKHs");

            migrationBuilder.DropTable(
                name: "TaiXes");

            migrationBuilder.DropTable(
                name: "ThanhToans");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "VeXes");

            migrationBuilder.DropTable(
                name: "ChuyenXes");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "SoGheSoGiuongs");

            migrationBuilder.DropTable(
                name: "Xes");

            migrationBuilder.DropTable(
                name: "LoaiXes");

            migrationBuilder.DropTable(
                name: "NhaXes");
        }
    }
}
