using System.ComponentModel.DataAnnotations;

namespace LVQ_Day09Lab.Models
{
    public class Lvq_LoaiSanPham
    {
        [Key]
        public int Lvq_ID { get; set; }
        public string Lvq_MaLoai { get; set; }
        public string Lvq_TenLoai { get; set; }
        public bool Lvq_TrangThai { get; set; }

        public ICollection<Lvq_SanPham> Lvq_SanPhams { get; set; }
    }
}
