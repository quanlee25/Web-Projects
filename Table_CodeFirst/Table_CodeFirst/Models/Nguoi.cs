using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Table_CodeFirst.Models
{
    [Table("Nguoi")]
    public class Nguoi
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Tuoi { get; set; }
        public virtual ICollection<Cho> DanhSachCho { get; set; }
    }
}
