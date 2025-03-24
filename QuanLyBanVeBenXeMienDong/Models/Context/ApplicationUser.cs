using Microsoft.AspNetCore.Identity;

namespace QuanLyBanVeBenXeMienDong.Models.Context
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
