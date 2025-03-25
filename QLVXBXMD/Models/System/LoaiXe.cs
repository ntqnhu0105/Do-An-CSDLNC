using System.ComponentModel.DataAnnotations;

namespace QLVXBXMD.Models.System
{
    public class LoaiXe
    {
        [Key]
        public string MaLoai { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoai { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        [Required]
        public int SoLuongGhe { get; set; }
    }
}
