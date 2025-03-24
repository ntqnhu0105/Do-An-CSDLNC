using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLyBanVeBenXeMienDong.Models.Data;

namespace QuanLyBanVeBenXeMienDong.Models.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhaXe> NhaXes { get; set; }
        public DbSet<LoaiXe> LoaiXes { get; set; }
        public DbSet<TaiXe> TaiXes { get; set; }
        public DbSet<TuyenXe> TuyenXes { get; set; }
        public DbSet<Xe> Xes { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Diem> Diems { get; set; }
        public DbSet<ChuyenXe> ChuyenXes { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<ChuyenXe_Diem> ChuyenXe_Diems { get; set; }
        public DbSet<SoGheSoGiuong> SoGheSoGiuongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Khóa chính
            modelBuilder.Entity<ChuyenXe>().HasKey(c => c.MaChuyen);
            modelBuilder.Entity<Diem>().HasKey(d => d.MaDiem);
            modelBuilder.Entity<ChuyenXe_Diem>().HasKey(cd => new { cd.MaChuyen, cd.MaDiem });
            modelBuilder.Entity<SoGheSoGiuong>().HasKey(sg => new { sg.MaSoGhe, sg.MaXe, sg.MaChuyen });

            // ✅ Quan hệ giữa ChuyenXe_Diem và ChuyenXe
            modelBuilder.Entity<ChuyenXe_Diem>()
                .HasOne(cd => cd.ChuyenXe)
                .WithMany(c => c.ChuyenXe_Diems)
                .HasForeignKey(cd => cd.MaChuyen)
                .OnDelete(DeleteBehavior.NoAction); // 🔥 Tránh vòng lặp

            // ✅ Quan hệ giữa ChuyenXe_Diem và Diem
            modelBuilder.Entity<ChuyenXe_Diem>()
                .HasOne(cd => cd.Diem)
                .WithMany(d => d.ChuyenXe_Diems)
                .HasForeignKey(cd => cd.MaDiem)
                .OnDelete(DeleteBehavior.Cascade);

            // ✅ Quan hệ giữa SoGheSoGiuong và Xe
            modelBuilder.Entity<SoGheSoGiuong>()
                .HasOne(sg => sg.Xe)
                .WithMany(x => x.SoGheSoGiuongs)
                .HasForeignKey(sg => sg.MaXe)
                .OnDelete(DeleteBehavior.NoAction); // 🔥 Tránh vòng lặp

            // ✅ Quan hệ giữa SoGheSoGiuong và ChuyenXe
            modelBuilder.Entity<SoGheSoGiuong>()
                .HasOne(sg => sg.ChuyenXe)
                .WithMany(cx => cx.SoGheSoGiuongs)
                .HasForeignKey(sg => sg.MaChuyen)
                .OnDelete(DeleteBehavior.NoAction); // 🔥 Tránh vòng lặp

            // ✅ Ràng buộc kiểm tra
            modelBuilder.Entity<ChuyenXe>()
                .Property(c => c.TrangThai)
                .HasDefaultValue("Chưa khởi hành");

            modelBuilder.Entity<ChuyenXe>()
                .ToTable(t => t.HasCheckConstraint("CHK_TrangThai_Chuyen",
                    "TrangThai IN (N'Chưa khởi hành', N'Đã khởi hành', N'Hủy', N'Hoàn thành')"));

            modelBuilder.Entity<Diem>()
                .ToTable(t => t.HasCheckConstraint("CHK_LoaiDiem",
                    "LoaiDiem IN (N'Điểm đón', N'Điểm trả', N'Cả hai')"));

            modelBuilder.Entity<KhuyenMai>()
                .ToTable(t => t.HasCheckConstraint("CHK_MucGiamGia",
                    "MucGiamGia >= 0 AND MucGiamGia <= 100"));
        }
    }
}
