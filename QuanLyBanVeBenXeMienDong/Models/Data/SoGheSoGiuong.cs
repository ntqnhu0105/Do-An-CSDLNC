using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanVeBenXeMienDong.Models.Data
{
    public class SoGheSoGiuong
    {
        public string MaSoGhe { get; set; }
        public string MaXe { get; set; }
        public string MaChuyen { get; set; }
        public string TrangThai { get; set; }

        // Navigation properties
        public virtual Xe? Xe { get; set; }
        public virtual ChuyenXe? ChuyenXe { get; set; }
    }
}
