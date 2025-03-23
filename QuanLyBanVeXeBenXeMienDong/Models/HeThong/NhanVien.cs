using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeXeBenXeMienDong.Models.HeThong
{
    public class NhanVien
    {
        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [Key]
        [StringLength(10)]
        public string MANV { get; set; }

        [Required]
        [StringLength(50)]
        public string HovaTen { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(12)]
        public string CCCD { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        public DateTime? NgaySinh { get; set; }

        [ForeignKey("MaNhaXe")]
        public virtual NhaXe NhaXe { get; set; }
    }
}
