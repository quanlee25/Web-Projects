using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseFirst.Models
{
    [Table(name:"Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Quantity { get; set; }
        public string Description  { get; set; }
        public virtual ICollection<Product> Products { get;  }
    }
}
