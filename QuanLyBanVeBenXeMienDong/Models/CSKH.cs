using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models
{
    public class CSKH
    {
        [Required]
        [StringLength(10)]
        public string MaNhaXe { get; set; }

        [Required]
        [StringLength(10)]
        public string MaKh { get; set; }

        [Key]
        [StringLength(10)]
        public string MaCSKH { get; set; }

        [Required]
        [StringLength(50)]
        public string MoTa { get; set; }

        [Required]
        public DateTime NgayCSKH { get; set; } = DateTime.Now;

        [ForeignKey("MaNhaXe")]
        public virtual NhaXe NhaXe { get; set; }

        [ForeignKey("MaKh")]
        public virtual KhachHang KhachHang { get; set; }
    }
}
