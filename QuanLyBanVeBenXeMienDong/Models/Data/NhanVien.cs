using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class NhanVien
    {
        [Key]
        [StringLength(10)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(50)]
        public string HovaTen { get; set; }

        [Required]
        [StringLength(12)]
        public string CCCD { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? DiaChi { get; set; }

        public DateTime? NgaySinh { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [ForeignKey("MaNhaXe")]
        public NhaXe NhaXe { get; set; }

        [Required]
        [StringLength(50)]
        public string ChucVu { get; set; }
    }
}
