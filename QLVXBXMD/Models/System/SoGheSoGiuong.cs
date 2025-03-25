using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLVXBXMD.Models.System
{
    public class SoGheSoGiuong
    {
        [Key]
        [Column(TypeName = "char(10)")]
        public string MaSoGhe { get; set; }

        [Key]
        [Column(TypeName = "char(10)")]
        public string MaXe { get; set; }
        public Xe Xe { get; set; } 

        [Key]
        [Column(TypeName = "char(10)")]
        public string MaChuyen { get; set; }
        public ChuyenXe ChuyenXe { get; set; } 

        public string TrangThai { get; set; }
    }
}
