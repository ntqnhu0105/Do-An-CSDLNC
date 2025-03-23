using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeXeBenXeMienDong.Models.HeThong
{
    public enum TrangThaiGhe
    {
        DaDat,
        ConTrong
    }
    public class SoGheSoGiuong
    {
        [Key, Column(Order = 0)]
        [StringLength(10)]
        public string MaSoGhe { get; set; }

        public TrangThaiGhe? TrangThai { get; set; } // Nullable để hỗ trợ NULL

        [Key, Column(Order = 1)]
        [StringLength(10)]
        public string MaXe { get; set; }

        [ForeignKey("MaXe")]
        public virtual Xe Xe { get; set; }
    }
}
