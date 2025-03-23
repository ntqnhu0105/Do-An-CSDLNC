using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeXeBenXeMienDong.Models.HeThong
{
    public enum TrangThaiThanhToan
    {
        HoanTat,
        ChuaThanhToan,
        DaHuy
    }
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
        [Range(0, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn hoặc bằng 0")]
        public decimal SoTien { get; set; }

        [Required]
        [StringLength(50)]
        public string PhuongThucThanhToan { get; set; }

        [Required]
        public TrangThaiThanhToan TrangThai { get; set; }

        [ForeignKey("MaNhaXe")]
        public virtual NhaXe NhaXe { get; set; }

        [ForeignKey("MaKh")]
        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey("MaVeXe")]
        public virtual VeXe VeXe { get; set; }
    }
}
