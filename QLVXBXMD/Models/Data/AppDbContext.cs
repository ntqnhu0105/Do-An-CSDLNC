using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLVXBXMD.Models.System;
namespace QLVXBXMD.Models.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhaXe> NhaXes { get; set; }
        public DbSet<LoaiXe> LoaiXes { get; set; }
        public DbSet<TaiXe> TaiXes { get; set; }
        public DbSet<TuyenXe> TuyenXes { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<Xe> Xes { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Diem> Diems { get; set; }
        public DbSet<ChuyenXe> ChuyenXes { get; set; }
        public DbSet<ChuyenXeDiem> ChuyenXeDiems { get; set; }
        public DbSet<SoGheSoGiuong> SoGheSoGiuongs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Định nghĩa khóa chính cho bảng ChuyenXeDiem (Bảng trung gian)
            modelBuilder.Entity<SoGheSoGiuong>()
                .HasKey(sg => new { sg.MaSoGhe, sg.MaXe, sg.MaChuyen });

            modelBuilder.Entity<SoGheSoGiuong>()
                .HasOne(sg => sg.Xe)
                .WithMany(x => x.SoGheSoGiuongs)
                .HasForeignKey(sg => sg.MaXe)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<SoGheSoGiuong>()
                .HasOne(sg => sg.ChuyenXe)
                .WithMany(cx => cx.SoGheSoGiuongs)
                .HasForeignKey(sg => sg.MaChuyen)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChuyenXeDiem>()
                .HasKey(cd => new { cd.MaChuyen, cd.MaDiem });

            modelBuilder.Entity<ChuyenXeDiem>()
                .HasOne(cd => cd.ChuyenXe)
                .WithMany(c => c.ChuyenXeDiems)
                .HasForeignKey(cd => cd.MaChuyen)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ChuyenXeDiem>()
                .HasOne(cd => cd.Diem)
                .WithMany(d => d.ChuyenXeDiems)
                .HasForeignKey(cd => cd.MaDiem)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}