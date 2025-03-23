using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models
{
    public class VeXe
    {
        [Key]
        [StringLength(10)]
        public string MaVeXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSoGhe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaXe { get; set; } // Thêm MaXe để tham chiếu đầy đủ

        [Required]
        [StringLength(10)]
        public string MaChuyen { get; set; }

        [Required]
        [StringLength(10)]
        public string MANV { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKh { get; set; }

        [Required]
        public DateTime NgayDatVe { get; set; }

        [ForeignKey("MaNhaXe")]
        public virtual NhaXe NhaXe { get; set; }

        [ForeignKey("MaChuyen")]
        public virtual ChuyenXe ChuyenXe { get; set; }

        [ForeignKey("MaKh")]
        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey("MANV")]
        public virtual NhanVien NhanVien { get; set; }

        [ForeignKey("MaSoGhe, MaXe")]
        public virtual SoGheSoGiuong SoGheSoGiuong { get; set; }
    }
}
