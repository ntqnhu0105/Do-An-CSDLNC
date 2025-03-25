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
    [Migration("20250325152642_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
