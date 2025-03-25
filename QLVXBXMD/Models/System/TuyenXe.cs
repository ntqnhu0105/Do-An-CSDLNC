using System.ComponentModel.DataAnnotations;

namespace QLVXBXMD.Models.System
{
    public class TuyenXe
    {
        [Key]
        public string MaTuyen { get; set; }

        [Required]
        [StringLength(100)]
        public string DiemDi { get; set; }

        [Required]
        [StringLength(100)]
        public string DiemDen { get; set; }

        [Required]
        public decimal KhoangCach { get; set; }

        [Required]
        public TimeSpan ThoiGianDuKien { get; set; }

        [StringLength(200)]
        public string MoTa { get; set; }

        public decimal? GiaThamKhao { get; set; }
    }
}
