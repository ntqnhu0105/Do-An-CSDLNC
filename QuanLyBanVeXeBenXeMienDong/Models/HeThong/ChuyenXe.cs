using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeXeBenXeMienDong.Models.HeThong
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
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0")]
        public decimal Gia { get; set; }

        [Required]
        [StringLength(10)]
        public string MaXe { get; set; }

        [ForeignKey("MaXe")]
        public virtual Xe Xe { get; set; }
    }
}
