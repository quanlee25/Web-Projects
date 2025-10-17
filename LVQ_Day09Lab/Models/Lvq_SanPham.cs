using System.ComponentModel.DataAnnotations;

namespace LVQ_Day09Lab.Models
{
    public class Lvq_SanPham
    {
        [Key]
        public int Lvq_ID { get; set; }
        public string Lvq_MaSanPham { get; set; }
        public string Lvq_TenSanPham { get; set; }
        public string Lvq_HinhAnh { get; set; }
        public int Lvq_SoLuong { get; set; }
        public decimal Lvq_DonGia { get; set; }
        public bool Lvq_TrangThai { get; set; }

        public int Lvq_LoaiSanPhamID { get; set; }
        public Lvq_LoaiSanPham Lvq_LoaiSanPham { get; set; }

        public ICollection<Lvq_ChiTietHoaDon> Lvq_ChiTietHoaDons { get; set; }
    }
}
