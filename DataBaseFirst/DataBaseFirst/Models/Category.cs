using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseFirst.Models
{
    [Table( name: "Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Description { get; set; }
        [Column(TypeName = "ntext")]
        public bool CategoryId { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
