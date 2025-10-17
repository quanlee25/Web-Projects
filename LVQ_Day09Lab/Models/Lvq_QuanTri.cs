using System.ComponentModel.DataAnnotations;

namespace LVQ_Day09Lab.Models
{
    public class Lvq_QuanTri
    {
            [Key]
            public int Lvq_ID { get; set; }
            public string Lvq_TaiKhoan { get; set; }
            public string Lvq_MatKhau { get; set; }
            public bool Lvq_TrangThai { get; set; }
    

    }
}
