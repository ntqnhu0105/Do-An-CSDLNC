using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeXeBenXeMienDong.Models.HeThong
{
    public class TaiXe
    {
        [Key]
        [StringLength(10)]
        public string MaTaiXe { get; set; }

        [Required]
        [StringLength(50)]
        public string HovaTen { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [Required]
        [StringLength(12)]
        public string CCCD { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(12)]
        public string BangLai { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Kinh nghiệm phải lớn hơn hoặc bằng 0")]
        public int KinhNghiem { get; set; }
    }
}
