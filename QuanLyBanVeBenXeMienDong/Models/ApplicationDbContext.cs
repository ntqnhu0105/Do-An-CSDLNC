using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuanLyBanVeBenXeMienDong.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SoGheSoGiuong>()
                .HasKey(s => new { s.MaSoGhe, s.MaXe });

            // Ràng buộc giá trị cho TrangThai trong SoGhe_SoGiuong
            modelBuilder.Entity<SoGheSoGiuong>()
                .Property(s => s.TrangThai)
                .HasMaxLength(10)
                .IsUnicode(true);

            // Ràng buộc giá trị cho TrangThai trong ThanhToan
            modelBuilder.Entity<ThanhToan>()
                .Property(t => t.TrangThai)
                .HasMaxLength(20)
                .IsUnicode(true);

            // Vô hiệu hóa cascade delete cho VeXe -> NhaXe
            modelBuilder.Entity<VeXe>()
                .HasOne(v => v.NhaXe)
                .WithMany()
                .HasForeignKey(v => v.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            // Vô hiệu hóa cascade delete cho NhanVien -> NhaXe
            modelBuilder.Entity<NhanVien>()
                .HasOne(n => n.NhaXe)
                .WithMany()
                .HasForeignKey(n => n.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            // Vô hiệu hóa cascade delete cho Xe -> NhaXe
            modelBuilder.Entity<Xe>()
                .HasOne(x => x.NhaXe)
                .WithMany()
                .HasForeignKey(x => x.MaNhaXe)
                .OnDelete(DeleteBehavior.NoAction);

            // Vô hiệu hóa cascade delete cho VeXe -> SoGheSoGiuong
            modelBuilder.Entity<VeXe>()
                .HasOne(v => v.SoGheSoGiuong)
                .WithMany()
                .HasForeignKey(v => new { v.MaSoGhe, v.MaXe })
                .OnDelete(DeleteBehavior.NoAction);

            // Vô hiệu hóa cascade delete cho ThanhToan -> VeXe
            modelBuilder.Entity<ThanhToan>()
                .HasOne(t => t.VeXe)
                .WithMany()
                .HasForeignKey(t => t.MaVeXe)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
