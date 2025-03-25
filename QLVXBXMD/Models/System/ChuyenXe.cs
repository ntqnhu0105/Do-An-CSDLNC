using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLVXBXMD.Models.System
{
    public class ChuyenXe
    {
        [Key]
        [Column(TypeName = "char(10)")] 
        public string MaChuyen { get; set; }

        [Required]
        public string MaTuyen { get; set; }

        [ForeignKey("MaTuyen")]
        public TuyenXe TuyenXe { get; set; }

        [Required]
        public string MaXe { get; set; }

        [ForeignKey("MaXe")]
        public Xe Xe { get; set; }

        [Required]
        public DateTime NgayKhoiHanh { get; set; }

        [Required]
        public TimeSpan GioKhoiHanh { get; set; }

        [Required]
        public decimal Gia { get; set; }

        [Required]
        [StringLength(20)]
        public string TrangThai { get; set; }
        public ICollection<ChuyenXeDiem> ChuyenXeDiems { get; set; }
        public ICollection<SoGheSoGiuong> SoGheSoGiuongs { get; set; }

    }
}
