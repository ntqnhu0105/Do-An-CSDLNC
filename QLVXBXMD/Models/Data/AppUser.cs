using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QLVXBXMD.Models.Data
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }  // Họ và tên

        [Required]
        [StringLength(12, MinimumLength = 9, ErrorMessage = "CCCD phải từ 9-12 số")]
        public string CCCD { get; set; }  // Căn cước công dân

        [Required]
        [Phone]
        public string SDT { get; set; }  // Số điện thoại
    }
}
