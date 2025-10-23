using System.ComponentModel.DataAnnotations;

namespace Web_Table01.Models
{
    public class Sach
    {
        [Key]
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public string MaTheLoai { get; set; }
        public string MaNXB { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public int SoLuong { get; set; }
        public int SoTrang { get; set; }
        public double TrongLuong { get; set; }
        public string Anh { get; set; }
    }
}
