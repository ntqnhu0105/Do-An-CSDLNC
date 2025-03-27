﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLVXBXMD.Models.Data;

#nullable disable

namespace QLVXBXMD.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250325174654_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QLVXBXMD.Models.Data.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.ChuyenXe", b =>
                {
                    b.Property<string>("MaChuyen")
                        .HasColumnType("char(10)");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<TimeSpan>("GioKhoiHanh")
                        .HasColumnType("time");

                    b.Property<string>("MaTuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaXe")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.Property<DateTime>("NgayKhoiHanh")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MaChuyen");

                    b.HasIndex("MaTuyen");

                    b.HasIndex("MaXe");

                    b.ToTable("ChuyenXes");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.ChuyenXeDiem", b =>
                {
                    b.Property<string>("MaChuyen")
                        .HasColumnType("char(10)");

                    b.Property<string>("MaDiem")
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("ThoiGianDuKien")
                        .HasColumnType("time");

                    b.HasKey("MaChuyen", "MaDiem");

                    b.HasIndex("MaDiem");

                    b.ToTable("ChuyenXeDiems");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.Diem", b =>
                {
                    b.Property<string>("MaDiem")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LoaiDiem")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MaTuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenDiem")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ToaDoGPS")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaDiem");

                    b.HasIndex("MaTuyen");

                    b.ToTable("Diems");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.KhachHang", b =>
                {
                    b.Property<string>("MaKh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HovaTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("MaKh");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.KhuyenMai", b =>
                {
                    b.Property<string>("MaKhuyenMai")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("MucGiamGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenKhuyenMai")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaKhuyenMai");

                    b.ToTable("KhuyenMais");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.LoaiXe", b =>
                {
                    b.Property<string>("MaLoai")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SoLuongGhe")
                        .HasColumnType("int");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoai");

                    b.ToTable("LoaiXes");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.NhaXe", b =>
                {
                    b.Property<string>("MaNhaXe")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("TenNhaXe")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaNhaXe");

                    b.ToTable("NhaXes");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.NhanVien", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HovaTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MaNhaXe")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("MaNV");

                    b.HasIndex("MaNhaXe");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.SoGheSoGiuong", b =>
                {
                    b.Property<string>("MaSoGhe")
                        .HasColumnType("char(10)");

                    b.Property<string>("MaXe")
                        .HasColumnType("char(10)");

                    b.Property<string>("MaChuyen")
                        .HasColumnType("char(10)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSoGhe", "MaXe", "MaChuyen");

                    b.HasIndex("MaChuyen");

                    b.HasIndex("MaXe");

                    b.ToTable("SoGheSoGiuongs");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.TaiXe", b =>
                {
                    b.Property<string>("MaTaiXe")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BangLai")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HovaTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("KinhNghiem")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("MaTaiXe");

                    b.ToTable("TaiXes");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.TuyenXe", b =>
                {
                    b.Property<string>("MaTuyen")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiemDen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DiemDi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("GiaThamKhao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("KhoangCach")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<TimeSpan>("ThoiGianDuKien")
                        .HasColumnType("time");

                    b.HasKey("MaTuyen");

                    b.ToTable("TuyenXes");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.Xe", b =>
                {
                    b.Property<string>("MaXe")
                        .HasColumnType("char(10)");

                    b.Property<string>("BienSoXe")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("MaLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaNhaXe")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaXe");

                    b.HasIndex("MaLoai");

                    b.HasIndex("MaNhaXe");

                    b.ToTable("Xes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("QLVXBXMD.Models.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("QLVXBXMD.Models.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLVXBXMD.Models.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("QLVXBXMD.Models.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.ChuyenXe", b =>
                {
                    b.HasOne("QLVXBXMD.Models.System.TuyenXe", "TuyenXe")
                        .WithMany()
                        .HasForeignKey("MaTuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLVXBXMD.Models.System.Xe", "Xe")
                        .WithMany()
                        .HasForeignKey("MaXe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TuyenXe");

                    b.Navigation("Xe");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.ChuyenXeDiem", b =>
                {
                    b.HasOne("QLVXBXMD.Models.System.ChuyenXe", "ChuyenXe")
                        .WithMany("ChuyenXeDiems")
                        .HasForeignKey("MaChuyen")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QLVXBXMD.Models.System.Diem", "Diem")
                        .WithMany("ChuyenXeDiems")
                        .HasForeignKey("MaDiem")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChuyenXe");

                    b.Navigation("Diem");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.Diem", b =>
                {
                    b.HasOne("QLVXBXMD.Models.System.TuyenXe", "TuyenXe")
                        .WithMany()
                        .HasForeignKey("MaTuyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TuyenXe");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.NhanVien", b =>
                {
                    b.HasOne("QLVXBXMD.Models.System.NhaXe", "NhaXe")
                        .WithMany()
                        .HasForeignKey("MaNhaXe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaXe");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.SoGheSoGiuong", b =>
                {
                    b.HasOne("QLVXBXMD.Models.System.ChuyenXe", "ChuyenXe")
                        .WithMany("SoGheSoGiuongs")
                        .HasForeignKey("MaChuyen")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("QLVXBXMD.Models.System.Xe", "Xe")
                        .WithMany("SoGheSoGiuongs")
                        .HasForeignKey("MaXe")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ChuyenXe");

                    b.Navigation("Xe");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.Xe", b =>
                {
                    b.HasOne("QLVXBXMD.Models.System.LoaiXe", "LoaiXe")
                        .WithMany()
                        .HasForeignKey("MaLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLVXBXMD.Models.System.NhaXe", "NhaXe")
                        .WithMany()
                        .HasForeignKey("MaNhaXe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiXe");

                    b.Navigation("NhaXe");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.ChuyenXe", b =>
                {
                    b.Navigation("ChuyenXeDiems");

                    b.Navigation("SoGheSoGiuongs");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.Diem", b =>
                {
                    b.Navigation("ChuyenXeDiems");
                });

            modelBuilder.Entity("QLVXBXMD.Models.System.Xe", b =>
                {
                    b.Navigation("SoGheSoGiuongs");
                });
#pragma warning restore 612, 618
        }
    }
}
