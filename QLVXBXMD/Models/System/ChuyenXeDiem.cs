using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLVXBXMD.Models.System
{
    public class ChuyenXeDiem
    {
        public string MaChuyen { get; set; }
        public string MaDiem { get; set; }   
        public TimeSpan ThoiGianDuKien { get; set; }

        [ForeignKey("MaChuyen")]
        public ChuyenXe ChuyenXe { get; set; }

        [ForeignKey("MaDiem")]
        public Diem Diem { get; set; }
    }
}
