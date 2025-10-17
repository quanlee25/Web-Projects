using System.ComponentModel.DataAnnotations;

namespace LVQ_Day09Lab.Models
{
    public class Lvq_ChiTietHoaDon
    {
        [Key]
        public int Lvq_ID { get; set; }
        public int Lvq_HoaDonID { get; set; }
        public Lvq_HoaDon Lvq_HoaDon { get; set; }

        public int Lvq_SanPhamID { get; set; }
        public Lvq_SanPham Lvq_SanPham { get; set; }

        public int Lvq_SoLuongMua { get; set; }
        public decimal Lvq_DonGiaMua { get; set; }
        public decimal Lvq_ThanhTien { get; set; }
        public bool Lvq_TrangThai { get; set; }
    }
}
