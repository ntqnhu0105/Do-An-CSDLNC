using System.ComponentModel.DataAnnotations;

namespace QLVXBXMD.Models.System
{
    public class NhaXe
    {
        [Key]
        public string MaNhaXe { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNhaXe { get; set; }

        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }
    }
}
