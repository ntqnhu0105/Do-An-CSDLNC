using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QuanLyBanVeBenXeMienDong.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string HovaTen { get; set; }
        public string SDT { get; set; }

        [StringLength(10)]
        public string? MaKh { get; set; }

        [ForeignKey("MaKh")]
        public virtual KhachHang? KhachHang { get; set; }
    }
}
