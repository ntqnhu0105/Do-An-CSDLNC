using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class Diem
    {
        [Key] // Đánh dấu khóa chính
        [Column(TypeName = "nvarchar(10)")]
        public string MaDiem { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string TenDiem { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string DiaChi { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string LoaiDiem { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ToaDoGPS { get; set; }

        [Required]
        public string MaTuyen { get; set; }

        // Thiết lập mối quan hệ với TuyenXe
        [ForeignKey("MaTuyen")]
        public virtual TuyenXe? TuyenXe { get; set; }
        public virtual ICollection<ChuyenXe_Diem>? ChuyenXe_Diems { get; set; }
    }
}
