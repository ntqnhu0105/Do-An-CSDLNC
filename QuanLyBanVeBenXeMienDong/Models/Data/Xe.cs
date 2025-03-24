using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class Xe
    {
        [Key] // Đánh dấu khóa chính
        [Column(TypeName = "nvarchar(10)")]
        public string MaXe { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(12)")]
        public string BienSoXe { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string MaLoai { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string MaNhaXe { get; set; }

        // Thiết lập mối quan hệ với LoaiXe
        [ForeignKey("MaLoai")]
        public virtual LoaiXe? LoaiXe { get; set; }

        // Thiết lập mối quan hệ với NhaXe
        [ForeignKey("MaNhaXe")]
        public virtual NhaXe? NhaXe { get; set; }

        // Quan hệ với bảng ChuyenXe
        public virtual ICollection<ChuyenXe>? ChuyenXes { get; set; }

        // Quan hệ với bảng SoGheSoGiuong
        public virtual ICollection<SoGheSoGiuong>? SoGheSoGiuongs { get; set; }
    }
}
