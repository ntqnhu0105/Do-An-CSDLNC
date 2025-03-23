using Microsoft.EntityFrameworkCore;
using QuanLyBanVeXeBenXeMienDong.Models.HeThong;

namespace QuanLyBanVeXeBenXeMienDong.Models
{
    public class BenXeMienDongContext : DbContext
    {
        public BenXeMienDongContext(DbContextOptions<BenXeMienDongContext> options) : base(options) {}
        public DbSet<NhaXe> NhaXes { get; set; }
        public DbSet<LoaiXe> LoaiXes { get; set; }
        public DbSet<TaiXe> TaiXes { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<Xe> Xes { get; set; }
        public DbSet<ChuyenXe> ChuyenXes { get; set; }
        public DbSet<SoGheSoGiuong> SoGheSoGiuongs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<VeXe> VeXes { get; set; }
        public DbSet<ThanhToan> ThanhToans { get; set; }
        public DbSet<CSKH> CSKHs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoGheSoGiuong>()
                .HasKey(s => new { s.MaSoGhe, s.MaXe });

            // Cấu hình mối quan hệ VE_XE -> SoGhe_SoGiuong
            modelBuilder.Entity<VeXe>()
                .HasOne(v => v.SoGheSoGiuong)
                .WithMany()
                .HasForeignKey(v => new { v.MaSoGhe, v.MaXe })
                .OnDelete(DeleteBehavior.NoAction);

            // Cấu hình mối quan hệ VE_XE -> NHAN_VIEN
            modelBuilder.Entity<VeXe>()
                .HasOne(v => v.NhanVien)
                .WithMany()
                .HasForeignKey(v => v.MANV)
                .OnDelete(DeleteBehavior.NoAction);

            // Cấu hình mối quan hệ VE_XE -> NHA_XE
            modelBuilder.Entity<VeXe>()
                .HasOne(v => v.NhaXe)
                .WithMany()
                .HasForeignKey(v => v.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            // Cấu hình mối quan hệ NHAN_VIEN -> NHA_XE
            modelBuilder.Entity<NhanVien>()
                .HasOne(n => n.NhaXe)
                .WithMany()
                .HasForeignKey(n => n.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            // Cấu hình mối quan hệ CHUYEN_XE -> XE
            modelBuilder.Entity<ChuyenXe>()
                .HasOne(c => c.Xe)
                .WithMany()
                .HasForeignKey(c => c.MaXe)
                .OnDelete(DeleteBehavior.NoAction);

            // Cấu hình mối quan hệ VE_XE -> CHUYEN_XE
            modelBuilder.Entity<VeXe>()
                .HasOne(v => v.ChuyenXe)
                .WithMany()
                .HasForeignKey(v => v.MaChuyen)
                .OnDelete(DeleteBehavior.NoAction);

            // Cấu hình mối quan hệ THANH_TOAN -> VE_XE (mới thêm)
            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.VeXe)
                .WithMany()
                .HasForeignKey(t => t.MaVeXe)
                .OnDelete(DeleteBehavior.NoAction);

            // Cấu hình mối quan hệ THANH_TOAN -> NHA_XE (tùy chọn)
            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.NhaXe)
                .WithMany()
                .HasForeignKey(t => t.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            // Cấu hình mối quan hệ THANH_TOAN -> KHACH_HANG (tùy chọn)
            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.KhachHang)
                .WithMany()
                .HasForeignKey(t => t.MaKh)
                .OnDelete(DeleteBehavior.NoAction);

            // Ánh xạ tên bảng
            modelBuilder.Entity<NhaXe>().ToTable("NHA_XE");
            modelBuilder.Entity<LoaiXe>().ToTable("LOAI_XE");
            modelBuilder.Entity<TaiXe>().ToTable("TAI_XE");
            modelBuilder.Entity<KhachHang>().ToTable("KHACH_HANG");
            modelBuilder.Entity<Xe>().ToTable("XE");
            modelBuilder.Entity<ChuyenXe>().ToTable("CHUYEN_XE");
            modelBuilder.Entity<SoGheSoGiuong>().ToTable("SoGhe_SoGiuong");
            modelBuilder.Entity<NhanVien>().ToTable("NHAN_VIEN");
            modelBuilder.Entity<VeXe>().ToTable("VE_XE");
            modelBuilder.Entity<ThanhToan>().ToTable("THANH_TOAN");
            modelBuilder.Entity<CSKH>().ToTable("CSKH");
        }
    }
}
