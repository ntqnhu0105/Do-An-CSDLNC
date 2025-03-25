using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLVXBXMD.Models.System
{
    public class Diem
    {
        [Key]
        public string MaDiem { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDiem { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        public string MaTuyen { get; set; }

        [ForeignKey("MaTuyen")]
        public TuyenXe TuyenXe { get; set; }

        [Required]
        [StringLength(20)]
        public string LoaiDiem { get; set; }

        [StringLength(50)]
        public string ToaDoGPS { get; set; }
        public ICollection<ChuyenXeDiem> ChuyenXeDiems { get; set; }

    }
}
