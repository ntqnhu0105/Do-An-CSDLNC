using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models
{
    public class Xe
    {
        [Key]
        [StringLength(10)]
        public string MaXe { get; set; }

        [Required]
        [StringLength(12)]
        public string BienSoXe { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int SoLuongGhe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLoai { get; set; }

        [ForeignKey("MaNhaXe")]
        public virtual NhaXe NhaXe { get; set; }

        [ForeignKey("MaLoai")]
        public virtual LoaiXe LoaiXe { get; set; }
    }
}
