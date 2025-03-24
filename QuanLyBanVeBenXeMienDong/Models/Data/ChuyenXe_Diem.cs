using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class ChuyenXe_Diem
    {
        public string MaChuyen { get; set; }
        public string MaDiem { get; set; }
        public TimeSpan ThoiGianDuKien { get; set; }

        // Navigation properties
        public virtual ChuyenXe? ChuyenXe { get; set; }
        public virtual Diem? Diem { get; set; }
    }
}
