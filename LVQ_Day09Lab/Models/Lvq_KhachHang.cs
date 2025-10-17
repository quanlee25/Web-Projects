using System.ComponentModel.DataAnnotations;

namespace LVQ_Day09Lab.Models
{
    public class Lvq_KhachHang
    {
        [Key]
        public int Lvq_ID { get; set; }
        public string Lvq_MaKhachHang { get; set; }
        public string Lvq_HoTenKhachHang { get; set; }
        public string Lvq_Email { get; set; }
        public string Lvq_MatKhau { get; set; }
        public string Lvq_DienThoai { get; set; }
        public string Lvq_DiaChi { get; set; }
        public DateTime Lvq_NgayDangKy { get; set; }
        public bool Lvq_TrangThai { get; set; }

        public ICollection<Lvq_HoaDon> Lvq_HoaDons { get; set; }
    }
}
