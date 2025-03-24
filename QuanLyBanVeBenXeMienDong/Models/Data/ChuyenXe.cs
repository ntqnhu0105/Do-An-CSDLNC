using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class ChuyenXe
    {
        [Key] // Xác định đây là khóa chính
        [Column(TypeName = "nvarchar(10)")]
        public string MaChuyen { get; set; }

        [Required]
        public string MaTuyen { get; set; }

        [Required]
        public string MaXe { get; set; }

        [Required]
        public DateTime NgayKhoiHanh { get; set; }

        [Required]
        public TimeSpan GioKhoiHanh { get; set; }

        [Required]
        public decimal Gia { get; set; }

        [Required]
        public string TrangThai { get; set; }

        // Thiết lập mối quan hệ với các bảng khác
        [ForeignKey("MaTuyen")]
        public virtual TuyenXe? TuyenXe { get; set; }

        [ForeignKey("MaXe")]
        public virtual Xe? Xe { get; set; }
        public virtual ICollection<ChuyenXe_Diem>? ChuyenXe_Diems { get; set; }
        public virtual ICollection<SoGheSoGiuong>? SoGheSoGiuongs { get; set; }
    }
}
