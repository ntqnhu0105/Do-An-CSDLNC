using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models
{
    public class KhachHang
    {
        [Key]
        [StringLength(10)]
        public string MaKh { get; set; }

        [Required]
        [StringLength(50)]
        public string HovaTen { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
