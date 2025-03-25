using System.ComponentModel.DataAnnotations;

namespace QLVXBXMD.Models.System
{
    public class KhachHang
    {
        [Key]
        public string MaKh { get; set; }

        [Required]
        [StringLength(50)]
        public string HovaTen { get; set; }

        [Required]
        [StringLength(11)]
        public string SDT { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(12)]
        public string CCCD { get; set; }
    }
}
