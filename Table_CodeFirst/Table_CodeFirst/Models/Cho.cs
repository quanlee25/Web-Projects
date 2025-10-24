using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Table_CodeFirst.Models
{
    [Table("Cho")]
    public class Cho
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Giong { get; set; }
        public virtual ICollection<Nguoi> ChuSoHuu { get; set; }
    }
}
