using System.ComponentModel.DataAnnotations;

namespace LVQ_Day09Lab.Models
{
    public class Lvq_HoaDon
    {
        [Key]
        public int Lvq_ID { get; set; }
        public string Lvq_MaHoaDon { get; set; }
        public int Lvq_KhachHangID { get; set; }
        public Lvq_KhachHang Lvq_KhachHang { get; set; }

        public DateTime Lvq_NgayHoaDon { get; set; }
        public DateTime Lvq_NgayNhan { get; set; }
        public string Lvq_HoTenKhachHang { get; set; }
        public string Lvq_Email { get; set; }
        public string Lvq_DienThoai { get; set; }
        public string Lvq_DiaChi { get; set; }
        public decimal Lvq_TongTriGia { get; set; }
        public bool Lvq_TrangThai { get; set; }

        public ICollection<Lvq_ChiTietHoaDon> Lvq_ChiTietHoaDons { get; set; }
    }
}
