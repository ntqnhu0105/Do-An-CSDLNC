using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models
{
    public class SoGheSoGiuong
    {
        [Key, Column(Order = 0)]
        [StringLength(10)]
        public string MaSoGhe { get; set; }

        [StringLength(10)]
        public string? TrangThai { get; set; } // "Đã đặt", "Còn trống", hoặc null

        [Key, Column(Order = 1)]
        [StringLength(10)]
        public string MaXe { get; set; }

        [ForeignKey("MaXe")]
        public virtual Xe Xe { get; set; }
    }
}
