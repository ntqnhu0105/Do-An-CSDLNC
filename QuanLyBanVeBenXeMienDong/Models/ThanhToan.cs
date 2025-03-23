using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models
{
    public class ThanhToan
    {
        [Key]
        [StringLength(10)]
        public string MaGiaoDich { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKh { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaVeXe { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal SoTien { get; set; }

        [Required]
        [StringLength(50)]
        public string PhuongThucThanhToan { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; } // "Hoàn tất", "Chưa thanh toán", "Đã hủy"

        [ForeignKey("MaNhaXe")]
        public virtual NhaXe NhaXe { get; set; }

        [ForeignKey("MaKh")]
        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey("MaVeXe")]
        public virtual VeXe VeXe { get; set; }
    }
}
