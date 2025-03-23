using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models
{
    public class ChuyenXe
    {
        [Key]
        [StringLength(10)]
        public string MaChuyen { get; set; }

        [Required]
        public DateTime NgayKhoiHanh { get; set; }

        [Required]
        public TimeSpan GioKhoiHanh { get; set; }

        [Required]
        [StringLength(100)]
        public string DiemDi { get; set; }

        [Required]
        [StringLength(100)]
        public string DiemDen { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Gia { get; set; }

        [Required]
        [StringLength(10)]
        public string MaXe { get; set; }

        [ForeignKey("MaXe")]
        public virtual Xe Xe { get; set; }
    }
}
