using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLVXBXMD.Models.System
{
    public class Xe
    {
        [Key]
        [Column(TypeName = "char(10)")] 
        public string MaXe { get; set; }

        [Required]
        [StringLength(12)]
        public string BienSoXe { get; set; }

        [Required]
        public string MaLoai { get; set; }

        [ForeignKey("MaLoai")]
        public LoaiXe LoaiXe { get; set; }

        [Required]
        public string MaNhaXe { get; set; }

        [ForeignKey("MaNhaXe")]
        public NhaXe NhaXe { get; set; }
        public ICollection<SoGheSoGiuong> SoGheSoGiuongs { get; set; }

    }
}
